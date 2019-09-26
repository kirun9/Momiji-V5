using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace Momiji.Bot.V5.Core.InternalServer
{
	internal class Server : IConsole
	{
		private readonly ushort Port = 12369; 

		private static int MaxLogs { get; } = 100;
		private DateTime startDateTime;
		private static Server _instance;
		private static readonly CultureInfo EnglishCulture = new CultureInfo("en-US");
		private LogMessage[] logMessages = new LogMessage[0];
		private HttpListener listener;
		private string filePath;
		private StreamWriter streamWriter;

		internal static Server Instance
		{
			get
			{
				if (_instance == null)
				{
					return new Server();
				}
				else
				{
					return _instance;
				}
			}
			set
			{
				_instance = value;
			}
		}

		public Server()
		{
			var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
			var principal = new System.Security.Principal.WindowsPrincipal(identity);
			var isAdministrator = principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);

			listener = new HttpListener();
			var host = Dns.GetHostEntry(Dns.GetHostName());
			if (isAdministrator)
			{
				foreach (var ip in host.AddressList)
				{
					if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
					{
						listener.Prefixes.Add($"http://{ip.ToString()}:{Port}/");
						listener.Prefixes.Add($"http://{ip.ToString()}:80/");
					}
				}
				listener.Prefixes.Add("http://localhost:80/");
			}
			listener.Prefixes.Add($"http://localhost:{Port}/");
			startDateTime = DateTime.Now;
			#region FileLogger
			if (Program.ENABLE_FILE_LOGGING)
			{
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
			}
			#endregion
			Instance = this;
		}

		public void Start()
		{
			listener.Start();
			Thread thread = new Thread(() => {
				try
				{
					while (listener.IsListening)
					{
						var context = listener.GetContext();
						context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
						context.Response.Headers.Add("Access-Control-Allow-Methods", "GET");
						string webFilePath = context.Request.Url.AbsolutePath.Substring(1);
						context.Response.StatusCode = 200;
						if (context.Request.Url.Port == 80)
						{
							try
							{
								var writer = new StreamWriter(context.Response.OutputStream);
								var path = ".\\website\\" + ((webFilePath ?? "") == "" ? "index.html" : context.Request.Url.LocalPath.Substring(1));
								var ext = Path.GetExtension(path);
								if (ext == ".png")
								{
									var bytes = File.ReadAllBytes(path);
									writer.Write("Content-Type: image/png\r\n");
									writer.Write("Content-Length: " + bytes.Length + "\r\n");
									writer.BaseStream.Write(bytes, 0, bytes.Length);
									writer.Close();
								}
								else
								{
									var html = File.ReadAllText(path);
									writer.Write(html);
									writer.Close();
								}
							}
							catch (FileNotFoundException)
							{
								context.Response.StatusCode = 404;
							}
							catch (Exception)
							{
								context.Response.StatusCode = 500;
								//context.Response.StatusDescription = ex.Message;
							}
							context.Response.Close();
						}
						else
						{
							switch (webFilePath)
							{
								case "main.html":
								{
									var writer = new StreamWriter(context.Response.OutputStream);
									var html = Properties.Resources.ConsoleHeader;
									html = html.Replace("<MomijiVersion />", GetType().Assembly.GetName().Version.ToString(4));
									html = html.Replace("<Date />", "Started " + startDateTime.ToString("MMMM dd, yyyy 'at' HH:mm:ss", EnglishCulture));
									writer.Write(html);
									writer.Close();
									context.Response.Close();
									break;
								}
								case "console/ConsoleScript.js":
								{
									var writer = new StreamWriter(context.Response.OutputStream);
									writer.Write(Properties.Resources.ConsoleScript);
									writer.Close();
									context.Response.Close();
									break;
								}
								case "console/ConsoleStyle.css":
								{
									var writer = new StreamWriter(context.Response.OutputStream);
									writer.Write(Properties.Resources.ConsoleStyle);
									writer.Close();
									context.Response.Close();
									break;
								}
								case "log.html":
								{
									var writer = new StreamWriter(context.Response.OutputStream);
									var output = "<table>\n<colgroup><col width=\"70px\" /><col width=\"120px\" /><col width=\"430px\" /></colgroup>\n";
									output += GetLog();
									output += "\n</table>\n";
									writer.Write(output);
									writer.Close();
									context.Response.Close();
									break;
								}
							}
						}
					}
				}
				catch (HttpListenerException ex) when (ex.ErrorCode == 995 || ex.ErrorCode == 6)
				{

				}
				catch (HttpListenerException ex)
				{
					Append(new LogMessage(DateTime.Now, "Logger", ex.ToString(), ConsoleMessageType.Error));
					Start();
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
			if (Program.ENABLE_FILE_LOGGING)
			{
				streamWriter.WriteLine(EndHtmlFile());
				streamWriter.Flush();
				streamWriter.Close();
				streamWriter.Dispose();
			}
			listener.Stop();
			listener.Close();
		}


		public void Append(string moduleName, string message, ConsoleMessageType type)
		{
			Append(new LogMessage(DateTime.Now, moduleName, message, type));
		}

		internal void Append(LogMessage message)
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
			if (Program.ENABLE_FILE_LOGGING)
			{
				streamWriter.WriteLine(message.ToString());
			}
		}

		public static void StartServer() => Instance.Start();

		public static void StopServer() => Instance.Stop();

		public static void ShutdownServer() => Instance.Shutdown();

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
			html = html.Replace("<script src=\"console/ConsoleScript.js\"></script>", "<script>document.getElementById(\"consoleVersion\").innerHTML += \" offline mode\"</script>");
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
