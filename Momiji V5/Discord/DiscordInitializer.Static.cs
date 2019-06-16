using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core.Discord
{
	public partial class DiscordInitializer
	{
		public static async Task InitializeDiscord(bool connect)
		{
			Instance = new DiscordInitializer(connect);
			Instance.Initialize();
			await Instance.Connect();
		}

		public static async Task DisconnectDiscord()
		{
			InternalServer.Server.Log("DiscordModule", "Disconnect operation was requested", InternalServer.ConsoleMessageType.Attention);
			await Instance.Disconnect();
		}

		public static void Log(string message)
		{
			InternalServer.Server.Log("DiscordModule", message, InternalServer.ConsoleMessageType.Heart);
		}

		public static Task LogSocket(LogMessage message)
		{
			InternalServer.Server.Log(message.Source, message.Message, InternalServer.ConsoleMessageType.Discord);
			return Task.CompletedTask;
		}

		public static Task LogCommands(LogMessage message)
		{
			InternalServer.Server.Log(message.Source, message.Message, InternalServer.ConsoleMessageType.User);
			return Task.CompletedTask;
		}
	}
}
