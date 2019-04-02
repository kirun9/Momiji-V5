using System;
using System.Drawing;
using System.Windows.Forms;
using Momiji.Bot.V5.Core.Controls.Panels;

namespace Momiji.Bot.V5.Core
{
	public partial class MainForm : Form
	{
		private ConsolePanel consolePanel;
		public MainForm()
		{
			InitializeComponent();
#if DEBUG
			this.WindowState = FormWindowState.Normal;
#else
			this.WindowState = FormWindowStete.Maximized;
#endif
			InternalServer.Server server = new InternalServer.Server();
			server.Start();

			consolePanel = new ConsolePanel();
			consolePanel.Top = 3;
			consolePanel.Left = 3;


			MainPanel.Controls.Add(consolePanel);
		}

		#region MoveWindow
		private bool _mouseLeftDown = false;
		private Point _lastMouseLocation;
		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_mouseLeftDown = true;
				_lastMouseLocation = e.Location;
			}
		}

		private void MainForm_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				_mouseLeftDown = false;
			}
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (_mouseLeftDown)
			{
				SetDesktopLocation(this.Location.X - _lastMouseLocation.X + e.X, this.Location.Y - _lastMouseLocation.Y + e.Y);
			}
		}

		private void MainForm_MouseCaptureChanged(object sender, EventArgs e)
		{
			_mouseLeftDown = false;
		}
		#endregion

		private void ExitButton_Click(Object sender, EventArgs e)
		{
#warning Temporarily
			Application.Exit();
			Environment.Exit(0);
		}

		private void MinimizeButton_Click(Object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void ConsoleButton_MouseClick(Object sender, MouseEventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(consolePanel);
		}

		private void ModulesButton_MouseClick(Object sender, MouseEventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("Clicked");
		}
	}
}
