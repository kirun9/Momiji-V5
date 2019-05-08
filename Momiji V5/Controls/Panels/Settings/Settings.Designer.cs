namespace Momiji.Bot.V5.Core.Controls.Panels.Settings
{
	partial class Settings
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.DiscordSocketConfigLabel = new System.Windows.Forms.Label();
			this.borderPanel1 = new kirun9.WinForms.Controls.BorderPanel();
			this.MessageCacheSize = new System.Windows.Forms.NumericUpDown();
			this.LogSeverity = new System.Windows.Forms.ComboBox();
			this.DefaultRetryMode = new System.Windows.Forms.ComboBox();
			this.MessageCacheSizeLabel = new System.Windows.Forms.Label();
			this.LogSeverityLabel = new System.Windows.Forms.Label();
			this.DefaultRetryModeLabel = new System.Windows.Forms.Label();
			this.CommandServiceConfigLabel = new System.Windows.Forms.Label();
			this.borderPanel2 = new kirun9.WinForms.Controls.BorderPanel();
			this.SeparatorChar = new System.Windows.Forms.TextBox();
			this.LogLevel = new System.Windows.Forms.ComboBox();
			this.ThrowOnError = new System.Windows.Forms.ComboBox();
			this.IgnoreExtraArgs = new System.Windows.Forms.ComboBox();
			this.LogLevelLabel = new System.Windows.Forms.Label();
			this.ThrowOnErrorLabel = new System.Windows.Forms.Label();
			this.IgnoreExtraArgsLabel = new System.Windows.Forms.Label();
			this.DefaultRunMode = new System.Windows.Forms.ComboBox();
			this.SeparatorCharLabel = new System.Windows.Forms.Label();
			this.DefaultRunModeLabel = new System.Windows.Forms.Label();
			this.CaseSensitiveCommands = new System.Windows.Forms.ComboBox();
			this.CaseSensitiveCommandsLabel = new System.Windows.Forms.Label();
			this.SaveButton = new System.Windows.Forms.Button();
			this.borderPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MessageCacheSize)).BeginInit();
			this.borderPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// DiscordSocketConfigLabel
			// 
			this.DiscordSocketConfigLabel.AutoSize = true;
			this.DiscordSocketConfigLabel.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DiscordSocketConfigLabel.Location = new System.Drawing.Point(17, 15);
			this.DiscordSocketConfigLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
			this.DiscordSocketConfigLabel.Name = "DiscordSocketConfigLabel";
			this.DiscordSocketConfigLabel.Size = new System.Drawing.Size(219, 19);
			this.DiscordSocketConfigLabel.TabIndex = 1;
			this.DiscordSocketConfigLabel.Text = "Discord Socket Config";
			// 
			// borderPanel1
			// 
			this.borderPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.borderPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.borderPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.borderPanel1.Controls.Add(this.MessageCacheSize);
			this.borderPanel1.Controls.Add(this.LogSeverity);
			this.borderPanel1.Controls.Add(this.DefaultRetryMode);
			this.borderPanel1.Controls.Add(this.MessageCacheSizeLabel);
			this.borderPanel1.Controls.Add(this.LogSeverityLabel);
			this.borderPanel1.Controls.Add(this.DefaultRetryModeLabel);
			this.borderPanel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.borderPanel1.Location = new System.Drawing.Point(15, 37);
			this.borderPanel1.Margin = new System.Windows.Forms.Padding(15, 3, 15, 15);
			this.borderPanel1.Name = "borderPanel1";
			this.borderPanel1.PenWidth = 1F;
			this.borderPanel1.Size = new System.Drawing.Size(644, 52);
			this.borderPanel1.TabIndex = 0;
			// 
			// MessageCacheSize
			// 
			this.MessageCacheSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.MessageCacheSize.Location = new System.Drawing.Point(335, 24);
			this.MessageCacheSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.MessageCacheSize.Name = "MessageCacheSize";
			this.MessageCacheSize.Size = new System.Drawing.Size(160, 20);
			this.MessageCacheSize.TabIndex = 2;
			this.MessageCacheSize.ValueChanged += new System.EventHandler(this.MessageCacheSize_ValueChanged);
			// 
			// LogSeverity
			// 
			this.LogSeverity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.LogSeverity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.LogSeverity.Items.AddRange(new object[] {
            "Critical",
            "Debug",
            "Error",
            "Info",
            "Verbose",
            "Warning"});
			this.LogSeverity.Location = new System.Drawing.Point(169, 24);
			this.LogSeverity.Name = "LogSeverity";
			this.LogSeverity.Size = new System.Drawing.Size(160, 21);
			this.LogSeverity.TabIndex = 1;
			this.LogSeverity.SelectedIndexChanged += new System.EventHandler(this.LogSeverity_SelectedIndexChanged);
			// 
			// DefaultRetryMode
			// 
			this.DefaultRetryMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.DefaultRetryMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.DefaultRetryMode.Items.AddRange(new object[] {
            "AlwaysFail",
            "AlwaysRetry",
            "Retry502",
            "RetryRatelimit",
            "RetryTimeouts"});
			this.DefaultRetryMode.Location = new System.Drawing.Point(3, 24);
			this.DefaultRetryMode.Name = "DefaultRetryMode";
			this.DefaultRetryMode.Size = new System.Drawing.Size(160, 21);
			this.DefaultRetryMode.TabIndex = 1;
			this.DefaultRetryMode.SelectedIndexChanged += new System.EventHandler(this.DefaultRetryMode_SelectedIndexChanged);
			// 
			// MessageCacheSizeLabel
			// 
			this.MessageCacheSizeLabel.AutoEllipsis = true;
			this.MessageCacheSizeLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.MessageCacheSizeLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.MessageCacheSizeLabel.Location = new System.Drawing.Point(335, 4);
			this.MessageCacheSizeLabel.Name = "MessageCacheSizeLabel";
			this.MessageCacheSizeLabel.Size = new System.Drawing.Size(160, 17);
			this.MessageCacheSizeLabel.TabIndex = 0;
			this.MessageCacheSizeLabel.Text = "Message Cache Size";
			this.MessageCacheSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.MessageCacheSizeLabel.UseMnemonic = false;
			// 
			// LogSeverityLabel
			// 
			this.LogSeverityLabel.AutoEllipsis = true;
			this.LogSeverityLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.LogSeverityLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.LogSeverityLabel.Location = new System.Drawing.Point(169, 4);
			this.LogSeverityLabel.Name = "LogSeverityLabel";
			this.LogSeverityLabel.Size = new System.Drawing.Size(160, 17);
			this.LogSeverityLabel.TabIndex = 0;
			this.LogSeverityLabel.Text = "Log Severity";
			this.LogSeverityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LogSeverityLabel.UseMnemonic = false;
			// 
			// DefaultRetryModeLabel
			// 
			this.DefaultRetryModeLabel.AutoEllipsis = true;
			this.DefaultRetryModeLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DefaultRetryModeLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.DefaultRetryModeLabel.Location = new System.Drawing.Point(3, 4);
			this.DefaultRetryModeLabel.Name = "DefaultRetryModeLabel";
			this.DefaultRetryModeLabel.Size = new System.Drawing.Size(160, 17);
			this.DefaultRetryModeLabel.TabIndex = 0;
			this.DefaultRetryModeLabel.Text = "Default Retry Mode";
			this.DefaultRetryModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DefaultRetryModeLabel.UseMnemonic = false;
			// 
			// CommandServiceConfigLabel
			// 
			this.CommandServiceConfigLabel.AutoSize = true;
			this.CommandServiceConfigLabel.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CommandServiceConfigLabel.Location = new System.Drawing.Point(17, 100);
			this.CommandServiceConfigLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
			this.CommandServiceConfigLabel.Name = "CommandServiceConfigLabel";
			this.CommandServiceConfigLabel.Size = new System.Drawing.Size(229, 19);
			this.CommandServiceConfigLabel.TabIndex = 2;
			this.CommandServiceConfigLabel.Text = "Command Service Config";
			// 
			// borderPanel2
			// 
			this.borderPanel2.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.borderPanel2.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.borderPanel2.Controls.Add(this.SeparatorChar);
			this.borderPanel2.Controls.Add(this.LogLevel);
			this.borderPanel2.Controls.Add(this.ThrowOnError);
			this.borderPanel2.Controls.Add(this.IgnoreExtraArgs);
			this.borderPanel2.Controls.Add(this.LogLevelLabel);
			this.borderPanel2.Controls.Add(this.ThrowOnErrorLabel);
			this.borderPanel2.Controls.Add(this.IgnoreExtraArgsLabel);
			this.borderPanel2.Controls.Add(this.DefaultRunMode);
			this.borderPanel2.Controls.Add(this.SeparatorCharLabel);
			this.borderPanel2.Controls.Add(this.DefaultRunModeLabel);
			this.borderPanel2.Controls.Add(this.CaseSensitiveCommands);
			this.borderPanel2.Controls.Add(this.CaseSensitiveCommandsLabel);
			this.borderPanel2.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.borderPanel2.Location = new System.Drawing.Point(15, 122);
			this.borderPanel2.Name = "borderPanel2";
			this.borderPanel2.PenWidth = 1F;
			this.borderPanel2.Size = new System.Drawing.Size(644, 107);
			this.borderPanel2.TabIndex = 3;
			// 
			// SeparatorChar
			// 
			this.SeparatorChar.Location = new System.Drawing.Point(3, 80);
			this.SeparatorChar.MaxLength = 1;
			this.SeparatorChar.Name = "SeparatorChar";
			this.SeparatorChar.Size = new System.Drawing.Size(160, 20);
			this.SeparatorChar.TabIndex = 6;
			this.SeparatorChar.WordWrap = false;
			this.SeparatorChar.TextChanged += new System.EventHandler(this.SeparatorChar_TextChanged);
			// 
			// LogLevel
			// 
			this.LogLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.LogLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.LogLevel.Items.AddRange(new object[] {
            "Critical",
            "Error",
            "Info",
            "Warning",
            "Verbose",
            "Debug"});
			this.LogLevel.Location = new System.Drawing.Point(501, 25);
			this.LogLevel.Name = "LogLevel";
			this.LogLevel.Size = new System.Drawing.Size(140, 21);
			this.LogLevel.TabIndex = 5;
			this.LogLevel.SelectedIndexChanged += new System.EventHandler(this.LogLevel_SelectedIndexChanged);
			// 
			// ThrowOnError
			// 
			this.ThrowOnError.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.ThrowOnError.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.ThrowOnError.Items.AddRange(new object[] {
            "True",
            "False"});
			this.ThrowOnError.Location = new System.Drawing.Point(169, 79);
			this.ThrowOnError.Name = "ThrowOnError";
			this.ThrowOnError.Size = new System.Drawing.Size(160, 21);
			this.ThrowOnError.TabIndex = 5;
			this.ThrowOnError.SelectedIndexChanged += new System.EventHandler(this.ThrowOnError_SelectedIndexChanged);
			// 
			// IgnoreExtraArgs
			// 
			this.IgnoreExtraArgs.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.IgnoreExtraArgs.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.IgnoreExtraArgs.Items.AddRange(new object[] {
            "True",
            "False"});
			this.IgnoreExtraArgs.Location = new System.Drawing.Point(335, 25);
			this.IgnoreExtraArgs.Name = "IgnoreExtraArgs";
			this.IgnoreExtraArgs.Size = new System.Drawing.Size(160, 21);
			this.IgnoreExtraArgs.TabIndex = 5;
			this.IgnoreExtraArgs.SelectedIndexChanged += new System.EventHandler(this.IgnoreExtraArgs_SelectedIndexChanged);
			// 
			// LogLevelLabel
			// 
			this.LogLevelLabel.AutoEllipsis = true;
			this.LogLevelLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.LogLevelLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.LogLevelLabel.Location = new System.Drawing.Point(501, 5);
			this.LogLevelLabel.Name = "LogLevelLabel";
			this.LogLevelLabel.Size = new System.Drawing.Size(140, 17);
			this.LogLevelLabel.TabIndex = 4;
			this.LogLevelLabel.Text = "Log Level";
			this.LogLevelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.LogLevelLabel.UseMnemonic = false;
			// 
			// ThrowOnErrorLabel
			// 
			this.ThrowOnErrorLabel.AutoEllipsis = true;
			this.ThrowOnErrorLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.ThrowOnErrorLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.ThrowOnErrorLabel.Location = new System.Drawing.Point(169, 59);
			this.ThrowOnErrorLabel.Name = "ThrowOnErrorLabel";
			this.ThrowOnErrorLabel.Size = new System.Drawing.Size(160, 17);
			this.ThrowOnErrorLabel.TabIndex = 4;
			this.ThrowOnErrorLabel.Text = "Throw On Error";
			this.ThrowOnErrorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ThrowOnErrorLabel.UseMnemonic = false;
			// 
			// IgnoreExtraArgsLabel
			// 
			this.IgnoreExtraArgsLabel.AutoEllipsis = true;
			this.IgnoreExtraArgsLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.IgnoreExtraArgsLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.IgnoreExtraArgsLabel.Location = new System.Drawing.Point(335, 5);
			this.IgnoreExtraArgsLabel.Name = "IgnoreExtraArgsLabel";
			this.IgnoreExtraArgsLabel.Size = new System.Drawing.Size(160, 17);
			this.IgnoreExtraArgsLabel.TabIndex = 4;
			this.IgnoreExtraArgsLabel.Text = "Ignore Extra Args";
			this.IgnoreExtraArgsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.IgnoreExtraArgsLabel.UseMnemonic = false;
			// 
			// DefaultRunMode
			// 
			this.DefaultRunMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.DefaultRunMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.DefaultRunMode.Items.AddRange(new object[] {
            "Async",
            "Default",
            "Sync"});
			this.DefaultRunMode.Location = new System.Drawing.Point(169, 25);
			this.DefaultRunMode.Name = "DefaultRunMode";
			this.DefaultRunMode.Size = new System.Drawing.Size(160, 21);
			this.DefaultRunMode.TabIndex = 5;
			this.DefaultRunMode.SelectedIndexChanged += new System.EventHandler(this.DefaultRunMode_SelectedIndexChanged);
			// 
			// SeparatorCharLabel
			// 
			this.SeparatorCharLabel.AutoEllipsis = true;
			this.SeparatorCharLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.SeparatorCharLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.SeparatorCharLabel.Location = new System.Drawing.Point(3, 59);
			this.SeparatorCharLabel.Name = "SeparatorCharLabel";
			this.SeparatorCharLabel.Size = new System.Drawing.Size(160, 17);
			this.SeparatorCharLabel.TabIndex = 4;
			this.SeparatorCharLabel.Text = "Separator Char";
			this.SeparatorCharLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.SeparatorCharLabel.UseMnemonic = false;
			// 
			// DefaultRunModeLabel
			// 
			this.DefaultRunModeLabel.AutoEllipsis = true;
			this.DefaultRunModeLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DefaultRunModeLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.DefaultRunModeLabel.Location = new System.Drawing.Point(169, 5);
			this.DefaultRunModeLabel.Name = "DefaultRunModeLabel";
			this.DefaultRunModeLabel.Size = new System.Drawing.Size(160, 17);
			this.DefaultRunModeLabel.TabIndex = 4;
			this.DefaultRunModeLabel.Text = "Default Run Mode";
			this.DefaultRunModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DefaultRunModeLabel.UseMnemonic = false;
			// 
			// CaseSensitiveCommands
			// 
			this.CaseSensitiveCommands.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.CaseSensitiveCommands.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.CaseSensitiveCommands.Items.AddRange(new object[] {
            "True",
            "False"});
			this.CaseSensitiveCommands.Location = new System.Drawing.Point(3, 25);
			this.CaseSensitiveCommands.Name = "CaseSensitiveCommands";
			this.CaseSensitiveCommands.Size = new System.Drawing.Size(160, 21);
			this.CaseSensitiveCommands.TabIndex = 3;
			this.CaseSensitiveCommands.SelectedIndexChanged += new System.EventHandler(this.CaseSensitiveCommands_SelectedIndexChanged);
			// 
			// CaseSensitiveCommandsLabel
			// 
			this.CaseSensitiveCommandsLabel.AutoEllipsis = true;
			this.CaseSensitiveCommandsLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.CaseSensitiveCommandsLabel.Font = new System.Drawing.Font("Monospac821 BT", 7.5F, System.Drawing.FontStyle.Bold);
			this.CaseSensitiveCommandsLabel.Location = new System.Drawing.Point(3, 5);
			this.CaseSensitiveCommandsLabel.Name = "CaseSensitiveCommandsLabel";
			this.CaseSensitiveCommandsLabel.Size = new System.Drawing.Size(160, 17);
			this.CaseSensitiveCommandsLabel.TabIndex = 2;
			this.CaseSensitiveCommandsLabel.Text = "Case Sensitive Commands";
			this.CaseSensitiveCommandsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CaseSensitiveCommandsLabel.UseMnemonic = false;
			// 
			// SaveButton
			// 
			this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.SaveButton.FlatAppearance.BorderSize = 0;
			this.SaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.SaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.SaveButton.Font = new System.Drawing.Font("Special Elite", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SaveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.SaveButton.Location = new System.Drawing.Point(516, 345);
			this.SaveButton.Margin = new System.Windows.Forms.Padding(15);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(143, 30);
			this.SaveButton.TabIndex = 3;
			this.SaveButton.Text = "Save";
			this.SaveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.SaveButton.UseVisualStyleBackColor = false;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.borderPanel2);
			this.Controls.Add(this.CommandServiceConfigLabel);
			this.Controls.Add(this.DiscordSocketConfigLabel);
			this.Controls.Add(this.borderPanel1);
			this.Name = "Settings";
			this.Size = new System.Drawing.Size(674, 390);
			this.borderPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MessageCacheSize)).EndInit();
			this.borderPanel2.ResumeLayout(false);
			this.borderPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private kirun9.WinForms.Controls.BorderPanel borderPanel1;
		private System.Windows.Forms.Label DefaultRetryModeLabel;
		private System.Windows.Forms.ComboBox DefaultRetryMode;
		private System.Windows.Forms.ComboBox LogSeverity;
		private System.Windows.Forms.Label LogSeverityLabel;
		private System.Windows.Forms.NumericUpDown MessageCacheSize;
		private System.Windows.Forms.Label MessageCacheSizeLabel;
		private kirun9.WinForms.Controls.BorderPanel borderPanel2;
		private System.Windows.Forms.ComboBox DefaultRunMode;
		private System.Windows.Forms.Label DefaultRunModeLabel;
		private System.Windows.Forms.ComboBox CaseSensitiveCommands;
		private System.Windows.Forms.Label CaseSensitiveCommandsLabel;
		private System.Windows.Forms.ComboBox IgnoreExtraArgs;
		private System.Windows.Forms.Label IgnoreExtraArgsLabel;
		private System.Windows.Forms.ComboBox LogLevel;
		private System.Windows.Forms.Label LogLevelLabel;
		private System.Windows.Forms.TextBox SeparatorChar;
		private System.Windows.Forms.ComboBox ThrowOnError;
		private System.Windows.Forms.Label ThrowOnErrorLabel;
		private System.Windows.Forms.Label SeparatorCharLabel;
		private System.Windows.Forms.Label DiscordSocketConfigLabel;
		private System.Windows.Forms.Label CommandServiceConfigLabel;
		private System.Windows.Forms.Button SaveButton;
	}
}
