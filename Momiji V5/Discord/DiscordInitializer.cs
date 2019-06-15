using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using Momiji.Bot.V3.Serialization.XmlSerializer;
using Microsoft.Extensions.DependencyInjection;
using System;
using Momiji.Bot.V5.Modules;
using System.Reflection;

namespace Momiji.Bot.V5.Core.Discord
{
	public partial class DiscordInitializer : MarshalByRefObject
	{
		internal static DiscordInitializer Instance;

		private static bool _connect;

		internal DiscordSocketConfig DiscordSocketConfig { get; private set; }
		internal DiscordSocketClient DiscordSocketClient { get; private set; }
		internal CommandServiceConfig CommandServiceConfig { get; private set; }
		internal CommandService CommandService { get; private set; }
		public IServiceProvider ServiceProvider { get; set; }
		internal bool Initialized = false;

		public static XmlObject<DiscordConfig> DiscordCfg { get; set; } = new XmlObject<DiscordConfig>()
		{
			Data = new DiscordConfig(),
			Version = new XmlSerializerVersion("v1.0.0.0")
		};
		public static XmlSerializerConfig<DiscordConfig> SerializerConfig { get; set; } = new XmlSerializerConfig<DiscordConfig>()
		{
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
				DiscordSocketClient.MessageReceived += DiscordSocketClient_MessageReceived;
			}
			else
			{
				await DiscordSocketClient_Ready();
			}
			await CommandService.AddModulesAsync(Assembly.GetEntryAssembly(), ServiceProvider);
		}

		private async Task DiscordSocketClient_MessageReceived(SocketMessage arg)
		{
			
			var message = arg as SocketUserMessage;
			int argPos = 0;
			if (message is null || message.Content == null)
			{
				return;
			}
			if (message.HasStringPrefix(DiscordCfg.Data.CommandServiceConfig.CommandPrefix, ref argPos) || (DiscordCfg.Data.CommandServiceConfig.ReactOnMention && message.HasMentionPrefix(DiscordSocketClient.CurrentUser, ref argPos)))
			{
				var context = new SocketCommandContext(DiscordSocketClient, message);
				Log(context.User, $"{message.Content} - sent from: {(context.IsPrivate ? "DM channel" : $"{context.Guild.Name} - {context.Channel.Name}")}");
				try
				{
					var result = await CommandService.ExecuteAsync(context, argPos, ServiceProvider);
					if (!result.IsSuccess)
					{
						if (result is ExecuteResult executeResult)
						{
							
						}
					}
				}
				catch (Exception ex)
				{
					Log(context.User, $"Exception in {ex.TargetSite.DeclaringType.FullName} inside {ex.TargetSite.DeclaringType.Assembly.GetName().Name}:" +
						$"\n{this.GetType().FullName}: {ex.Message}\nCommand: {message.Content}\nBy:      {context.User.Username}\nChannel: {context.Channel.Name}\n\n", ex, InternalServer.ConsoleMessageType.Warning);
					await context.Channel.SendMessageAsync("Sorry. I couldn't handle that.\nPlease ask <@332164161129938944> for help. :worried:");
				}
			}
			
		}

		private Task DiscordSocketClient_Ready()
		{
			Initialized = true;
			return Task.CompletedTask;
		}

		internal async Task AddCommands(Type t)
		{
			await CommandService.AddModuleAsync(t, ServiceProvider);
		}

		internal async Task AddCommands(Assembly assembly)
		{
			await CommandService.AddModulesAsync(assembly, ServiceProvider);
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
				XmlSerializer.Save(SerializerConfig, DiscordCfg);
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
