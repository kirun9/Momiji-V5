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
	public partial class FirstForm : Form
	{
		public FirstForm()
		{
			InitializeComponent();
		}

		private void button1_Click(Object sender, EventArgs e)
		{
			Program.ChangeForm(new SecondForm());
		}

		private void button2_Click(Object sender, EventArgs e)
		{
			InternalServer.Server.ShutdownServer();
			Environment.ExitCode = 0;
			Application.Exit();
		}
	}
}
