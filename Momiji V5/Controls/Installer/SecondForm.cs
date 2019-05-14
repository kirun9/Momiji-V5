using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core.Controls.Installer
{
	public partial class SecondForm : Form
	{
		private bool botTokenTextBoxClicked = false;
		public SecondForm()
		{
			InitializeComponent();
		}

		private void button1_Click(Object sender, EventArgs e)
		{
			if (BotTokenTextBox.Text.Length == 59)
			{
				BotKeyReader.SaveKey(BotTokenTextBox.Text);
				Program.ChangeForm(new MainForm());
			}
		}

		private void button2_Click(Object sender, EventArgs e)
		{
			InternalServer.Server.ShutdownServer();
			Environment.ExitCode = 0;
			Application.Exit();
		}

		private void BotTokenTextBox_TextChanged(Object sender, EventArgs e)
		{
			if (BotTokenTextBox.Text.Length != 59)
			{
				DisplayBotTokenError("This is not a bot token.");
			}
			else
			{
				HideBotTokenError();
			}
		}

		private void BotTokenTextBox_Click(Object sender, EventArgs e)
		{
			if (!botTokenTextBoxClicked)
			{
				BotTokenTextBox.Text = "";
				botTokenTextBoxClicked = true;
			}
		}

		private void DisplayBotTokenError(string text)
		{
			label3.Text = text;
			label3.Visible = true;
			panel1.BackColor = Color.DarkRed;
			panel1.Size = new Size(panel1.Size.Width, 1);
		}

		private void HideBotTokenError()
		{
			label3.Visible = false;
			panel1.BackColor = Color.FromArgb(70, 98, 137);
			panel1.Size = new Size(panel1.Size.Width, 2);
		}

	}
}
