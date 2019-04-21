using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Discord
{

	public class DiscordConfig
	{
		[XmlElement]
		public DiscordSocketConfigObj DiscordSocketConfig { get; set; } = new DiscordSocketConfigObj();
		[XmlElement]
		public CommandServiceConfigObj CommandServiceConfig { get; set; } = new CommandServiceConfigObj();
	}
}
