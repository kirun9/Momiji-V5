using System;
using System.Windows.Forms;
using RetryMode = Discord.RetryMode;
using LogS = Discord.LogSeverity;
using RunMode = Discord.Commands.RunMode;

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

			CaseSensitiveCommands.SelectedIndex = CaseSensitiveCommands.Items.IndexOf(prevConfig.CommandServiceConfig.CaseSensitiveCommands.ToString());
			DefaultRunMode.SelectedIndex = DefaultRunMode.Items.IndexOf(prevConfig.CommandServiceConfig.DefaultRunMode.ToString());
			IgnoreExtraArgs.SelectedIndex = IgnoreExtraArgs.Items.IndexOf(prevConfig.CommandServiceConfig.IgnoreExtraArgs.ToString());
			LogLevel.SelectedIndex = LogLevel.Items.IndexOf(prevConfig.CommandServiceConfig.LogLevel.ToString());
			ThrowOnError.SelectedIndex = ThrowOnError.Items.IndexOf(prevConfig.CommandServiceConfig.ThrowOnError.ToString());
			SeparatorChar.Text = prevConfig.CommandServiceConfig.SeparatorChar + "";
		}

		private void UpdateHeaders()
		{
			AppendStar(DiscordSocketConfigLabel,
				newConfig.DiscordSocketConfig.DefaultRetryModeChanged		||
				newConfig.DiscordSocketConfig.LogSeverityChanged			||
				newConfig.DiscordSocketConfig.MessageCacheSizeChanged);

			AppendStar(CommandServiceConfigLabel,
				newConfig.CommandServiceConfig.CaseSensitiveCommandsChanged ||
				newConfig.CommandServiceConfig.DefaultRunModeChanged		||
				newConfig.CommandServiceConfig.IgnoreExtraArgsChanged		||
				newConfig.CommandServiceConfig.LogLevelChanged				||
				newConfig.CommandServiceConfig.SeparatorCharChanged			||
				newConfig.CommandServiceConfig.ThrowOnErrorChanged );
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
			UpdateHeaders();
		}

		private void AppendStar(Label label, bool condition)
		{
			if (label.Text.EndsWith("*"))
			{
				if (!condition)
				{
					label.Text = label.Text.Substring(0, label.Text.Length - 1);
				}
			}
			else
			{
				if (condition)
				{
					label.Text += "*";
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
				case "Info":
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

		private void CaseSensitiveCommands_SelectedIndexChanged(Object sender, EventArgs e)
		{
			var val = Boolean.Parse(CaseSensitiveCommands.SelectedItem as string);
			newConfig.CommandServiceConfig.CaseSensitiveCommands = val;
			if (prevConfig.CommandServiceConfig.CaseSensitiveCommands != val)
			{
				newConfig.CommandServiceConfig.CaseSensitiveCommandsChanged = true;
			}
			else
			{
				newConfig.CommandServiceConfig.CaseSensitiveCommandsChanged = false;
			}
			AppendStar(CaseSensitiveCommandsLabel, CaseSensitiveCommands, newConfig.CommandServiceConfig.CaseSensitiveCommandsChanged);
		}

		private void DefaultRunMode_SelectedIndexChanged(Object sender, EventArgs e)
		{
			void Change(RunMode mode)
			{
				newConfig.CommandServiceConfig.DefaultRunMode = mode;
				if (prevConfig.CommandServiceConfig.DefaultRunMode != mode)
				{
					newConfig.CommandServiceConfig.DefaultRunModeChanged = true;
				}
				else
				{
					newConfig.CommandServiceConfig.DefaultRunModeChanged = false;
				}
				AppendStar(DefaultRunModeLabel, DefaultRunMode, newConfig.CommandServiceConfig.DefaultRunModeChanged);
			}
			switch (DefaultRunMode.SelectedItem as string)
			{
				case "Async":
				{
					Change(RunMode.Async);
					return;
				}
				case "Sync":
				{
					Change(RunMode.Sync);
					return;
				}
				case "Default":
				case "":
				default:
				{
					Change(RunMode.Default);
					return;
				}
			}
		}

		private void IgnoreExtraArgs_SelectedIndexChanged(Object sender, EventArgs e)
		{
			var val = Boolean.Parse(IgnoreExtraArgs.SelectedItem as string);
			newConfig.CommandServiceConfig.IgnoreExtraArgs = val;
			if (prevConfig.CommandServiceConfig.IgnoreExtraArgs != val)
			{
				newConfig.CommandServiceConfig.IgnoreExtraArgsChanged = true;
			}
			else
			{
				newConfig.CommandServiceConfig.IgnoreExtraArgsChanged = false;
			}
			AppendStar(IgnoreExtraArgsLabel, IgnoreExtraArgs, newConfig.CommandServiceConfig.IgnoreExtraArgsChanged);
		}

		private void LogLevel_SelectedIndexChanged(Object sender, EventArgs e)
		{
			void Change(LogS mode)
			{
				newConfig.CommandServiceConfig.LogLevel = mode;
				if (prevConfig.CommandServiceConfig.LogLevel != mode)
				{
					newConfig.CommandServiceConfig.LogLevelChanged = true;
				}
				else
				{
					newConfig.CommandServiceConfig.LogLevelChanged = false;
				}
				AppendStar(LogLevelLabel, LogLevel, newConfig.CommandServiceConfig.LogLevelChanged);
			}
			switch (LogLevel.SelectedItem as string)
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
				case "Info":
				case "":
				default:
				{
					Change(LogS.Info);
					return;
				}
			}
		}

		private void SeparatorChar_TextChanged(Object sender, EventArgs e)
		{
			if (SeparatorChar.Text.Length == 1)
			{
				var val = SeparatorChar.Text.ToCharArray()[0];
				newConfig.CommandServiceConfig.SeparatorChar = val;
				if (prevConfig.CommandServiceConfig.SeparatorChar != val)
				{
					newConfig.CommandServiceConfig.SeparatorCharChanged = true;
				}
				else
				{
					newConfig.CommandServiceConfig.SeparatorCharChanged = false;
				}
				AppendStar(SeparatorCharLabel, SeparatorChar, newConfig.CommandServiceConfig.SeparatorCharChanged);
			}
			else
			{
				AppendStar(SeparatorCharLabel, SeparatorChar, true);
			}
		}

		private void ThrowOnError_SelectedIndexChanged(Object sender, EventArgs e)
		{
			var val = Boolean.Parse(ThrowOnError.SelectedItem as string);
			newConfig.CommandServiceConfig.ThrowOnError = val;
			if (prevConfig.CommandServiceConfig.ThrowOnError != val)
			{
				newConfig.CommandServiceConfig.ThrowOnErrorChanged = true;
			}
			else
			{
				newConfig.CommandServiceConfig.ThrowOnErrorChanged = false;
			}
			AppendStar(ThrowOnErrorLabel, ThrowOnError, newConfig.CommandServiceConfig.ThrowOnErrorChanged);
		}

		private void SaveButton_Click(Object sender, EventArgs e)
		{
			ConfirmationBox box = new ConfirmationBox();
			box.StartPosition = FormStartPosition.CenterParent;
			var r = box.ShowDialog(this);
			var config = newConfig.GenerateConfig();
			Discord.DiscordInitializer.UpdateConfig(config, r == DialogResult.Yes);
			box.Dispose();
		}
	}
}
