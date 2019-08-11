namespace Momiji.Bot.V5.Core.Controls.Panels.RunCommand
{
	partial class CommandTree
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
			this.DiscordServer = new System.Windows.Forms.ComboBox();
			this.ServerChannel = new System.Windows.Forms.ComboBox();
			this.DiscordServerLabel = new System.Windows.Forms.Label();
			this.ServerChannelLabel = new System.Windows.Forms.Label();
			this.ChannelUser = new System.Windows.Forms.ComboBox();
			this.ChannelUserLabel = new System.Windows.Forms.Label();
			this.Command = new System.Windows.Forms.TextBox();
			this.CommandLabel = new System.Windows.Forms.Label();
			this.ExecuteButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// DiscordServer
			// 
			this.DiscordServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.DiscordServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.DiscordServer.Location = new System.Drawing.Point(24, 70);
			this.DiscordServer.Name = "DiscordServer";
			this.DiscordServer.Size = new System.Drawing.Size(123, 21);
			this.DiscordServer.TabIndex = 4;
			this.DiscordServer.SelectedIndexChanged += new System.EventHandler(this.DiscordServer_SelectedIndexChanged);
			// 
			// ServerChannel
			// 
			this.ServerChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.ServerChannel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.ServerChannel.Enabled = false;
			this.ServerChannel.Location = new System.Drawing.Point(153, 70);
			this.ServerChannel.Name = "ServerChannel";
			this.ServerChannel.Size = new System.Drawing.Size(123, 21);
			this.ServerChannel.TabIndex = 4;
			this.ServerChannel.SelectedIndexChanged += new System.EventHandler(this.ServerChannel_SelectedIndexChanged);
			// 
			// DiscordServerLabel
			// 
			this.DiscordServerLabel.AutoEllipsis = true;
			this.DiscordServerLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.DiscordServerLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.DiscordServerLabel.Location = new System.Drawing.Point(24, 50);
			this.DiscordServerLabel.Name = "DiscordServerLabel";
			this.DiscordServerLabel.Size = new System.Drawing.Size(123, 17);
			this.DiscordServerLabel.TabIndex = 5;
			this.DiscordServerLabel.Text = "Discord Server";
			this.DiscordServerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.DiscordServerLabel.UseMnemonic = false;
			// 
			// ServerChannelLabel
			// 
			this.ServerChannelLabel.AutoEllipsis = true;
			this.ServerChannelLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.ServerChannelLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.ServerChannelLabel.Location = new System.Drawing.Point(153, 50);
			this.ServerChannelLabel.Name = "ServerChannelLabel";
			this.ServerChannelLabel.Size = new System.Drawing.Size(123, 17);
			this.ServerChannelLabel.TabIndex = 5;
			this.ServerChannelLabel.Text = "Server Channel";
			this.ServerChannelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ServerChannelLabel.UseMnemonic = false;
			// 
			// ChannelUser
			// 
			this.ChannelUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.ChannelUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.ChannelUser.Enabled = false;
			this.ChannelUser.Location = new System.Drawing.Point(282, 70);
			this.ChannelUser.Name = "ChannelUser";
			this.ChannelUser.Size = new System.Drawing.Size(123, 21);
			this.ChannelUser.TabIndex = 4;
			// 
			// ChannelUserLabel
			// 
			this.ChannelUserLabel.AutoEllipsis = true;
			this.ChannelUserLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.ChannelUserLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.ChannelUserLabel.Location = new System.Drawing.Point(282, 50);
			this.ChannelUserLabel.Name = "ChannelUserLabel";
			this.ChannelUserLabel.Size = new System.Drawing.Size(123, 17);
			this.ChannelUserLabel.TabIndex = 5;
			this.ChannelUserLabel.Text = "Channel User";
			this.ChannelUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ChannelUserLabel.UseMnemonic = false;
			// 
			// Command
			// 
			this.Command.Location = new System.Drawing.Point(24, 124);
			this.Command.Name = "Command";
			this.Command.Size = new System.Drawing.Size(381, 20);
			this.Command.TabIndex = 6;
			this.Command.TextChanged += new System.EventHandler(this.Command_TextChanged);
			// 
			// CommandLabel
			// 
			this.CommandLabel.AutoEllipsis = true;
			this.CommandLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.CommandLabel.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.CommandLabel.Location = new System.Drawing.Point(24, 104);
			this.CommandLabel.Name = "CommandLabel";
			this.CommandLabel.Size = new System.Drawing.Size(70, 17);
			this.CommandLabel.TabIndex = 5;
			this.CommandLabel.Text = "Command";
			this.CommandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.CommandLabel.UseMnemonic = false;
			// 
			// ExecuteButton
			// 
			this.ExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ExecuteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.ExecuteButton.Enabled = false;
			this.ExecuteButton.FlatAppearance.BorderSize = 0;
			this.ExecuteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.ExecuteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExecuteButton.Font = new System.Drawing.Font("Special Elite", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExecuteButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.ExecuteButton.Location = new System.Drawing.Point(516, 345);
			this.ExecuteButton.Margin = new System.Windows.Forms.Padding(15);
			this.ExecuteButton.Name = "ExecuteButton";
			this.ExecuteButton.Size = new System.Drawing.Size(143, 30);
			this.ExecuteButton.TabIndex = 7;
			this.ExecuteButton.Text = "Execute";
			this.ExecuteButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.ExecuteButton.UseVisualStyleBackColor = false;
			this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
			// 
			// CommandTree
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.Controls.Add(this.ExecuteButton);
			this.Controls.Add(this.Command);
			this.Controls.Add(this.ChannelUserLabel);
			this.Controls.Add(this.ServerChannelLabel);
			this.Controls.Add(this.CommandLabel);
			this.Controls.Add(this.DiscordServerLabel);
			this.Controls.Add(this.ChannelUser);
			this.Controls.Add(this.ServerChannel);
			this.Controls.Add(this.DiscordServer);
			this.MaximumSize = new System.Drawing.Size(674, 390);
			this.Name = "CommandTree";
			this.Size = new System.Drawing.Size(674, 390);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox DiscordServer;
		private System.Windows.Forms.ComboBox ServerChannel;
		private System.Windows.Forms.Label DiscordServerLabel;
		private System.Windows.Forms.Label ServerChannelLabel;
		private System.Windows.Forms.ComboBox ChannelUser;
		private System.Windows.Forms.Label ChannelUserLabel;
		private System.Windows.Forms.TextBox Command;
		private System.Windows.Forms.Label CommandLabel;
		private System.Windows.Forms.Button ExecuteButton;
	}
}
