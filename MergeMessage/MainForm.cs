using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

using log4net;

using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Repository;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Enums;
using MergeMessage.Common.Models;

namespace MergeMessage
{
    public partial class MainForm : Form
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainForm));

        private readonly ITfsChangesetParsingService _mTfsChangesetParsingService;
        private readonly IBranchRepository _mBranchRepository;
        private readonly IAlertService _mAlertService;
        private readonly IProgramSettingsRepository _programSettingsRepository;
        private readonly IBuildMergeMessageService _buildMergeMessageService;

        public MainForm(
            ITfsChangesetParsingService mTfsChangesetParsingService, 
            IBranchRepository mBranchRepository, 
            IAlertService mAlertService, 
            IProgramSettingsRepository programSettingsRepository, 
            IBuildMergeMessageService buildMergeMessageService)
        {
            _mTfsChangesetParsingService = mTfsChangesetParsingService;
            _mBranchRepository = mBranchRepository;
            _mAlertService = mAlertService;
            _programSettingsRepository = programSettingsRepository;
            _buildMergeMessageService = buildMergeMessageService;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = GetTitle();
            SetMode(ProgramMode.Single);

            var branches = _mBranchRepository.GetAll();
            if (branches.Length > 0)
            {
                FromBranchComboBox.Items.AddRange(branches.Select(branch => (object) branch.Name).ToArray());
                FromBranchComboBox.SelectedIndex = 0;
            }
        }

        private void FromBranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var branch =  _mBranchRepository.GetByName(FromBranchComboBox.SelectedItem.ToString());

            if (branch == null)
            {
                Logger.Error("Nonexistent branch has been selected");
                FromBranchComboBox.SelectedIndex = 0;
                return;
            }

            FromBranchAdditionalLabel.Visible = branch.IsAdditionalNeeded;
            FromBranchAdditionalTextBox.Visible = branch.IsAdditionalNeeded;
            FromBranchAdditionalLabel.Text = branch.AdditionalLabel;
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            ResultRichTextBox.Text = string.Empty;
            CommitTable.Rows.Clear();

            var imputMessageParsingResult = _mTfsChangesetParsingService.Parse(InputMessageRichTextBox.Text);
            if (imputMessageParsingResult.HasErrors)
            {
                var errorsForMessage = string.Join(Environment.NewLine, imputMessageParsingResult.Errors);
                var errorMessage =
                    $"Some errors have been occured on parsing input message.{Environment.NewLine}{Environment.NewLine}{errorsForMessage}";
                Logger.Warn(errorMessage);
                _mAlertService.Alert(new AlertEntity("Error", errorMessage, AlertType.Error));
                return;
            }


            var targetBranch =  _mBranchRepository.GetByName(FromBranchComboBox.SelectedItem.ToString());
            if (targetBranch == null)
            {
                var errorMessage = $"Brnch with name '{FromBranchComboBox.SelectedItem}' hasn't been found";
                Logger.Warn(errorMessage);
                _mAlertService.Alert(new AlertEntity("Error", errorMessage, AlertType.Error));
                return;
            }

            var additionalText = FromBranchAdditionalTextBox.Text;

            var mergeMessages = _buildMergeMessageService.Build(imputMessageParsingResult.TfsCommitLines, targetBranch, additionalText);
            ResultRichTextBox.Text = string.Join(Environment.NewLine, mergeMessages);

            ResetCommitTable(imputMessageParsingResult.TfsCommitLines);
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ResultRichTextBox.Text);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputMessageRichTextBox.Text.Trim()))
            {
                return;
            }

            PasteCopiedText();
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            InputMessageRichTextBox.Text = string.Empty;
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            InputMessageRichTextBox.Text = string.Empty;
            PasteCopiedText();
        }

        private void RadioButtonModeChecked(object sender, EventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null || !radioButton.Checked)
            {
                return;
            }

            var isSingle = radioButton == SingleModeRadioButton;
            var mode = isSingle ? ProgramMode.Single : ProgramMode.Multi;
            SetMode(mode);
        }

        private void PasteCopiedText()
        {
            var copiedText = Clipboard.GetText().Trim();
            if (!string.IsNullOrEmpty(copiedText))
            {
                InputMessageRichTextBox.Text = copiedText;
            }
        }

        private void ResetCommitTable(IList<ITfsChangeset> parsedInputMessages)
        {
            CommitTable.Rows.Clear();

            if (parsedInputMessages == null)
            {
                Logger.Error("Unable to set message. Parsed message is null.");
                return;
            }

            foreach (var parsedInputMessage in parsedInputMessages)
            {
                CommitTable.Rows.Add(
                    parsedInputMessage.ChangesetNumber,
                    parsedInputMessage.User,
                    parsedInputMessage.Date,
                    parsedInputMessage.TaskNumber,
                    parsedInputMessage.Comment);
            }
        }

        private void SetMode(ProgramMode mode)
        {
            _programSettingsRepository.ProgramMode = mode;

            if (mode == ProgramMode.Single)
            {
                SingleModeRadioButton.Checked = true;
            }
            else
            {
                MultiModeRadioButton.Checked = true;
            }
        }

        private string GetTitle()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return $"{GetAssemblyTitle(assembly)} v{GetAssemblyVersion(assembly)}";
        }

        private string GetAssemblyTitle(Assembly assembly)
        {
            var assemblyTitleAttribute =
                (AssemblyTitleAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute), false);
            return assemblyTitleAttribute?.Title ?? "Merge Message";
        }

        private string GetAssemblyVersion(Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }
    }
}
