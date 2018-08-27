namespace MergeMessage
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputMessageLabel = new System.Windows.Forms.Label();
            this.FromBranchLabel = new System.Windows.Forms.Label();
            this.FromBranchComboBox = new System.Windows.Forms.ComboBox();
            this.FromBranchAdditionalLabel = new System.Windows.Forms.Label();
            this.FromBranchAdditionalTextBox = new System.Windows.Forms.TextBox();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.CopyToClipboardButton = new System.Windows.Forms.Button();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CommitTable = new System.Windows.Forms.DataGridView();
            this.CommitNumberColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommitAuthorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommitDateTimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommitMessageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ReplaceButton = new System.Windows.Forms.Button();
            this.InputMessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommitTable)).BeginInit();
            this.SuspendLayout();
            // 
            // InputMessageLabel
            // 
            this.InputMessageLabel.AutoSize = true;
            this.InputMessageLabel.Location = new System.Drawing.Point(13, 33);
            this.InputMessageLabel.Name = "InputMessageLabel";
            this.InputMessageLabel.Size = new System.Drawing.Size(104, 13);
            this.InputMessageLabel.TabIndex = 0;
            this.InputMessageLabel.Text = "Input origin message";
            // 
            // FromBranchLabel
            // 
            this.FromBranchLabel.AutoSize = true;
            this.FromBranchLabel.Location = new System.Drawing.Point(13, 127);
            this.FromBranchLabel.Name = "FromBranchLabel";
            this.FromBranchLabel.Size = new System.Drawing.Size(66, 13);
            this.FromBranchLabel.TabIndex = 2;
            this.FromBranchLabel.Text = "From branch";
            // 
            // FromBranchComboBox
            // 
            this.FromBranchComboBox.FormattingEnabled = true;
            this.FromBranchComboBox.Location = new System.Drawing.Point(16, 144);
            this.FromBranchComboBox.Name = "FromBranchComboBox";
            this.FromBranchComboBox.Size = new System.Drawing.Size(120, 21);
            this.FromBranchComboBox.TabIndex = 3;
            this.FromBranchComboBox.SelectedIndexChanged += new System.EventHandler(this.FromBranchComboBox_SelectedIndexChanged);
            // 
            // FromBranchAdditionalLabel
            // 
            this.FromBranchAdditionalLabel.AutoSize = true;
            this.FromBranchAdditionalLabel.Location = new System.Drawing.Point(210, 127);
            this.FromBranchAdditionalLabel.Name = "FromBranchAdditionalLabel";
            this.FromBranchAdditionalLabel.Size = new System.Drawing.Size(0, 13);
            this.FromBranchAdditionalLabel.TabIndex = 4;
            this.FromBranchAdditionalLabel.Visible = false;
            // 
            // FromBranchAdditionalTextBox
            // 
            this.FromBranchAdditionalTextBox.Location = new System.Drawing.Point(213, 145);
            this.FromBranchAdditionalTextBox.Name = "FromBranchAdditionalTextBox";
            this.FromBranchAdditionalTextBox.Size = new System.Drawing.Size(100, 20);
            this.FromBranchAdditionalTextBox.TabIndex = 5;
            this.FromBranchAdditionalTextBox.Visible = false;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(16, 199);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(16, 299);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(545, 83);
            this.ResultTextBox.TabIndex = 7;
            // 
            // CopyToClipboardButton
            // 
            this.CopyToClipboardButton.Location = new System.Drawing.Point(16, 388);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(101, 23);
            this.CopyToClipboardButton.TabIndex = 8;
            this.CopyToClipboardButton.Text = "Copy to clipboard";
            this.CopyToClipboardButton.UseVisualStyleBackColor = true;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(573, 24);
            this.MenuStrip.TabIndex = 9;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem
            // 
            this.MenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            this.MenuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.MenuToolStripMenuItem.Text = "Menu";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.AboutToolStripMenuItem.Text = "About";
            // 
            // CommitTable
            // 
            this.CommitTable.AllowUserToAddRows = false;
            this.CommitTable.AllowUserToDeleteRows = false;
            this.CommitTable.AllowUserToResizeRows = false;
            this.CommitTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CommitTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CommitTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CommitNumberColumn,
            this.CommitAuthorColumn,
            this.CommitDateTimeColumn,
            this.CommitMessageColumn});
            this.CommitTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.CommitTable.Location = new System.Drawing.Point(16, 229);
            this.CommitTable.MultiSelect = false;
            this.CommitTable.Name = "CommitTable";
            this.CommitTable.ReadOnly = true;
            this.CommitTable.RowHeadersVisible = false;
            this.CommitTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.CommitTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CommitTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.CommitTable.Size = new System.Drawing.Size(545, 64);
            this.CommitTable.TabIndex = 10;
            // 
            // CommitNumberColumn
            // 
            this.CommitNumberColumn.HeaderText = "Changeset";
            this.CommitNumberColumn.Name = "CommitNumberColumn";
            this.CommitNumberColumn.ReadOnly = true;
            // 
            // CommitAuthorColumn
            // 
            this.CommitAuthorColumn.HeaderText = "User";
            this.CommitAuthorColumn.Name = "CommitAuthorColumn";
            this.CommitAuthorColumn.ReadOnly = true;
            // 
            // CommitDateTimeColumn
            // 
            this.CommitDateTimeColumn.HeaderText = "Date";
            this.CommitDateTimeColumn.Name = "CommitDateTimeColumn";
            this.CommitDateTimeColumn.ReadOnly = true;
            // 
            // CommitMessageColumn
            // 
            this.CommitMessageColumn.HeaderText = "Comment";
            this.CommitMessageColumn.Name = "CommitMessageColumn";
            this.CommitMessageColumn.ReadOnly = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(433, 105);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(61, 23);
            this.ClearButton.TabIndex = 11;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ReplaceButton
            // 
            this.ReplaceButton.Location = new System.Drawing.Point(500, 105);
            this.ReplaceButton.Name = "ReplaceButton";
            this.ReplaceButton.Size = new System.Drawing.Size(61, 23);
            this.ReplaceButton.TabIndex = 13;
            this.ReplaceButton.Text = "Replace";
            this.ReplaceButton.UseVisualStyleBackColor = true;
            this.ReplaceButton.Click += new System.EventHandler(this.ReplaceButton_Click);
            // 
            // InputMessageTextBox
            // 
            this.InputMessageRichTextBox.Location = new System.Drawing.Point(16, 49);
            this.InputMessageRichTextBox.Name = "InputMessageRichTextBox";
            this.InputMessageRichTextBox.Size = new System.Drawing.Size(545, 50);
            this.InputMessageRichTextBox.TabIndex = 14;
            this.InputMessageRichTextBox.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 422);
            this.Controls.Add(this.InputMessageRichTextBox);
            this.Controls.Add(this.ReplaceButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.CommitTable);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.FromBranchAdditionalTextBox);
            this.Controls.Add(this.FromBranchAdditionalLabel);
            this.Controls.Add(this.FromBranchComboBox);
            this.Controls.Add(this.FromBranchLabel);
            this.Controls.Add(this.InputMessageLabel);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge Message v1.0.0.0";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommitTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InputMessageLabel;
        private System.Windows.Forms.Label FromBranchLabel;
        private System.Windows.Forms.ComboBox FromBranchComboBox;
        private System.Windows.Forms.Label FromBranchAdditionalLabel;
        private System.Windows.Forms.TextBox FromBranchAdditionalTextBox;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Button CopyToClipboardButton;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView CommitTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommitNumberColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommitAuthorColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommitDateTimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommitMessageColumn;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ReplaceButton;
        private System.Windows.Forms.RichTextBox InputMessageRichTextBox;
    }
}