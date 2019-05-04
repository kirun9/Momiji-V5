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
			System.Windows.Forms.Label DiscordSocketConfigLabel;
			this.borderPanel1 = new kirun9.WinForms.Controls.BorderPanel();
			this.DefaultRetryMode = new System.Windows.Forms.ComboBox();
			this.DefaultRetryModeLabel = new System.Windows.Forms.Label();
			this.LogSeverityLabel = new System.Windows.Forms.Label();
			this.LogSeverity = new System.Windows.Forms.ComboBox();
			this.MessageCacheSizeLabel = new System.Windows.Forms.Label();
			this.MessageCacheSize = new System.Windows.Forms.NumericUpDown();
			DiscordSocketConfigLabel = new System.Windows.Forms.Label();
			this.borderPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MessageCacheSize)).BeginInit();
			this.SuspendLayout();
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
			// DiscordSocketConfigLabel
			// 
			DiscordSocketConfigLabel.AutoSize = true;
			DiscordSocketConfigLabel.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			DiscordSocketConfigLabel.Location = new System.Drawing.Point(17, 15);
			DiscordSocketConfigLabel.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
			DiscordSocketConfigLabel.Name = "DiscordSocketConfigLabel";
			DiscordSocketConfigLabel.Size = new System.Drawing.Size(219, 19);
			DiscordSocketConfigLabel.TabIndex = 1;
			DiscordSocketConfigLabel.Text = "Discord Socket Config";
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.Controls.Add(DiscordSocketConfigLabel);
			this.Controls.Add(this.borderPanel1);
			this.Name = "Settings";
			this.Size = new System.Drawing.Size(674, 390);
			this.borderPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MessageCacheSize)).EndInit();
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
	}
}
