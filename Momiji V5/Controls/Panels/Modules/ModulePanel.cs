using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Momiji.Bot.V5.Modules;

namespace Momiji.Bot.V5.Core.Controls.Panels.Modules
{
	public partial class ModulePanel : UserControl
	{
		List<Control> Modules = new List<Control>();

		public ModulePanel()
		{
			InitializeComponent();
		}

		public void AddModule(MomijiModuleBase module)
		{
			Control control;
			if (module is ICustomModuleItem customModule)
			{
				control = customModule.CustomControl;
				control.MaximumSize = new Size(label1.Width, 23 * (customModule.TwoRowModuleItem ? 2 : 1));
			}
			else
			{
				control = new ModuleItem(module);
			}
			control.Dock = DockStyle.Top;
			// TODO Module dropdown menu
			// TODO Custom dropdown menu
			Modules.Add(control);
			label1.Text = "Module List (" + Modules.Count + " module" + (Modules.Count == 1 ? "" : "s") + ")";
			flowLayoutPanel1.Controls.Add(control);
			control.Show();
			Invalidate();
		}
	}
}
