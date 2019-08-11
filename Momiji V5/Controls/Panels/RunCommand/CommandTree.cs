using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Commands;
using Momiji.Bot.V5.Modules;

namespace Momiji.Bot.V5.Core.Controls.Panels.RunCommand
{
	public partial class CommandTree : UserControl
	{
		public CommandTree()
		{
			InitializeComponent();
		}

		public void FillDiscordServers()
		{
			var client = Discord.DiscordInitializer.Instance.DiscordSocketClient;
			DiscordServer.Items.Clear();
			foreach (var server in client.Guilds)
			{
				DiscordServer.Items.Add(new CommandTreeItem(server.Name, server.Id));
			}
			DiscordServer.Enabled = DiscordServer.Items.Count > 0;
			ServerChannel.Enabled = true;
			ServerChannel.Items.Clear();
			ChannelUser.Enabled = false;
			ChannelUser.Items.Clear();
			ExecuteButton.Enabled = false;
			CheckCommand();
		}

		private void DiscordServer_SelectedIndexChanged(Object sender, EventArgs e)
		{
			var selectedServer = DiscordServer.SelectedItem as CommandTreeItem;

			var client = Discord.DiscordInitializer.Instance.DiscordSocketClient;
			var guild = client.GetGuild(selectedServer.Id);
			ServerChannel.Items.Clear();
			foreach (var channel in guild.TextChannels)
			{
				var channelName = channel.Category.Name + " #" + channel.Name;
				ServerChannel.Items.Add(new CommandTreeItem(channelName, channel.Id));
			}
			ServerChannel.Enabled = true;
			ChannelUser.Enabled = false;
			ChannelUser.Items.Clear();
			CheckCommand();
		}

		private void ServerChannel_SelectedIndexChanged(Object sender, EventArgs e)
		{
			var selectedChannel = ServerChannel.SelectedItem as CommandTreeItem;
			var client = Discord.DiscordInitializer.Instance.DiscordSocketClient;
			var channel = client.GetChannel(selectedChannel.Id);
			foreach (var user in channel.Users)
			{
				var nickname = (user is global::Discord.WebSocket.SocketGuildUser gUser ? (gUser.Nickname != null ? $"{gUser.Nickname} ({gUser.Username})" : gUser.Username) : user.Username); 
				ChannelUser.Items.Add(new CommandTreeItem(nickname, user.Id));
			}
			ChannelUser.Enabled = true;
			CheckCommand();
		}

		private void CheckCommand()
		{
			ExecuteButton.Enabled = (Command.Text != "" ? (ServerChannel.SelectedItem != null) : false);
		}

		private void Command_TextChanged(Object sender, EventArgs e)
		{
			CheckCommand();
		}

		private void ExecuteButton_Click(Object sender, EventArgs e)
		{
			var discord = Discord.DiscordInitializer.Instance;
			var user = (ChannelUser.SelectedItem != null ? discord.DiscordSocketClient.GetUser((ChannelUser.SelectedItem as CommandTreeItem).Id) : discord.DiscordSocketClient.CurrentUser);
			var context = new CommandContext()
			{
				Channel = discord.DiscordSocketClient.GetChannel((ServerChannel.SelectedItem as CommandTreeItem).Id) as IMessageChannel,
				Guild = discord.DiscordSocketClient.GetGuild((DiscordServer.SelectedItem as CommandTreeItem).Id),
				Client = discord.DiscordSocketClient,
				User = user,
				Message = null,
			};
			var search = discord.CommandService.Search(context, Command.Text);
			if (search.IsSuccess)
			{
				var commandInfo = search.Commands[0].Command;
				foreach (var attribute in commandInfo.Attributes)
				{
					if (attribute is GUIDAttribute guidAttribue)
					{
						foreach (var command in Config.Settings.Config.GetCommands())
						{
							if (command.Guid == guidAttribue.Guid)
							{
								if (!command.ConfigModule.Enabled)
								{
									context.Channel.SendMessageAsync("Sorry, but that module was disabled");
									return;
								}
								else
								{
									if (!command.Enabled)
									{
										context.Channel.SendMessageAsync("Sorry, but that command was disabled");
										//Log("Command Disabled");
										return;
									}
								}
								//ExcelDatabase.CommandExecuted(command.Guid, context.User);
								break;
							}
						}
						break;
					}
				}
			}

			try
			{
				var result = discord.CommandService.ExecuteAsync(context, Command.Text, MomijiHeart.ServiceProvider).Result;
				if (!result.IsSuccess)
				{
					if (result is ExecuteResult executeResult)
					{
						var ex = executeResult.Exception;
						//Log(context.User, $"Exception in {ex.TargetSite.DeclaringType.FullName} inside inside {ex.TargetSite.DeclaringType.Assembly.GetName().Name}:" +
						//	$"\n{this.GetType().FullName}: {ex.Message}\nCommand: {message.Content}\nBy: {context.User.Username}\nChannel: {context.Channel.Name}\n\n", ex, InternalServer.ConsoleMessageType.Warning);
						context.Channel.SendMessageAsync($"Sorry. I couldn't handle that.\nPlease ask <@332164161129938944> for help. :worried:\nApproximated problem: {executeResult.ErrorReason} ({Enum.GetName(typeof(CommandError), (executeResult.Error.Value))})");
					}
					else
					{
						//Log(context.User, $"Approximated problem: {result.ErrorReason} ({ Enum.GetName(typeof(CommandError), (result.Error.Value))})", null, InternalServer.ConsoleMessageType.Warning);
						context.Channel.SendMessageAsync($"Sorry. I couldn't handle that.\nPlease ask <@332164161129938944> for help. :worried:\nApproximated problem: {result.ErrorReason} ({Enum.GetName(typeof(CommandError), (result.Error.Value))})");
					}
				}
			}
			catch (Exception ex)
			{
				//Log(context.User, $"Exception in {ex.TargetSite.DeclaringType.FullName} inside {ex.TargetSite.DeclaringType.Assembly.GetName().Name}:" +
				//	$"\n{this.GetType().FullName}: {ex.Message}\nCommand: {message.Content}\nBy:      {context.User.Username}\nChannel: {context.Channel.Name}\n\n", ex, InternalServer.ConsoleMessageType.Warning);
				context.Channel.SendMessageAsync("Sorry. I couldn't handle that.\nPlease ask <@332164161129938944> for help. :worried:");
			}
		}
	}
	internal class CommandContext : ICommandContext
	{
		public IDiscordClient Client { get; internal set; }

		public IGuild Guild { get; internal set; }

		public IMessageChannel Channel { get; internal set; }

		public IUser User { get; internal set; }

		public IUserMessage Message { get; internal set; }
	}
}
