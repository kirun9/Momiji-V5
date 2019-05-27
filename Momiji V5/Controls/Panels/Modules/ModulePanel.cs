using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core.Controls.Panels.Modules
{
	public partial class ModulePanel : UserControl
	{
		public ModulePanel()
		{
			InitializeComponent();
			moduleItem1.PSetModuleStatusText("Disabled", Color.Black);
			moduleItem2.PSetModuleStatusText("Enabled", Color.DarkGreen);
			moduleItem3.PSetModuleStatusText("Error", Color.DarkRed);
			moduleItem4.PSetModuleStatusText("Warning", Color.Yellow);
		}
	}
}
