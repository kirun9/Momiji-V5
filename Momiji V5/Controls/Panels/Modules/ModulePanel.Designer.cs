namespace Momiji.Bot.V5.Core.Controls.Panels.Modules
{
	partial class ModulePanel
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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.moduleItem1 = new Momiji.Bot.V5.Core.Controls.Panels.Modules.ModuleItem();
			this.moduleItem2 = new Momiji.Bot.V5.Core.Controls.Panels.Modules.ModuleItem();
			this.moduleItem3 = new Momiji.Bot.V5.Core.Controls.Panels.Modules.ModuleItem();
			this.moduleItem4 = new Momiji.Bot.V5.Core.Controls.Panels.Modules.ModuleItem();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.moduleItem1);
			this.flowLayoutPanel1.Controls.Add(this.moduleItem2);
			this.flowLayoutPanel1.Controls.Add(this.moduleItem3);
			this.flowLayoutPanel1.Controls.Add(this.moduleItem4);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(674, 390);
			this.flowLayoutPanel1.TabIndex = 0;
			this.flowLayoutPanel1.WrapContents = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Monospac821 BT", 14F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(3, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
			this.label1.Size = new System.Drawing.Size(650, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Module List";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// moduleItem1
			// 
			this.moduleItem1.Location = new System.Drawing.Point(3, 26);
			this.moduleItem1.MaximumSize = new System.Drawing.Size(650, 23);
			this.moduleItem1.MinimumSize = new System.Drawing.Size(650, 23);
			this.moduleItem1.Name = "moduleItem1";
			this.moduleItem1.Size = new System.Drawing.Size(650, 23);
			this.moduleItem1.TabIndex = 1;
			// 
			// moduleItem2
			// 
			this.moduleItem2.Location = new System.Drawing.Point(3, 55);
			this.moduleItem2.MaximumSize = new System.Drawing.Size(650, 23);
			this.moduleItem2.MinimumSize = new System.Drawing.Size(650, 23);
			this.moduleItem2.Name = "moduleItem2";
			this.moduleItem2.Size = new System.Drawing.Size(650, 23);
			this.moduleItem2.TabIndex = 2;
			// 
			// moduleItem3
			// 
			this.moduleItem3.Location = new System.Drawing.Point(3, 84);
			this.moduleItem3.MaximumSize = new System.Drawing.Size(650, 23);
			this.moduleItem3.MinimumSize = new System.Drawing.Size(650, 23);
			this.moduleItem3.Name = "moduleItem3";
			this.moduleItem3.Size = new System.Drawing.Size(650, 23);
			this.moduleItem3.TabIndex = 3;
			// 
			// moduleItem4
			// 
			this.moduleItem4.Location = new System.Drawing.Point(3, 113);
			this.moduleItem4.MaximumSize = new System.Drawing.Size(650, 23);
			this.moduleItem4.MinimumSize = new System.Drawing.Size(650, 23);
			this.moduleItem4.Name = "moduleItem4";
			this.moduleItem4.Size = new System.Drawing.Size(650, 23);
			this.moduleItem4.TabIndex = 4;
			// 
			// ModulePanel
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.Controls.Add(this.flowLayoutPanel1);
			this.Font = new System.Drawing.Font("Monospac821 BT", 9.5F, System.Drawing.FontStyle.Bold);
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.MaximumSize = new System.Drawing.Size(674, 390);
			this.Name = "ModulePanel";
			this.Size = new System.Drawing.Size(674, 390);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private ModuleItem moduleItem1;
		private ModuleItem moduleItem2;
		private ModuleItem moduleItem3;
		private ModuleItem moduleItem4;
	}
}
