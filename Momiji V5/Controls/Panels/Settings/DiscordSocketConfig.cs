namespace Momiji.Bot.V5.Core.Controls.Panels.Settings
{
	public class DiscordSocketConfig
	{
		public global::Discord.RetryMode DefaultRetryMode { get; set; } = global::Discord.RetryMode.AlwaysRetry;
		public bool DefaultRetryModeChanged { get; set; } = false;
		public global::Discord.LogSeverity LogSeverity { get; set; } = global::Discord.LogSeverity.Info;
		public bool LogSeverityChanged { get; set; } = false;
		public int MessageCacheSize { get; set; } = 100;
		public bool MessageCacheSizeChanged { get; set; } = false;
	}
}