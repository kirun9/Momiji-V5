namespace Momiji.Bot.V5.Core.Controls.Panels.Modules
{
	partial class ModuleItem
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
			this.components = new System.ComponentModel.Container();
			this.borderPanel1 = new kirun9.WinForms.Controls.BorderPanel();
			this.moreButton = new System.Windows.Forms.Button();
			this.ModuleStatusLabel = new System.Windows.Forms.Label();
			this.ModuleNameLabel = new System.Windows.Forms.Label();
			this.menuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.resourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rResaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openConfigFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openResourceFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.borderPanel1.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// borderPanel1
			// 
			this.borderPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.borderPanel1.BorderPadding = new System.Windows.Forms.Padding(0);
			this.borderPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.borderPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.borderPanel1.Controls.Add(this.moreButton);
			this.borderPanel1.Controls.Add(this.ModuleStatusLabel);
			this.borderPanel1.Controls.Add(this.ModuleNameLabel);
			this.borderPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.borderPanel1.Font = new System.Drawing.Font("Monospac821 BT", 12F, System.Drawing.FontStyle.Bold);
			this.borderPanel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.borderPanel1.Location = new System.Drawing.Point(0, 0);
			this.borderPanel1.Name = "borderPanel1";
			this.borderPanel1.Padding = new System.Windows.Forms.Padding(2);
			this.borderPanel1.PenWidth = 1F;
			this.borderPanel1.Size = new System.Drawing.Size(650, 23);
			this.borderPanel1.TabIndex = 0;
			// 
			// moreButton
			// 
			this.moreButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.moreButton.Dock = System.Windows.Forms.DockStyle.Right;
			this.moreButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.moreButton.FlatAppearance.BorderSize = 3;
			this.moreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.moreButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.moreButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.moreButton.Font = new System.Drawing.Font("Monospac821 BT", 15F, System.Drawing.FontStyle.Bold);
			this.moreButton.Location = new System.Drawing.Point(586, 2);
			this.moreButton.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
			this.moreButton.Name = "moreButton";
			this.moreButton.Size = new System.Drawing.Size(62, 19);
			this.moreButton.TabIndex = 2;
			this.moreButton.Text = "•••";
			this.moreButton.UseCompatibleTextRendering = true;
			this.moreButton.UseVisualStyleBackColor = false;
			this.moreButton.Click += new System.EventHandler(this.moreButton_Click);
			// 
			// ModuleStatusLabel
			// 
			this.ModuleStatusLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.ModuleStatusLabel.ForeColor = System.Drawing.Color.DarkGreen;
			this.ModuleStatusLabel.Location = new System.Drawing.Point(296, 2);
			this.ModuleStatusLabel.Name = "ModuleStatusLabel";
			this.ModuleStatusLabel.Size = new System.Drawing.Size(112, 19);
			this.ModuleStatusLabel.TabIndex = 1;
			this.ModuleStatusLabel.Text = "label2";
			// 
			// ModuleNameLabel
			// 
			this.ModuleNameLabel.AutoEllipsis = true;
			this.ModuleNameLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.ModuleNameLabel.Location = new System.Drawing.Point(2, 2);
			this.ModuleNameLabel.Name = "ModuleNameLabel";
			this.ModuleNameLabel.Size = new System.Drawing.Size(294, 19);
			this.ModuleNameLabel.TabIndex = 0;
			this.ModuleNameLabel.Text = "Module Name Goes Here";
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.toolStripSeparator1,
            this.resourcesToolStripMenuItem,
            this.configToolStripMenuItem,
            this.filesToolStripMenuItem,
            this.toolStripSeparator2});
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(128, 104);
			// 
			// enableToolStripMenuItem
			// 
			this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
			this.enableToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.enableToolStripMenuItem.Text = "Enable";
			this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(124, 6);
			this.toolStripSeparator1.Visible = false;
			// 
			// resourcesToolStripMenuItem
			// 
			this.resourcesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rLoadToolStripMenuItem,
            this.rSaveToolStripMenuItem,
            this.rReloadToolStripMenuItem,
            this.rResaveToolStripMenuItem});
			this.resourcesToolStripMenuItem.Name = "resourcesToolStripMenuItem";
			this.resourcesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.resourcesToolStripMenuItem.Text = "Resources";
			this.resourcesToolStripMenuItem.Visible = false;
			// 
			// rLoadToolStripMenuItem
			// 
			this.rLoadToolStripMenuItem.Name = "rLoadToolStripMenuItem";
			this.rLoadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.rLoadToolStripMenuItem.Text = "Load";
			// 
			// rSaveToolStripMenuItem
			// 
			this.rSaveToolStripMenuItem.Name = "rSaveToolStripMenuItem";
			this.rSaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.rSaveToolStripMenuItem.Text = "Save";
			// 
			// rReloadToolStripMenuItem
			// 
			this.rReloadToolStripMenuItem.Name = "rReloadToolStripMenuItem";
			this.rReloadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.rReloadToolStripMenuItem.Text = "Reload";
			// 
			// rResaveToolStripMenuItem
			// 
			this.rResaveToolStripMenuItem.Name = "rResaveToolStripMenuItem";
			this.rResaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.rResaveToolStripMenuItem.Text = "Resave";
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLoadToolStripMenuItem,
            this.cSaveToolStripMenuItem});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.configToolStripMenuItem.Text = "Config";
			this.configToolStripMenuItem.Visible = false;
			// 
			// cLoadToolStripMenuItem
			// 
			this.cLoadToolStripMenuItem.Name = "cLoadToolStripMenuItem";
			this.cLoadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cLoadToolStripMenuItem.Text = "Load";
			// 
			// cSaveToolStripMenuItem
			// 
			this.cSaveToolStripMenuItem.Name = "cSaveToolStripMenuItem";
			this.cSaveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.cSaveToolStripMenuItem.Text = "Save";
			// 
			// filesToolStripMenuItem
			// 
			this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConfigFolderToolStripMenuItem,
            this.openResourceFolderToolStripMenuItem});
			this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
			this.filesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.filesToolStripMenuItem.Text = "Files";
			this.filesToolStripMenuItem.Visible = false;
			// 
			// openConfigFolderToolStripMenuItem
			// 
			this.openConfigFolderToolStripMenuItem.Name = "openConfigFolderToolStripMenuItem";
			this.openConfigFolderToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.openConfigFolderToolStripMenuItem.Text = "Open Config Folder";
			this.openConfigFolderToolStripMenuItem.Visible = false;
			// 
			// openResourceFolderToolStripMenuItem
			// 
			this.openResourceFolderToolStripMenuItem.Name = "openResourceFolderToolStripMenuItem";
			this.openResourceFolderToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
			this.openResourceFolderToolStripMenuItem.Text = "Open Resource Folder";
			this.openResourceFolderToolStripMenuItem.Visible = false;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(124, 6);
			this.toolStripSeparator2.Visible = false;
			// 
			// ModuleItem
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.Controls.Add(this.borderPanel1);
			this.MaximumSize = new System.Drawing.Size(650, 23);
			this.MinimumSize = new System.Drawing.Size(650, 23);
			this.Name = "ModuleItem";
			this.Size = new System.Drawing.Size(650, 23);
			this.borderPanel1.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private kirun9.WinForms.Controls.BorderPanel borderPanel1;
		private System.Windows.Forms.Button moreButton;
		private System.Windows.Forms.Label ModuleStatusLabel;
		private System.Windows.Forms.Label ModuleNameLabel;
		private System.Windows.Forms.ContextMenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem resourcesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rReloadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rResaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cLoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cSaveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openConfigFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openResourceFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}
