using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Momiji.Bot.V5.Modules;
using Momiji.Bot.V5.Modules.Interface;

namespace Momiji.Bot.V5.Core.Controls.Panels.Modules
{
	public partial class ModuleItem : UserControl
	{
		private MomijiModuleBase module;
		private delegate void DModuleState(ModuleState state);
		internal void PSetModuleState(ModuleState state)
		{
			var tuple = ParseModuleState(state);
			ModuleStatusLabel.Text = tuple.Item1;
			ModuleStatusLabel.ForeColor = tuple.Item2;
			PSetMenuStripAction(state);
			Invalidate();
		}
		internal void PSetMenuStripAction(ModuleState state)
		{
			if (state == ModuleState.Enabled)
			{
				enableToolStripMenuItem.Text = "Disable";
			}
			else if (state.HasFlag(ModuleState.DisableModule))
			{
				enableToolStripMenuItem.Text = "Enable";
			}
			Invalidate();
		}

		public ModuleItem()
		{
			InitializeComponent();
		}

		public ModuleItem(MomijiModuleBase module)
		{
			InitializeComponent();
			this.module = module;
			ModuleNameLabel.Text = module.ModuleName;
			module.ModuleStateEvent += OnModuleStateChanged;
			PSetMenuStripAction(module.ModuleState);
			SetModuleState(module.ModuleState);

			if (module is IConfig configModule)
			{
				toolStripSeparator1.Visible = true;
				configToolStripMenuItem.Visible = true;
				filesToolStripMenuItem.Visible = true;
				openConfigFolderToolStripMenuItem.Visible = true;
				cLoadToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						configModule.LoadConfig();
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
				cSaveToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						configModule.SaveConfig();
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
				openConfigFolderToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						string dir = new FileInfo(configModule.ConfigPath()).Directory.FullName;
						System.Diagnostics.Process.Start(dir);
					}
					catch (Exception ex)
					{
						Log(ex.ToString(), InternalServer.ConsoleMessageType.Warning);
					}
				};
			}
			if (module is IExternalResources resources)
			{
				toolStripSeparator1.Visible = true;
				resourcesToolStripMenuItem.Visible = true;
				filesToolStripMenuItem.Visible = true;
				openResourceFolderToolStripMenuItem.Visible = true;
				rLoadToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						resources.LoadResources();
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
				rSaveToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						resources.SaveResources();
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
				rResaveToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						resources.ResaveResources();
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
				rReloadToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						resources.ReloadResources();
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
				openResourceFolderToolStripMenuItem.Click += (sender, e) =>
				{
					try
					{
						System.Diagnostics.Process.Start(new FileInfo(resources.ResourcePath()).Directory.FullName);
					}
					catch (Exception ex)
					{
						Log(ex);
					}
				};
			}
			if (module is ICustomToolStrip toolStrip)
			{
				var menu = toolStrip.GetCustomMenuItem();
				menu.MergeAction = MergeAction.Insert;
				menuStrip.Items.Add(menu);
			}
		}

		internal void SetModuleState(ModuleState state)
		{
			if (InvokeRequired)
				Invoke(new DModuleState(PSetModuleState), state);
			else
				PSetModuleState(state);
		}

		private void OnModuleStateChanged(MomijiModuleBase sender, ModuleStateChangedArgs args) => SetModuleState(args.NewState);

		private Tuple<string, Color> ParseModuleState(ModuleState state) // ModuleStateFlags wszędzie?
		{
			switch (state)
			{
				case ModuleState.Disabled:
				{
					return Tuple.Create("Disabled", Color.Black);
				}
				case ModuleState.Enabled:
				{
					return Tuple.Create("Enabled", Color.DarkGreen);
				}
				case ModuleState.Error:
				{
					return Tuple.Create("Error", Color.DarkRed);
				}
				case ModuleState.Warning:
				{
					return Tuple.Create("Warning", Color.Yellow);
				}
				default:
				{
					return Tuple.Create(Single.NaN + "", Color.White);
				}
			}
		}

		private void moreButton_Click(Object sender, EventArgs e)
		{
			menuStrip.Show(moreButton, new Point((int) moreButton.Size.Width / 2, (int) moreButton.Size.Height / 2));
		}

		private void Log(Exception ex) => Log(ex.ToString(), InternalServer.ConsoleMessageType.Warning);
		private void Log(string message, InternalServer.ConsoleMessageType consoleMessageType = InternalServer.ConsoleMessageType.Info)
		{
			Console.Log("Module List", message, consoleMessageType);
		}

		private void enableToolStripMenuItem_Click(Object sender, EventArgs e)
		{
			if (module.ModuleState == ModuleState.Enabled || module.ModuleState == ModuleState.Error || module.ModuleState == ModuleState.Warning)
			{
				module.ModuleState = ModuleState.Disabled;
				ModuleLoader.DisableModule(module);
			}
			else if (module.ModuleState == ModuleState.Disabled)
			{
				module.ModuleState = ModuleState.Enabled;
				ModuleLoader.EnableModule(module);
			}
		}
	}
}
