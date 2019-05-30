using System.Drawing;
using System.Windows.Forms;
using Momiji.Bot.V5.Modules;

namespace Momiji.Bot.V5.Core.Controls.Panels.Modules
{
	public partial class ModuleItem : UserControl
	{
		private MomijiModuleBase module;
		private delegate void DSetText(string text, Color color);
		internal void PSetModuleStatusText(string text, Color color)
		{
			ModuleStatusLabel.ForeColor = color;
			ModuleStatusLabel.Text = text;
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
		}

		internal void UpdateModuleState(ModuleState state)
		{
			switch (state)
			{
				case ModuleState.Disabled:
				{
					Invoke(new DSetText(PSetModuleStatusText), "Disabled", Color.Black);
					break;
				}
				case ModuleState.Enabled:
				{
					Invoke(new DSetText(PSetModuleStatusText), "Enabled", Color.DarkGreen);
					break;
				}
				case ModuleState.Error:
				{
					Invoke(new DSetText(PSetModuleStatusText), "Error", Color.DarkRed);
					break;
				}
				case ModuleState.Warning:
				{
					Invoke(new DSetText(PSetModuleStatusText), "Warning", Color.Yellow);
					break;
				}
			}
		}
	}
}
