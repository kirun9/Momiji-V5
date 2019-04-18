namespace Momiji.Bot.V5.Core
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
			this.TopPanel = new System.Windows.Forms.Panel();
			this.TitleLabel = new System.Windows.Forms.Label();
			this.MinimizeButton = new System.Windows.Forms.Button();
			this.ExitButton = new System.Windows.Forms.Button();
			this.TabsPanel = new System.Windows.Forms.Panel();
			this.TabButtons = new System.Windows.Forms.FlowLayoutPanel();
			this.ConsoleButton = new Momiji.Bot.V5.Core.Controls.TabButton();
			this.ModulesButton = new Momiji.Bot.V5.Core.Controls.TabButton();
			this.MomijiIcon = new Momiji.Bot.V5.Core.Controls.CircularPictureBox();
			this.MainPanel = new System.Windows.Forms.Panel();
			this.TopPanel.SuspendLayout();
			this.TabsPanel.SuspendLayout();
			this.TabButtons.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MomijiIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// TopPanel
			// 
			this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.TopPanel.Controls.Add(this.TitleLabel);
			this.TopPanel.Controls.Add(this.MinimizeButton);
			this.TopPanel.Controls.Add(this.ExitButton);
			this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TopPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.TopPanel.Location = new System.Drawing.Point(150, 0);
			this.TopPanel.Name = "TopPanel";
			this.TopPanel.Size = new System.Drawing.Size(680, 54);
			this.TopPanel.TabIndex = 0;
			this.TopPanel.MouseCaptureChanged += new System.EventHandler(this.MainForm_MouseCaptureChanged);
			this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
			this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
			this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
			// 
			// TitleLabel
			// 
			this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TitleLabel.Font = new System.Drawing.Font("Special Elite", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleLabel.Location = new System.Drawing.Point(0, 0);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(572, 54);
			this.TitleLabel.TabIndex = 0;
			this.TitleLabel.Text = "Momiji V5";
			this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.TitleLabel.MouseCaptureChanged += new System.EventHandler(this.MainForm_MouseCaptureChanged);
			this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
			this.TitleLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
			this.TitleLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
			// 
			// MinimizeButton
			// 
			this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.MinimizeButton.FlatAppearance.BorderSize = 0;
			this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.MinimizeButton.Font = new System.Drawing.Font("Special Elite", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MinimizeButton.Location = new System.Drawing.Point(572, 0);
			this.MinimizeButton.Name = "MinimizeButton";
			this.MinimizeButton.Size = new System.Drawing.Size(54, 54);
			this.MinimizeButton.TabIndex = 2;
			this.MinimizeButton.Text = "_";
			this.MinimizeButton.UseVisualStyleBackColor = false;
			this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
			// 
			// ExitButton
			// 
			this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.ExitButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.ExitButton.FlatAppearance.BorderSize = 0;
			this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ExitButton.Font = new System.Drawing.Font("Special Elite", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ExitButton.ForeColor = System.Drawing.Color.Red;
			this.ExitButton.Location = new System.Drawing.Point(626, 0);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new System.Drawing.Size(54, 54);
			this.ExitButton.TabIndex = 1;
			this.ExitButton.Text = "X";
			this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ExitButton.UseVisualStyleBackColor = false;
			this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
			// 
			// TabsPanel
			// 
			this.TabsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.TabsPanel.Controls.Add(this.TabButtons);
			this.TabsPanel.Controls.Add(this.MomijiIcon);
			this.TabsPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.TabsPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.TabsPanel.Location = new System.Drawing.Point(0, 0);
			this.TabsPanel.Name = "TabsPanel";
			this.TabsPanel.Size = new System.Drawing.Size(150, 450);
			this.TabsPanel.TabIndex = 1;
			// 
			// TabButtons
			// 
			this.TabButtons.Controls.Add(this.ConsoleButton);
			this.TabButtons.Controls.Add(this.ModulesButton);
			this.TabButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TabButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.TabButtons.Location = new System.Drawing.Point(0, 70);
			this.TabButtons.Margin = new System.Windows.Forms.Padding(0);
			this.TabButtons.Name = "TabButtons";
			this.TabButtons.Size = new System.Drawing.Size(150, 380);
			this.TabButtons.TabIndex = 1;
			// 
			// ConsoleButton
			// 
			this.ConsoleButton.ButtonText = "Console";
			this.ConsoleButton.Location = new System.Drawing.Point(3, 3);
			this.ConsoleButton.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.ConsoleButton.Name = "ConsoleButton";
			this.ConsoleButton.Selected = true;
			this.ConsoleButton.Size = new System.Drawing.Size(144, 50);
			this.ConsoleButton.TabIndex = 0;
			this.ConsoleButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ConsoleButton_MouseClick);
			// 
			// ModulesButton
			// 
			this.ModulesButton.ButtonText = "Modules";
			this.ModulesButton.Location = new System.Drawing.Point(3, 59);
			this.ModulesButton.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.ModulesButton.Name = "ModulesButton";
			this.ModulesButton.Selected = false;
			this.ModulesButton.Size = new System.Drawing.Size(144, 50);
			this.ModulesButton.TabIndex = 1;
			this.ModulesButton.ButtonClick += new System.Windows.Forms.MouseEventHandler(this.ModulesButton_MouseClick);
			// 
			// MomijiIcon
			// 
			this.MomijiIcon.Image = global::Momiji.Bot.V5.Core.Properties.Resources.MomijiIcon;
			this.MomijiIcon.Location = new System.Drawing.Point(5, 5);
			this.MomijiIcon.Margin = new System.Windows.Forms.Padding(5);
			this.MomijiIcon.Name = "MomijiIcon";
			this.MomijiIcon.Size = new System.Drawing.Size(60, 60);
			this.MomijiIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.MomijiIcon.TabIndex = 0;
			this.MomijiIcon.TabStop = false;
			// 
			// MainPanel
			// 
			this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MainPanel.Location = new System.Drawing.Point(150, 54);
			this.MainPanel.Margin = new System.Windows.Forms.Padding(6);
			this.MainPanel.Name = "MainPanel";
			this.MainPanel.Size = new System.Drawing.Size(680, 396);
			this.MainPanel.TabIndex = 2;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(830, 450);
			this.Controls.Add(this.MainPanel);
			this.Controls.Add(this.TopPanel);
			this.Controls.Add(this.TabsPanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(830, 450);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Momiji";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.TopPanel.ResumeLayout(false);
			this.TabsPanel.ResumeLayout(false);
			this.TabButtons.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MomijiIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel TopPanel;
		private Controls.CircularPictureBox MomijiIcon;
		private System.Windows.Forms.Panel TabsPanel;
		private System.Windows.Forms.Panel MainPanel;
		private System.Windows.Forms.FlowLayoutPanel TabButtons;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Button MinimizeButton;
		private System.Windows.Forms.Button ExitButton;
		private Controls.TabButton ConsoleButton;
		private Controls.TabButton ModulesButton;
	}
}

