using System;
using System.Drawing;
using System.Windows.Forms;
using Momiji.Bot.V5.Modules;

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
			SetModuleState(module.ModuleState);
		}

		internal void SetModuleState(ModuleState state)
		{
			if (InvokeRequired)
				Invoke(new DModuleState(PSetModuleState), state);
			else
				PSetModuleState(state);
		}

		private void OnModuleStateChanged(MomijiModuleBase sender, ModuleStateChangedArgs args) => SetModuleState(args.NewState);

		private Tuple<string, Color> ParseModuleState(ModuleState state)
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
	}
}
