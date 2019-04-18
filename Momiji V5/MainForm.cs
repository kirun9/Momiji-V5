using CefSharp;
using CefSharp.WinForms;
using Momiji.Bot.V5.Core.Controls.Panels;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

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
			Cef.Initialize(new CefSettings());

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
			Cef.Shutdown();
			InternalServer.Server.ShutdownServer();
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
			
		}

		private void MainForm_Load(Object sedner, EventArgs e)
		{
			Thread thread = new Thread(t =>
			{
				MomijiHeart.Run();
			});
			thread.Start();
		}
	}
}
