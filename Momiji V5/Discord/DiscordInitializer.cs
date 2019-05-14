using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using Momiji.Bot.V3.Serialization.XmlSerializer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Momiji.Bot.V5.Modules;

namespace Momiji.Bot.V5.Core.Discord
{
	public partial class DiscordInitializer
	{
		internal static DiscordInitializer Instance;

		private static bool _connect;

		internal DiscordSocketConfig DiscordSocketConfig { get; private set; }
		internal DiscordSocketClient DiscordSocketClient { get; private set; }
		internal CommandServiceConfig CommandServiceConfig { get; private set; }
		internal CommandService CommandService { get; private set; }
		internal IServiceProvider ServiceProvider { get; private set; }
		internal bool Initialized = false;

		public static XmlObject<DiscordConfig> DiscordCfg { get; set; } = new XmlObject<DiscordConfig>()
		{
			Data = new DiscordConfig(),
			Version = new XmlSerializerVersion("v1.0.0.0")
		};
		public static XmlSerializerConfig<XmlObject<DiscordConfig>> SerializerConfig { get; set; } = new XmlSerializerConfig<XmlObject<DiscordConfig>>()
		{
			Data = DiscordCfg,
			Directory = "configs",
			FileName = "DiscordConfig.xml"
		};

		private DiscordInitializer(bool connect)
		{
			_connect = connect;
		}

		private void Initialize()
		{
			DiscordCfg = XmlSerializer.Load(SerializerConfig);

			DiscordSocketConfig = new DiscordSocketConfig();

			Log("Using Discord.Net version v" + global::Discord.DiscordConfig.Version);

			DiscordSocketConfig.DefaultRetryMode = DiscordCfg.Data.DiscordSocketConfig.DefaultRetryMode;
			DiscordSocketConfig.LogLevel = DiscordCfg.Data.DiscordSocketConfig.LogSeverity;
			DiscordSocketConfig.MessageCacheSize = DiscordCfg.Data.DiscordSocketConfig.MessageCacheSize; ;

			DiscordSocketClient = new DiscordSocketClient(DiscordSocketConfig);
			DiscordSocketClient.Log += LogSocket;

			CommandServiceConfig = new CommandServiceConfig();
			CommandServiceConfig.CaseSensitiveCommands = DiscordCfg.Data.CommandServiceConfig.CaseSensitiveCommands;
			CommandServiceConfig.DefaultRunMode = DiscordCfg.Data.CommandServiceConfig.DefaultRunMode;
			CommandServiceConfig.IgnoreExtraArgs = DiscordCfg.Data.CommandServiceConfig.IgnoreExtraArgs;
			CommandServiceConfig.LogLevel = DiscordCfg.Data.CommandServiceConfig.LogLevel;
			CommandServiceConfig.SeparatorChar = DiscordCfg.Data.CommandServiceConfig.SeparatorChar;
			CommandServiceConfig.ThrowOnError = DiscordCfg.Data.CommandServiceConfig.ThrowOnError;

			CommandService = new CommandService(CommandServiceConfig);
			CommandService.Log += LogCommands;

			ServiceProvider = new ServiceCollection()
				.AddSingleton(DiscordSocketClient)
				.AddSingleton(CommandService)
				.BuildServiceProvider();
		}

		private async Task Connect()
		{
			if (_connect)
			{
				DiscordSocketClient.Ready += DiscordSocketClient_Ready;
				await DiscordSocketClient.LoginAsync(TokenType.Bot, BotKeyReader.BOT_TOKEN);
				await DiscordSocketClient.StartAsync();
				await DiscordSocketClient.SetStatusAsync(UserStatus.Online);
			}
			else
			{
				await DiscordSocketClient_Ready();
			}
		}
		private Task DiscordSocketClient_Ready()
		{
			Initialized = true;
			return Task.CompletedTask;
		}

		private async Task Disconnect()
		{
			await DiscordSocketClient.LogoutAsync();
		}

		internal static void ModuleBase_LogEvent(MomijiModuleBase sender, String message)
		{
			InternalServer.Server.Log(sender.ModuleName, message, InternalServer.ConsoleMessageType.Module);
		}

		internal static void UpdateConfig(DiscordConfig config, bool restart)
		{
			Task task = new Task(async () => {
				DiscordCfg.Data = config;
				SerializerConfig.Data = DiscordCfg;
				XmlSerializer.Save(SerializerConfig);
				Log("Discord configuration changed.");
				if (restart)
				{
					Log("Restarting discord");
					await DisconnectDiscord();
					await InitializeDiscord(_connect);
				}
				else
				{
					Log("Restarting delayed");
				}
			});
			task.Start();
		}
	}
}
