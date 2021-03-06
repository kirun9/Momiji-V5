﻿using CefSharp;
using CefSharp.WinForms;
using Momiji.Bot.V5.Core.Controls.Panels;
using Momiji.Bot.V5.Core.Controls.Panels.Modules;
using Momiji.Bot.V5.Core.Controls.Panels.RunCommand;
using Momiji.Bot.V5.Core.Controls.Panels.Settings;
using Momiji.Bot.V5.Modules;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core
{
	public partial class MainForm : Form
	{
		private ConsolePanel consolePanel;
		private ModulePanel modulePanel;
		private CommandTree commandTree;

		delegate void DAddModule(MomijiModuleBase module);
		private void PAddModule(MomijiModuleBase module)
		{
			modulePanel.AddModule(module);
			modulePanel.Invalidate();
		}

		public MainForm()
		{
			InitializeComponent();
#if DEBUG
			this.WindowState = FormWindowState.Normal;
#else
			//this.WindowState = FormWindowStete.Maximized;
			this.WindowState = FormWindowState.Normal;
#endif
			Cef.Initialize(new CefSettings());

			consolePanel = new ConsolePanel();
			consolePanel.Top = 3;
			consolePanel.Left = 3;

			modulePanel = new ModulePanel();
			modulePanel.Top = 3;
			modulePanel.Left = 3;
			modulePanel.Show();

			commandTree = new CommandTree();
			commandTree.Top = 3;
			commandTree.Left = 3;
			commandTree.Show();
			
			MainPanel.Controls.Add(consolePanel);
		}

		#region Move Window ...
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

		private async void ExitButton_Click(Object sender, EventArgs e)
		{
			Console.Log("Main Thread", "Closing operation was requested by administrator", InternalServer.ConsoleMessageType.Attention);
			if (Discord.DiscordInitializer.Instance.DiscordSocketClient.ConnectionState == global::Discord.ConnectionState.Connected ||
				Discord.DiscordInitializer.Instance.DiscordSocketClient.ConnectionState == global::Discord.ConnectionState.Connecting)
			{
				await Discord.DiscordInitializer.DisconnectDiscord();
				
			}
			Console.Log("Main Thread", "Closing operation completed", InternalServer.ConsoleMessageType.Attention);
			InternalServer.Server.ShutdownServer();
			Cef.Shutdown();
			await Config.Settings.SaveConfig();
			MomijiHeart.Stop();
			Environment.ExitCode = 0;
			Application.Exit();
		}

		private void MinimizeButton_Click(Object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		internal void ChangeToConsole()
		{
			ConsoleButton.PerformClick();
		}

		private void ConsoleButton_MouseClick(Object sender, MouseEventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(consolePanel);
		}
		
		private void ModulesButton_MouseClick(Object sender, MouseEventArgs e)
		{
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(modulePanel);
		}

		private void MainForm_Load(Object sedner, EventArgs e)
		{
			Thread thread = new Thread(t =>
			{
				MomijiHeart.Run();
			});
			thread.Start();
		}

		private void SettingsButton_MouseClick(Object sender, MouseEventArgs e)
		{
			Settings settings = new Settings();
			settings.Top = 3;
			settings.Left = 3;
			settings.Show();
			MainPanel.Controls.Clear();
			MainPanel.Controls.Add(settings);
		}

		private void RunCommandButton_MouseClick(Object sender, MouseEventArgs e)
		{
			MainPanel.Controls.Clear();
			commandTree.FillDiscordServers();
			MainPanel.Controls.Add(commandTree);
		}

		internal void AddModule(MomijiModuleBase module)
		{
			if (InvokeRequired)
				Invoke(new DAddModule(PAddModule), module);
			else
				PAddModule(module);
		}
	}
}
