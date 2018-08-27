using System;
using System.Linq;
using System.Windows.Forms;

using log4net;

using MergeMessage.Common.Contracts.Models;
using MergeMessage.Common.Contracts.Services;
using MergeMessage.Common.Enums;
using MergeMessage.Common.Models;

namespace MergeMessage
{
    public partial class MainForm : Form
    {
        private const string MergeMessageFormat = "Merged #{0} from {1} for {2}";

        private static readonly ILog Logger = LogManager.GetLogger(typeof(MainForm));

        private readonly ITfsChangesetParsingService _mTfsChangesetParsingService;
        private readonly IBranchRepository _mBranchRepository;
        private readonly IAlertService _mAlertService;

        public MainForm(ITfsChangesetParsingService mTfsChangesetParsingService, 
            IBranchRepository mBranchRepository, IAlertService mAlertService)
        {
            _mTfsChangesetParsingService = mTfsChangesetParsingService;
            _mBranchRepository = mBranchRepository;
            _mAlertService = mAlertService;

            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            var imputMessageParsingResult = _mTfsChangesetParsingService.Parse(InputMessageTextBox.Text);
            if (imputMessageParsingResult.HasErrors)
            {
                var errorsForMessage = string.Join(Environment.NewLine, imputMessageParsingResult.Errors);
                var errorMessage =
                    $"Some errors have been occured on parsing input message:{Environment.NewLine}{errorsForMessage}";
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

            var mergeMessage = BuildMergeMessage(imputMessageParsingResult.TfsCommitLine, targetBranch, additionalText);
            ResultTextBox.Text = mergeMessage;

            ResetCommitTable(imputMessageParsingResult.TfsCommitLine);
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(ResultTextBox.Text);
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InputMessageTextBox.Text.Trim()))
            {
                return;
            }

            var copiedText = Clipboard.GetText().Trim();
            if (!string.IsNullOrEmpty(copiedText))
            {
                InputMessageTextBox.Text = copiedText;
            }
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string BuildMergeMessage(ITfsChangeset parsedInputMessage, IBranch branch, string additionalText)
        {
            return string.Format(MergeMessageFormat,
                parsedInputMessage.Changeset,
                BuildBranchPartMessage(branch, additionalText),
                parsedInputMessage.Comment);
        }

        private string BuildBranchPartMessage(IBranch branch, string additionalText)
        {
            return string.Format(branch.Format, additionalText);
        }

        private void ResetCommitTable(ITfsChangeset parsedInputMessage)
        {
            CommitTable.Rows.Clear();

            if (parsedInputMessage == null)
            {
                Logger.Error("Unable to set message. Parsed message is null.");
                return;
            }

            CommitTable.Rows.Add(parsedInputMessage.Changeset,
                parsedInputMessage.User,
                parsedInputMessage.Date,
                parsedInputMessage.Comment);
        }
    }
}
