namespace Momiji.Bot.V5.Core.Controls
{
	partial class TabButton
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
			this.ButtonMark = new System.Windows.Forms.Panel();
			this.ButtonLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// ButtonMark
			// 
			this.ButtonMark.Dock = System.Windows.Forms.DockStyle.Left;
			this.ButtonMark.Location = new System.Drawing.Point(0, 0);
			this.ButtonMark.Name = "ButtonMark";
			this.ButtonMark.Size = new System.Drawing.Size(10, 50);
			this.ButtonMark.TabIndex = 0;
			this.ButtonMark.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabButton_MouseClick);
			// 
			// ButtonLabel
			// 
			this.ButtonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ButtonLabel.Font = new System.Drawing.Font("Special Elite", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ButtonLabel.Location = new System.Drawing.Point(10, 0);
			this.ButtonLabel.Name = "ButtonLabel";
			this.ButtonLabel.Size = new System.Drawing.Size(134, 50);
			this.ButtonLabel.TabIndex = 1;
			this.ButtonLabel.Text = "Text";
			this.ButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButtonLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabButton_MouseClick);
			// 
			// TabButton
			// 
			this.Controls.Add(this.ButtonLabel);
			this.Controls.Add(this.ButtonMark);
			this.Name = "TabButton";
			this.Size = new System.Drawing.Size(144, 50);
			this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TabButton_MouseClick);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel ButtonMark;
		private System.Windows.Forms.Label ButtonLabel;
	}
}
