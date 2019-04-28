namespace Momiji.Bot.V5.Core.Controls.Installer
{
	partial class Welcome_Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome_Form));
			this.TitleLabel = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.MomijiIcon = new Momiji.Bot.V5.Core.Controls.CircularPictureBox();
			((System.ComponentModel.ISupportInitialize)(this.MomijiIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// TitleLabel
			// 
			this.TitleLabel.Font = new System.Drawing.Font("Special Elite", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.TitleLabel.Location = new System.Drawing.Point(65, 79);
			this.TitleLabel.Name = "TitleLabel";
			this.TitleLabel.Size = new System.Drawing.Size(170, 54);
			this.TitleLabel.TabIndex = 2;
			this.TitleLabel.Text = "Momiji V5";
			this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Special Elite", 18.75F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.label1.Location = new System.Drawing.Point(12, 133);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(276, 61);
			this.label1.TabIndex = 2;
			this.label1.Text = "Configure Project?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Special Elite", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.button1.Location = new System.Drawing.Point(66, 226);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(168, 58);
			this.button1.TabIndex = 3;
			this.button1.Text = "Yes";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Special Elite", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.button2.Location = new System.Drawing.Point(66, 290);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(168, 58);
			this.button2.TabIndex = 3;
			this.button2.Text = "No";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// MomijiIcon
			// 
			this.MomijiIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.MomijiIcon.Image = global::Momiji.Bot.V5.Core.Properties.Resources.MomijiIcon;
			this.MomijiIcon.Location = new System.Drawing.Point(120, 14);
			this.MomijiIcon.Margin = new System.Windows.Forms.Padding(5);
			this.MomijiIcon.Name = "MomijiIcon";
			this.MomijiIcon.Size = new System.Drawing.Size(60, 60);
			this.MomijiIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.MomijiIcon.TabIndex = 1;
			this.MomijiIcon.TabStop = false;
			// 
			// Welcome_Form
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.ClientSize = new System.Drawing.Size(300, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TitleLabel);
			this.Controls.Add(this.MomijiIcon);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(300, 450);
			this.Name = "Welcome_Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Welcome_Form";
			((System.ComponentModel.ISupportInitialize)(this.MomijiIcon)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private CircularPictureBox MomijiIcon;
		private System.Windows.Forms.Label TitleLabel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}