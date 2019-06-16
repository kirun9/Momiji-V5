using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core.InternalServer
{
	public class LogMessage
	{
		public string Message { get; private set; }
		public DateTime Date { get; private set; }
		public string ModuleName { get; private set; }
		public ConsoleMessageType MessageType { get; private set; }
    
		public LogMessage(DateTime date, string moduleName, string message, ConsoleMessageType messageType = ConsoleMessageType.Info)
		{
			Message = message;
			Date = date;
			ModuleName = moduleName;
			MessageType = messageType;
		}

		public override string ToString()
		{
			var colors = ParseColors(MessageType);
			var m = Message?.Trim() ?? "";
			m = m.PreventInjection();
			m = m.Replace("\n", "<br />\n");
			string output = "";
			if (MessageType == ConsoleMessageType.Warning || MessageType == ConsoleMessageType.Error)
			{
				output += $"<tr><td class=\"row1{(colors.Item1 != "" ? " " + colors.Item1 : "")}\"><abbr title=\"{Date.ToString("MMM dd, YYYY")}\">{Date.ToString("HH:mm:ss")}</abbr></td><td class=\"row2{(colors.Item2 != "" ? " " + colors.Item2 : "")}\">{ModuleName}</td><td class=\"row3{(colors.Item3 != "" ? " " + colors.Item3 : "")}\">Caught Exception:</td></tr>\n";
				output += $"<tr><td class=\"multirow{(colors.Item3 != "" ? " " + colors.Item3 : "")}\" colspan=3>{Message}</td></tr>\n";
			}
			else
			{
				output += $"<tr><td class=\"row1{(colors.Item1 != "" ? " " + colors.Item1 : "")}\"><abbr title=\"{Date.ToString("MMM dd, YYYY")}\">{Date.ToString("HH:mm:ss")}</abbr></td><td class=\"row2{(colors.Item2 != "" ? " " + colors.Item2 : "")}\">{ModuleName}</td><td class=\"row3{(colors.Item3 != "" ? " " + colors.Item3 : "")}\">{Message}</td></tr>\n";
			}
			return output;
		}

		private Tuple<string, string, string> ParseColors(ConsoleMessageType type)
		{
			switch (type)
			{
				case ConsoleMessageType.Error:
					return Tuple.Create("error", "error", "error");
				case ConsoleMessageType.Warning:
					return Tuple.Create("warning", "warning", "warning");
				case ConsoleMessageType.User:
					return Tuple.Create("", "user", "user");
				case ConsoleMessageType.Info:
					return Tuple.Create("", "", "");
				case ConsoleMessageType.Module:
					return Tuple.Create("", "module", "module");
				case ConsoleMessageType.Heart:
					return Tuple.Create("", "", "module");
				case ConsoleMessageType.Discord:
					return Tuple.Create("", "discord", "discord");
				case ConsoleMessageType.Attention:
					return Tuple.Create("warning", "warning", "warning");
				default:
					return Tuple.Create("warning", "warning", "warning");
			}
		}
		
	}
}
