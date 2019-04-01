using System;

namespace Momiji.Bot.V5.Core.Controls.Panels
{
	public partial class ConsolePanel : System.Windows.Forms.UserControl
	{
		string logText;
		private readonly string ending = "</table></body></html>";

		public ConsolePanel()
		{
			InitializeComponent();
			logText = Program.ReadHtmlConsoleHeader();
			
			
			browser.Navigate(new Uri(@"http://localhost:12369/main.html"));
		}

		public void Append(string date, string moduleName, string message, ConsoleMessageType messageType = ConsoleMessageType.Info)
		{
			/*var colors = ParseColors(messageType);
			message = message.Trim();
			message = message.PreventInjection();
			message = message.Replace("\n", "<br />\n");

			if (messageType == ConsoleMessageType.Warning || messageType == ConsoleMessageType.Error)
			{
				logText += $"<tr><td class=\"row1{(colors.Item1 != "" ? " " + colors.Item1 : "")}\">{date}</td><td class=\"row2{(colors.Item2 != "" ? " " + colors.Item2 : "")}\">{moduleName}</td><td class=\"row3{(colors.Item3 != "" ? " " + colors.Item3 : "")}\">Caught Exception:</td></tr>\n";
				logText += $"<tr><td class=\"multirow{(colors.Item3 != "" ? " " + colors.Item3 : "")}\" colspan=3>{message}</td></tr>\n";
			}
			else
			{
				logText += $"<tr><td class=\"row1{(colors.Item1 != "" ? " " + colors.Item1 : "")}\">{date}</td><td class=\"row2{(colors.Item2 != "" ? " " + colors.Item2 : "")}\">{moduleName}</td><td class=\"row3{(colors.Item3 != "" ? " " + colors.Item3 : "")}\">{message}</td></tr>\n";
			}
			browser.DocumentText = logText + ending;
			System.IO.File.WriteAllText("C:\\Users\\Krystian\\Desktop\\output.html", logText + ending);*/
		}

		public void UpdateBrowser()
		{
			//browser.Invalidate();
		}

		public string getText() => browser.DocumentText;
		
		public Tuple<string, string, string> ParseColors(ConsoleMessageType type)
		{
			switch (type)
			{
				case ConsoleMessageType.Error:		return Tuple.Create("error", "error", "error");
				case ConsoleMessageType.Warning:	return Tuple.Create("warning", "warning", "warning");
				case ConsoleMessageType.User:		return Tuple.Create("", "user", "user");
				case ConsoleMessageType.Info:		return Tuple.Create("", "", "");
				case ConsoleMessageType.Module:		return Tuple.Create("", "module", "module");
				default:							return Tuple.Create("warning", "warning", "warning");
			}
		}
	}
	public enum ConsoleMessageType
	{
		Error, Warning, User, Info, Module
	}
}
