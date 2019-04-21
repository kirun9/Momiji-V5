using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Discord
{
	public class DiscordSocketConfigObj
	{
		[XmlElement]
		public global::Discord.RetryMode DefaultRetryMode { get; set; } = global::Discord.RetryMode.AlwaysRetry;
		[XmlElement]
		public global::Discord.LogSeverity LogSeverity { get; set; } = global::Discord.LogSeverity.Info;
		[XmlElement]
		public int MessageCacheSize { get; set; } = 100;
	}
}
