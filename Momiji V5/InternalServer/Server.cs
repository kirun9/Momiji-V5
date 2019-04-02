using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Momiji.Bot.V5.Core.InternalServer
{
	internal class Server
	{
		private HttpListener listener;
		private string log;
		public Server()
		{
			listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:12369/");
		}

		public void Start()
		{
			listener.Start();
			Thread thread = new Thread(() => {
				while (listener.IsListening)
				{
					var context = listener.GetContext();
					string webFilePath = context.Request.Url.AbsolutePath.Substring(1);
					if (webFilePath.Equals("main.html"))
					{
						var writer = new StreamWriter(context.Response.OutputStream);
						var html = Properties.Resources.ConsoleHeader;
						html = html.Replace("<MomijiVersion />", GetType().Assembly.GetName().Version.ToString(4));
						writer.Write(html);
						writer.Close();
						context.Response.Close();
					}
					else if (webFilePath.Equals("console/ConsoleScript.js"))
					{
						var writer = new StreamWriter(context.Response.OutputStream);
						writer.Write(Properties.Resources.ConsoleScript);
						writer.Close();
						context.Response.Close();
					}
					else if (webFilePath.Equals("console/ConsoleStyle.css"))
					{
						var writer = new StreamWriter(context.Response.OutputStream);
						writer.Write(Properties.Resources.ConsoleStyle);
						writer.Close();
						context.Response.Close();
					}
					else if (webFilePath.Equals("log.html"))
					{
						var writer = new StreamWriter(context.Response.OutputStream);
						var output = "<table>\n<colgroup><col width=\"70px\" /><col width=\"120px\" /><col width=\"430px\" /></colgroup>\n";
						output += log;
						output += "\n</table>\n";
						writer.Write(output);
						writer.Close();
						context.Response.Close();
					}
				}
			});
			thread.Start();
		}

		public void Stop()
		{
			listener.Stop();
		}

		public void Append(string date, string moduleName, string message, ConsoleMessageType messageType = ConsoleMessageType.Info)
		{
			var colors = ParseColors(messageType);
			message = message.Trim();
			message = message.PreventInjection();
			message = message.Replace("\n", "<br />\n");

			if (messageType == ConsoleMessageType.Warning || messageType == ConsoleMessageType.Error)
			{
				log += $"<tr><td class=\"row1{(colors.Item1 != "" ? " " + colors.Item1 : "")}\">{date}</td><td class=\"row2{(colors.Item2 != "" ? " " + colors.Item2 : "")}\">{moduleName}</td><td class=\"row3{(colors.Item3 != "" ? " " + colors.Item3 : "")}\">Caught Exception:</td></tr>\n";
				log += $"<tr><td class=\"multirow{(colors.Item3 != "" ? " " + colors.Item3 : "")}\" colspan=3>{message}</td></tr>\n";
			}
			else
			{
				log += $"<tr><td class=\"row1{(colors.Item1 != "" ? " " + colors.Item1 : "")}\">{date}</td><td class=\"row2{(colors.Item2 != "" ? " " + colors.Item2 : "")}\">{moduleName}</td><td class=\"row3{(colors.Item3 != "" ? " " + colors.Item3 : "")}\">{message}</td></tr>\n";
			}
		}
		public Tuple<string, string, string> ParseColors(ConsoleMessageType type)
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
				default:
					return Tuple.Create("warning", "warning", "warning");
			}
		}
	}
}
