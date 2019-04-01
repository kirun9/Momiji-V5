using System;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static string ReadHtmlConsoleHeader()
		{
			string s = global::Momiji.Bot.V5.Core.Properties.Resources.ConsoleHeader;
			//System.Diagnostics.Debug.WriteLine(s);
			return s;
		}

		public static void TestConsole(InternalServer.Server server)
		{
			server.Append("22:51:56", "Module Manager", "Found 13 modules", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialization procedure started", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Contest Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Discord Module v2", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Fortune Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Game Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Help Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Momiji Commands Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Momiji Talk Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Personal Culture Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Schedule Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Timer Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Usefull Commands Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Voting Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Preinitialized: Welcome Message Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Initialization procedure started", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Trying to initialize: Timer Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Module Manager", "Trying to initialize: Discord Module v2", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Discord", "Initializing Discord Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Discord", "Discord.Net v2.0.0-beta2-00936 (API v6)", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:56", "Gateway", "Connecting", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:57", "Gateway", "Connected", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Startup", "Bot successfully connected to Discord", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Gateway", "Ready", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Contest Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Fortune Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Game Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Help Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Momiji Commands Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Momiji Talk Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Momiji Talk Module", "Connecting to dialogflow.", Controls.Panels.ConsoleMessageType.Module);
			server.Append("22:51:58", "Dialogflow", "Connection request send ...", Controls.Panels.ConsoleMessageType.Module);
			server.Append("22:51:58", "Dialogflow", "Connected to dialogflow", Controls.Panels.ConsoleMessageType.Module);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Personal Culture Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Schedule Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Schedule Module", "Module resources loaded", Controls.Panels.ConsoleMessageType.Module);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Usefull Commands Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Voting Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to initialize: Welcome Message Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Postinitialization procedure started", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Timer Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Discord", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Contest Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Fortune Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Game Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Help Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Momiji Commands Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Momiji Talk Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Personal Culture Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Schedule Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Usefull Commands Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Voting Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Trying to postinitialize: Welcome Message Module", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Module Manager", "Modules loaded", Controls.Panels.ConsoleMessageType.Info);
			server.Append("22:51:58", "Startup", "Bot Initialized", Controls.Panels.ConsoleMessageType.Info);
		}

		public static void TestConsole2(InternalServer.Server server)
		{
			server.Append("22:53:08", "Kirun", "!activity set Watching ZeroIsYourHero - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:53:37", "Kirun", "!help - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:53:56", "Kirun", "!bot activity set Watching ZeroIsYourHero - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:54:24", "Kirun", "!bot status inactive - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:54:32", "Kirun", "!bot status idle - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:54:47", "Kirun", "!bot status connected - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:55:46", "Kirun", "!bot activity set Listening to ZeroIsYourHero complains - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("22:57:29", "Kirun", "!bot activity set Listening ZeroIsYourHero complains - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("23:09:33", "Kirun", "!endpoll 1 - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("23:14:47", "Kirun", "!schedule event add 2018-11-16T05:00 <#384038526531928064> - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("23:14:48", "Schedule", "Added schedule to database.", Controls.Panels.ConsoleMessageType.Module);
			server.Append("23:14:48", ".DEBUG", "Schedule Info: ID=1; guildID=384025726208442389", Controls.Panels.ConsoleMessageType.Info);
			server.Append("23:14:48", "Schedule", "Added schedule to database.", Controls.Panels.ConsoleMessageType.Module);
			server.Append("23:14:48", ".DEBUG", "Schedule Info: ID=2; guildID=384025726208442389", Controls.Panels.ConsoleMessageType.Info);
			server.Append("23:14:48", "Schedule", "Added schedule to database.", Controls.Panels.ConsoleMessageType.Module);
			server.Append("23:14:48", ".DEBUG", "Schedule Info: ID=3; guildID=384025726208442389", Controls.Panels.ConsoleMessageType.Info);
			server.Append("23:15:27", "Kirun", "!bot activity set Playing Dream Girlfriend - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("23:15:38", "Kirun", "!bot activity set Playing Dream Girlfriend - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("23:22:14", "Kirun", "!bot activity set watching ZeroIsYourHero by CCTV - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("23:22:27", "Kirun", "!bot activity set watching ZeroIsYourHero in CCTV - sent from: Test", Controls.Panels.ConsoleMessageType.User);
			server.Append("00:00:58", "Discord", "", Controls.Panels.ConsoleMessageType.Info);
			server.Append("00:00:58", "Discord", "", Controls.Panels.ConsoleMessageType.Info);
			server.Append("00:00:58", "Discord", "09 Nov (11) 2018 (Friday)", Controls.Panels.ConsoleMessageType.Info);
			server.Append("00:00:58", "Discord", "", Controls.Panels.ConsoleMessageType.Info);
			server.Append("00:00:58", "Discord", "", Controls.Panels.ConsoleMessageType.Info);
			server.Append("03:15:55", "Kirun", "!m I can't sleep .. - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("03:16:56", "Kirun", "!m Why do you think I have turned on radio in the middle of the night? - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("03:17:17", "Kirun", "!m Because it does not work - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("03:21:38", "Kirun", "!say <#384025726212636673> 👀 - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("03:23:58", "Kirun", "!say <#384025726212636673> 📹 - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("05:29:28", "ZeroIsYourHero", "!m Will you stop watching me? - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("08:36:58", "Kirun", "!fortune - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("13:28:32", "Rorani", "!fortune - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("16:24:17", "Kirun", "!fortune - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("17:37:26", "ZeroIsYourHero", "!fortune - sent from: Super Secret Society", Controls.Panels.ConsoleMessageType.User);
			server.Append("21:11:03", "Gateway", @"
System.Exception: WebSocket connection was closed ---> System.Net.WebSockets.WebSocketException: An internal WebSocket error occurred. Please see the innerException, if present, for more details.  ---> System.IO.IOException: Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host. ---> System.Net.Sockets.SocketException: An existing connection was forcibly closed by the remote host
   at System.Net.Sockets.Socket.EndReceive(IAsyncResult asyncResult)
   at System.Net.Sockets.NetworkStream.EndRead(IAsyncResult asyncResult)
   --- End of inner exception stack trace ---
   at System.Net.Security._SslStream.EndRead(IAsyncResult asyncResult)
   at System.Net.TlsStream.EndRead(IAsyncResult asyncResult)
   at System.Net.PooledStream.EndRead(IAsyncResult asyncResult)
   at System.IO.Stream.<>c.<BeginEndReadAsync>b__43_1(Stream stream, IAsyncResult asyncResult)
   at System.Threading.Tasks.TaskFactory`1.FromAsyncTrimPromise`1.Complete(TInstance thisRef, Func`3 endMethod, IAsyncResult asyncResult, Boolean requiresSynchronization)
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Net.WebSockets.WebSocketConnectionStream.<ReadAsync>d__21.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.ValidateEnd(Task task)
   at System.Net.WebSockets.WebSocketBase.WebSocketOperation.<Process>d__19.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Net.WebSockets.WebSocketBase.<ReceiveAsyncCore>d__45.MoveNext()
   --- End of inner exception stack trace ---
   at System.Net.WebSockets.WebSocketBase.ThrowIfConvertibleException(String methodName, Exception exception, CancellationToken cancellationToken, Boolean aborted)
   at System.Net.WebSockets.WebSocketBase.<ReceiveAsyncCore>d__45.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Discord.Net.WebSockets.DefaultWebSocketClient.<RunAsync>d__33.MoveNext()
   --- End of inner exception stack trace ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Discord.ConnectionManager.<>c__DisplayClass28_0.<<StartAsync>b__0>d.MoveNext()", Controls.Panels.ConsoleMessageType.Warning);
		}
	}
}
