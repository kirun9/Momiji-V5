using Momiji.Bot.V3.Serialization.XmlSerializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core.Controls.Panels.Settings
{
	public class DiscordConfig
	{
		public DiscordSocketConfig DiscordSocketConfig { get; set; } = new DiscordSocketConfig();
		public CommandServiceConfig CommandServiceConfig { get; set; } = new CommandServiceConfig();

		public void Get(XmlObject<Discord.DiscordConfig> xmlObject)
		{
			var socket = xmlObject.Data.DiscordSocketConfig;
			DiscordSocketConfig.DefaultRetryMode =			socket.DefaultRetryMode;
			DiscordSocketConfig.LogSeverity =				socket.LogSeverity;
			DiscordSocketConfig.MessageCacheSize =			socket.MessageCacheSize;

			var service = xmlObject.Data.CommandServiceConfig;
			CommandServiceConfig.CaseSensitiveCommands =	service.CaseSensitiveCommands;
			CommandServiceConfig.DefaultRunMode =			service.DefaultRunMode;
			CommandServiceConfig.IgnoreExtraArgs =			service.IgnoreExtraArgs;
			CommandServiceConfig.LogLevel =					service.LogLevel;
			CommandServiceConfig.SeparatorChar =			service.SeparatorChar;
			CommandServiceConfig.ThrowOnError =				service.ThrowOnError;
		}

		public Discord.DiscordConfig GenerateConfig()
		{
			Discord.DiscordConfig config = new Discord.DiscordConfig();

			var socket = new Discord.DiscordSocketConfigObj();
			socket.DefaultRetryMode			= DiscordSocketConfig.DefaultRetryMode;
			socket.LogSeverity				= DiscordSocketConfig.LogSeverity;
			socket.MessageCacheSize			= DiscordSocketConfig.MessageCacheSize;

			var service = new Discord.CommandServiceConfigObj();
			service.CaseSensitiveCommands	= CommandServiceConfig.CaseSensitiveCommands;
			service.DefaultRunMode			= CommandServiceConfig.DefaultRunMode;
			service.IgnoreExtraArgs			= CommandServiceConfig.IgnoreExtraArgs;
			service.LogLevel				= CommandServiceConfig.LogLevel;
			service.SeparatorChar			= CommandServiceConfig.SeparatorChar;
			service.ThrowOnError			= CommandServiceConfig.ThrowOnError;
			
			config.DiscordSocketConfig = socket;
			config.CommandServiceConfig = service;
			return config;
		}
	}
}
