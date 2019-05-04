using System;
using System.Windows.Forms;
using RetryMode = Discord.RetryMode;
using LogS = Discord.LogSeverity;

namespace Momiji.Bot.V5.Core.Controls.Panels.Settings
{
	public partial class Settings : UserControl
	{
		DiscordConfig prevConfig = new DiscordConfig();
		DiscordConfig newConfig = new DiscordConfig();
		public Settings()
		{
			InitializeComponent();
			prevConfig.Get(Discord.DiscordInitializer.DiscordCfg);
			newConfig.Get(Discord.DiscordInitializer.DiscordCfg);

			DefaultRetryMode.SelectedIndex = DefaultRetryMode.Items.IndexOf(prevConfig.DiscordSocketConfig.DefaultRetryMode.ToString());
			LogSeverity.SelectedIndex = LogSeverity.Items.IndexOf(prevConfig.DiscordSocketConfig.LogSeverity.ToString());
			MessageCacheSize.Value = prevConfig.DiscordSocketConfig.MessageCacheSize;
		}

		private void AppendStar(Label label, Control control, bool condition)
		{
			if (label.Text.EndsWith("*"))
			{
				if (!condition)
				{
					label.Text = label.Text.Substring(0, label.Text.Length - 1);
					control.Font = new System.Drawing.Font(control.Font, System.Drawing.FontStyle.Regular);
				}
			}
			else
			{
				if (condition)
				{
					label.Text += "*";
					control.Font = new System.Drawing.Font(control.Font, System.Drawing.FontStyle.Bold);
				}
			}
		}

		private void DefaultRetryMode_SelectedIndexChanged(Object sender, EventArgs e)
		{
			void Change(RetryMode mode)
			{
				newConfig.DiscordSocketConfig.DefaultRetryMode = mode;
				if (prevConfig.DiscordSocketConfig.DefaultRetryMode != mode)
				{
					newConfig.DiscordSocketConfig.DefaultRetryModeChanged = true;
				}
				else
				{
					newConfig.DiscordSocketConfig.DefaultRetryModeChanged = false;
				}
				AppendStar(DefaultRetryModeLabel, DefaultRetryMode, newConfig.DiscordSocketConfig.DefaultRetryModeChanged);
			}
			switch (DefaultRetryMode.SelectedItem as string)
			{
				case "AlwaysFail":
				{
					Change(RetryMode.AlwaysFail);
					return;
				}
				case "AlwaysRetry":
				{
					Change(RetryMode.AlwaysRetry);
					return;
				}
				case "Retry502":
				{
					Change(RetryMode.Retry502);
					return;
				}
				case "RetryRatelimit":
				{
					Change(RetryMode.RetryRatelimit);
					return;
				}
				case "RetryTimeouts":
				{
					Change(RetryMode.RetryTimeouts);
					return;
				}
				case "":
				default:
				{
					Change(RetryMode.AlwaysRetry);
					return;
				}
			}
		}

		private void LogSeverity_SelectedIndexChanged(Object sender, EventArgs e)
		{
			void Change(LogS mode)
			{
				newConfig.DiscordSocketConfig.LogSeverity = mode;
				if (prevConfig.DiscordSocketConfig.LogSeverity != mode)
				{
					newConfig.DiscordSocketConfig.LogSeverityChanged = true;
				}
				else
				{
					newConfig.DiscordSocketConfig.LogSeverityChanged = false;
				}
				AppendStar(LogSeverityLabel, LogSeverity, newConfig.DiscordSocketConfig.LogSeverityChanged);
			}
			switch (LogSeverity.SelectedItem as string)
			{
				case "Critical":
				{
					Change(LogS.Critical);
					return;
				}
				case "Debug":
				{
					Change(LogS.Debug);
					return;
				}
				case "Error":
				{
					Change(LogS.Error);
					return;
				}
				case "Info":
				{
					Change(LogS.Info);
					return;
				}
				case "Verbose":
				{
					Change(LogS.Verbose);
					return;
				}
				case "Warning":
				{
					Change(LogS.Warning);
					return;
				}
				case "":
				default:
				{
					Change(LogS.Info);
					return;
				}
			}
		}

		private void MessageCacheSize_ValueChanged(Object sender, EventArgs e)
		{
			var val = MessageCacheSize.Value;
			newConfig.DiscordSocketConfig.MessageCacheSize = (int) val;
			if (prevConfig.DiscordSocketConfig.MessageCacheSize != (int) val)
			{
				newConfig.DiscordSocketConfig.MessageCacheSizeChanged = true;
			}
			else
			{
				newConfig.DiscordSocketConfig.MessageCacheSizeChanged = false;
			}
			AppendStar(MessageCacheSizeLabel, MessageCacheSize, newConfig.DiscordSocketConfig.MessageCacheSizeChanged);
			
		}
	}
}
