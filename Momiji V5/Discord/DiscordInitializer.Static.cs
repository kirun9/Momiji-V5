﻿using Discord;
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
		public static void Log(Exception ex)
		{
			InternalServer.Server.Log("DiscordModule", ex.ToString(), InternalServer.ConsoleMessageType.Warning);
		}
		public static void Log(IUser user, string message)
		{
			InternalServer.Server.Log(user.Username, message, InternalServer.ConsoleMessageType.User);
		}
		public static void Log(IUser user, string message, Exception ex, InternalServer.ConsoleMessageType type)
		{
			InternalServer.Server.Log(user.Username, message, ex, type);
		}
		public static void Log(LogMessage logMessage)
		{
			if (logMessage.Exception == null)
				InternalServer.Server.Log(logMessage.Source, logMessage.Message, GetMessageType(logMessage.Severity));
			else
				InternalServer.Server.Log(logMessage.Source, logMessage.Message, logMessage.Exception, GetMessageType(logMessage.Severity));
		}

		private static InternalServer.ConsoleMessageType GetMessageType(LogSeverity severity)
		{
			switch (severity)
			{
				case LogSeverity.Critical: return InternalServer.ConsoleMessageType.Error;
				case LogSeverity.Debug: return InternalServer.ConsoleMessageType.Info;
				case LogSeverity.Error: return InternalServer.ConsoleMessageType.Error;
				case LogSeverity.Info: return InternalServer.ConsoleMessageType.Info;
				case LogSeverity.Verbose: return InternalServer.ConsoleMessageType.Info;
				case LogSeverity.Warning: return InternalServer.ConsoleMessageType.Warning;
				default: return InternalServer.ConsoleMessageType.Info;
			}
		}

		public static Task LogSocket(LogMessage message)
		{
			InternalServer.Server.Log(message.Source, message.Message ?? message.Exception.ToString(), InternalServer.ConsoleMessageType.Discord);
			return Task.CompletedTask;
		}

		public static Task LogCommands(LogMessage message)
		{
			InternalServer.Server.Log(message.Source, message.Message ?? message.Exception.ToString(), InternalServer.ConsoleMessageType.User);
			return Task.CompletedTask;
		}
	}
}
