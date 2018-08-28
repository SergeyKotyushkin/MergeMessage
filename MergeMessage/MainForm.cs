using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly string _mergeMessageFormat;

        private readonly ITfsChangesetParsingService _mTfsChangesetParsingService;
        private readonly IBranchRepository _mBranchRepository;
        private readonly IAlertService _mAlertService;
        private readonly IProgramSettingsRepository _programSettingsRepository;

        public MainForm(
            ITfsChangesetParsingService mTfsChangesetParsingService, 
            IBranchRepository mBranchRepository, 
            IAlertService mAlertService, 
            IProgramSettingsRepository programSettingsRepository)
        {
            _mTfsChangesetParsingService = mTfsChangesetParsingService;
            _mBranchRepository = mBranchRepository;
            _mAlertService = mAlertService;
            _programSettingsRepository = programSettingsRepository;

            _mergeMessageFormat = _programSettingsRepository.MergeMessageFormat;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetMode(true);
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

            var mergeMessages = BuildMergeMessages(imputMessageParsingResult.TfsCommitLines, targetBranch, additionalText);
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

        private void CurrentModeClick(object sender, EventArgs e)
        {
            var modeItem = sender as ToolStripMenuItem;
            if (modeItem == null || modeItem.Checked)
            {
                return;
            }

            SetMode(sender == SingleModeToolStripMenuItem);
        }

        private void PasteCopiedText()
        {
            var copiedText = Clipboard.GetText().Trim();
            if (!string.IsNullOrEmpty(copiedText))
            {
                InputMessageRichTextBox.Text = copiedText;
            }
        }

        private string[] BuildMergeMessages(IList<ITfsChangeset> parsedInputMessages, IBranch branch, string additionalText)
        {
            var builtMergeMessages = new string[parsedInputMessages.Count];
            for (var i = 0; i < parsedInputMessages.Count; i++)
            {
                builtMergeMessages[i] = BuildMergeMessage(parsedInputMessages[i], branch, additionalText);
            }

            return builtMergeMessages;
        }

        private string BuildMergeMessage(ITfsChangeset parsedInputMessage, IBranch branch, string additionalText)
        {
            return string.Format(_mergeMessageFormat,
                parsedInputMessage.Changeset,
                BuildBranchPartMessage(branch, additionalText),
                parsedInputMessage.Comment);
        }

        private string BuildBranchPartMessage(IBranch branch, string additionalText)
        {
            return string.Format(branch.Format, additionalText);
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
                    parsedInputMessage.Changeset,
                    parsedInputMessage.User,
                    parsedInputMessage.Date,
                    parsedInputMessage.Comment);
            }
        }

        private void SetMode(bool isSingle)
        {
            SingleModeToolStripMenuItem.Checked = isSingle;
            MultiModeToolStripMenuItem.Checked = !isSingle;

            _programSettingsRepository.ProgramMode = isSingle ? ProgramMode.Single : ProgramMode.Multi;
        }
    }
}
