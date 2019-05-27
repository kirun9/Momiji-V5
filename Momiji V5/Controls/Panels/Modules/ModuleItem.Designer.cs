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
			this.borderPanel1 = new kirun9.WinForms.Controls.BorderPanel();
			this.moreButton = new System.Windows.Forms.Button();
			this.ModuleStatusLabel = new System.Windows.Forms.Label();
			this.ModuleNameLabel = new System.Windows.Forms.Label();
			this.borderPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// borderPanel1
			// 
			this.borderPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.borderPanel1.BorderPadding = new System.Windows.Forms.Padding(0, 0, 0, 0);
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
			this.moreButton.Name = "moreButton";
			this.moreButton.Size = new System.Drawing.Size(62, 19);
			this.moreButton.TabIndex = 2;
			this.moreButton.Text = "•••";
			this.moreButton.UseCompatibleTextRendering = true;
			this.moreButton.UseVisualStyleBackColor = false;
			// 
			// ModuleStatusLabel
			// 
			this.ModuleStatusLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.ModuleStatusLabel.ForeColor = System.Drawing.Color.DarkGreen;
			this.ModuleStatusLabel.Location = new System.Drawing.Point(261, 2);
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
			this.ModuleNameLabel.Size = new System.Drawing.Size(259, 19);
			this.ModuleNameLabel.TabIndex = 0;
			this.ModuleNameLabel.Text = "Module Name Goes Here";
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
			this.ResumeLayout(false);

		}

		#endregion

		private kirun9.WinForms.Controls.BorderPanel borderPanel1;
		private System.Windows.Forms.Button moreButton;
		private System.Windows.Forms.Label ModuleStatusLabel;
		private System.Windows.Forms.Label ModuleNameLabel;
	}
}
