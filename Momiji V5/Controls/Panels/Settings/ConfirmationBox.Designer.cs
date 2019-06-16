namespace Momiji.Bot.V5.Core.Controls.Panels.Settings
{
	partial class ConfirmationBox
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.borderPanel1 = new kirun9.WinForms.Controls.BorderPanel();
			this.borderPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.button1.FlatAppearance.BorderSize = 0;
			this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Special Elite", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.button1.Location = new System.Drawing.Point(10, 92);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(170, 40);
			this.button1.TabIndex = 3;
			this.button1.Text = "Yes";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(98)))), ((int)(((byte)(137)))));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
			this.button2.FlatAppearance.BorderSize = 0;
			this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Special Elite", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.button2.Location = new System.Drawing.Point(10, 138);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(170, 40);
			this.button2.TabIndex = 3;
			this.button2.Text = "Later";
			this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button2.UseVisualStyleBackColor = false;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Special Elite", 18.75F, System.Drawing.FontStyle.Bold);
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(232)))), ((int)(((byte)(249)))));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(166, 80);
			this.label1.TabIndex = 2;
			this.label1.Text = "Restart Discord?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// borderPanel1
			// 
			this.borderPanel1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.borderPanel1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(97)))), ((int)(((byte)(33)))));
			this.borderPanel1.Controls.Add(this.label1);
			this.borderPanel1.Controls.Add(this.button2);
			this.borderPanel1.Controls.Add(this.button1);
			this.borderPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.borderPanel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
			this.borderPanel1.Location = new System.Drawing.Point(0, 0);
			this.borderPanel1.Name = "borderPanel1";
			this.borderPanel1.PenWidth = 4F;
			this.borderPanel1.Size = new System.Drawing.Size(190, 190);
			this.borderPanel1.TabIndex = 4;
			// 
			// ConfirmationBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(148)))));
			this.ClientSize = new System.Drawing.Size(190, 190);
			this.Controls.Add(this.borderPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MinimumSize = new System.Drawing.Size(190, 190);
			this.Name = "ConfirmationBox";
			this.Text = "ConfirmationBox";
			this.borderPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private kirun9.WinForms.Controls.BorderPanel borderPanel1;
	}
}