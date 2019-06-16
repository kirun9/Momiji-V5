using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Discord
{
	public class CommandServiceConfigObj
	{
		[XmlElement]
		public bool CaseSensitiveCommands { get; set; } = false;
		[XmlElement]
		public global::Discord.Commands.RunMode DefaultRunMode { get; set; } = global::Discord.Commands.RunMode.Async;
		[XmlElement]
		public bool IgnoreExtraArgs { get; set; } = false;
		[XmlElement]
		public global::Discord.LogSeverity LogLevel { get; set; } = global::Discord.LogSeverity.Info;
		[XmlElement]
		public char SeparatorChar { get; set; } = ' ';
		[XmlElement]
		public bool ThrowOnError { get; set; } = true;
		[XmlElement]
		public string CommandPrefix { get; set; } = "!";
		[XmlElement]
		public bool ReactOnMention { get; set; } = false;
	}
}
