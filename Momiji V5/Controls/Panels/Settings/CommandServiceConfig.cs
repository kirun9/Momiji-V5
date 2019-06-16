namespace Momiji.Bot.V5.Core.Controls.Panels.Settings
{
	public class CommandServiceConfig
	{
		public bool CaseSensitiveCommands { get; set; } = false;
		public bool CaseSensitiveCommandsChanged { get; set; } = false;
		public global::Discord.Commands.RunMode DefaultRunMode { get; set; } = global::Discord.Commands.RunMode.Async;
		public bool DefaultRunModeChanged { get; set; } = false;
		public bool IgnoreExtraArgs { get; set; } = false;
		public bool IgnoreExtraArgsChanged { get; set; } = false;
		public global::Discord.LogSeverity LogLevel { get; set; } = global::Discord.LogSeverity.Info;
		public bool LogLevelChanged { get; set; } = false;
		public char SeparatorChar { get; set; } = ' ';
		public bool SeparatorCharChanged { get; set; } = false;
		public bool ThrowOnError { get; set; } = true;
		public bool ThrowOnErrorChanged { get; set; } = false;
	}
}