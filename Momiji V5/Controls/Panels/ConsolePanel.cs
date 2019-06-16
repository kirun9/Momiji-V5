using System;
using CefSharp.WinForms;

namespace Momiji.Bot.V5.Core.Controls.Panels
{
	public partial class ConsolePanel : System.Windows.Forms.UserControl
	{
		ChromiumWebBrowser browser;
		public ConsolePanel()
		{
			InitializeComponent();
			browser = new ChromiumWebBrowser(@"http://localhost:12369/main.html");
			browser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Controls.Add(browser);
		}
	}
}
