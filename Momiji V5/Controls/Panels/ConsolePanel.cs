using System;

namespace Momiji.Bot.V5.Core.Controls.Panels
{
	public partial class ConsolePanel : System.Windows.Forms.UserControl
	{
		public ConsolePanel()
		{
			InitializeComponent();
			browser.Navigate(new Uri(@"http://localhost:12369/main.html"));
		}
	}
}
