using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace Momiji.Bot.V5.Core.InternalServer
{
	internal class Server
	{
		private static Server Instance;
		private LogMessage[] logMessages = new LogMessage[0];
		private HttpListener listener;

		public Server()
		{
			listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:12369/");
			Instance = this;
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
						output += GetLog();
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

		public void Append(LogMessage message)
		{
			if (logMessages.Length >= 100)
			{
				var temp = new LogMessage[100];
				for (int i = 0; i < 99; i++)
				{
					temp[i] = temp[i + 1];
				}
				temp[99] = message;
				logMessages = temp;
			}
			else
			{
				var temp = new LogMessage[logMessages.Length + 1];
				int i = 0;
				for (; i < logMessages.Length; i++)
				{
					temp[i] = logMessages[i];
				}
				temp[i] = message;
				logMessages = temp;
			}
		}
		public void Append(string date, string moduleName, string message, ConsoleMessageType messageType = ConsoleMessageType.Info)
		{
			LogMessage logMessage = new LogMessage(date, moduleName, message, messageType);
			Append(logMessage);
		}

		public static void Log(string date, string moduleName, string message,ConsoleMessageType messageType = ConsoleMessageType.Info) => Instance.Append(date, moduleName, message, messageType);

		public static void Log(LogMessage message) => Instance.Append(message);

		public static void StartServer() => Instance.Start();

		public static void StopServer() => Instance.Stop();

		private string GetLog()
		{
			string output = "";
			foreach (LogMessage message in logMessages)
			{
				output += message.ToString();
			}
			return output;
		}
	}
}
