using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace Momiji.Bot.V5.Core.InternalServer
{
	internal class Server
	{
		private static int MaxLogs { get; } = 100;
		private DateTime startDateTime;
		private static Server Instance;
		private static readonly CultureInfo EnglishCulture = new CultureInfo("en-US");
		private LogMessage[] logMessages = new LogMessage[0];
		private HttpListener listener;
		private string filePath;
		private StreamWriter streamWriter;

		public Server()
		{
			listener = new HttpListener();
			listener.Prefixes.Add("http://localhost:12369/");
			startDateTime = DateTime.Now;
			#region FileLogger
			int fileNumber = 0;
			string fileName = startDateTime.ToString("yyyy-MM-dd HH_mm_ss", EnglishCulture);
			filePath = Path.Combine("logs", $"{fileName}.log.html");
			string fullPath = Path.GetFullPath(filePath);
			while (File.Exists(filePath))
			{
				filePath = Path.Combine("logs", $"{fileName} ({fileNumber++}).log.html");
			}
			if (!Directory.Exists(Path.GetDirectoryName(filePath)))
			{
				Directory.CreateDirectory(Path.GetDirectoryName(filePath));
			}
			streamWriter = File.CreateText(filePath);
			streamWriter.AutoFlush = true;

			var html = PrepareHtmlForFile();
			streamWriter.WriteLine(html);

			#endregion
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
						html = html.Replace("<Date />", "Started " + startDateTime.ToString("MMMM dd, yyyy 'at' HH:mm:ss", EnglishCulture));
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

		public void Shutdown()
		{
			listener.Stop();
			listener.Close();
			streamWriter.WriteLine(EndHtmlFile());
			streamWriter.Flush();
			streamWriter.Close();
			streamWriter.Dispose();
		}

		public void Append(LogMessage message)
		{
			if (logMessages.Length >= MaxLogs)
			{
				var temp = new LogMessage[MaxLogs];
				for (int i = 0; i < MaxLogs - 1; i++)
				{
					temp[i] = logMessages[i + 1];
				}
				temp[MaxLogs - 1] = message;
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
			streamWriter.WriteLine(message.ToString());
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
		public static void ShutdownServer()
		{
			Instance.Shutdown();
		}

		private string GetLog()
		{
			string output = "";
			foreach (LogMessage message in logMessages)
			{
				output += message.ToString();
			}
			return output;
		}

		private string PrepareHtmlForFile()
		{
			var html = Properties.Resources.ConsoleHeader;
			html = html.Replace("<link rel=\"stylesheet\" href=\"console/ConsoleStyle.css\" />", $"<style>{Properties.Resources.ConsoleStyle}</style>");
			html = html.Replace("<script src=\"console/ConsoleScript.js\"></script>", "");
			html = html.Replace("<MomijiVersion />", GetType().Assembly.GetName().Version.ToString(4));
			html = html.Replace("<Date />", "Started " + startDateTime.ToString("MMMM dd, yyyy 'at' HH:mm:ss", EnglishCulture));
			string[] s = html.Split(new string[]{ "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			html = string.Join(Environment.NewLine, s.Take(s.Length - 3));
			html += "<table>\n<colgroup><col width=\"70px\" /><col width=\"120px\" /><col width=\"430px\" /></colgroup>\n";
			return html;
		}
		private string EndHtmlFile()
		{
			return "</table>\n</div>\n</body>\n</html>";
		}
	}
}
