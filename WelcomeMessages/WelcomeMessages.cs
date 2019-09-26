using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.Modules.Interface;
using Momiji.Bot.V3.Serialization.XmlSerializer;
using System;
using System.Threading.Tasks;
using Momiji.Bot.V3.Modules.Embed;
using Discord.WebSocket;
using Discord.Commands;

namespace Momiji.Bot.V5.Modules.WelcomeMessages
{
	public class WelcomeMessages : MomijiModuleBase, ICommandModule, IExternalResources
	{
		public override string ModuleName { get; } = "WelcomeMessages";
		public override Guid Guid { get; } = new Guid("41126c1d-ca80-47d9-ac54-2b4bd4508800");

		public WelcomeMessages() : base() { }
		public WelcomeMessages(Guid callerGuid, IConsole console) : base(callerGuid, console) { }

		public override Task Initialize()
		{
			var client = GetDiscordSocketClient();
			client.UserJoined += async (user) => {
				if (user.IsBot || user.IsWebhook) return;
				await user.Guild.SystemChannel.SendMessageAsync("", false, xmlEmbed.Data.GetEmbed(client.CurrentUser, user, null));
			};
			return Task.CompletedTask;
		}
		public override Task PostInitialize() => Task.CompletedTask;
		public override Task PreInitialize() => Task.CompletedTask;

		internal XmlObject<XmlEmbed> xmlEmbed = new XmlObject<XmlEmbed>()
		{
			Data = new XmlEmbed()
			{
				Color = Discord.Color.Purple,
				Title = "Welcome to the **Super Secret Society's Discord** Server!",
				Description = "Hi {user.username}, welcome to the Super Secret Society Discord!\nI'm Momiji, the Group's mascot-girl. We use Discord for most of our chatting and announcements, so be sure to check here often!\nPlease note that you will have to wait until you are assigned the Member role to access the rest of the Discord server. For now, please read the posts on the #welcome channel and familiarize yourself with the rules. Feel free to ask any questions you may have, and I hope to see you around!",
				Thumbnail = new XmlEmbedImage()
				{
					Type = XmlEmbedImageType.URL,
					Url = "https://i.imgur.com/qu1OLvd.png"
				},
				Image = new XmlEmbedImage()
				{
					Type = XmlEmbedImageType.UserProfile,
				},
			}
		};

		private readonly XmlSerializerConfig<XmlEmbed> file = new XmlSerializerConfig<XmlEmbed>()
		{
			Directory = "embed",
			FileName = "WelcomeMessage.xml"
		};

		public Type GetCommandClass() => typeof(WelcomeMessagesCommands);
		public Task LoadResources()
		{
			xmlEmbed = XmlSerializer.Load(file, xmlEmbed);
			return Task.CompletedTask;
		}
		public Task SaveResources()
		{
			XmlSerializer.Save(file, xmlEmbed);
			return Task.CompletedTask;
		}

		public Task ReloadResources()
		{
			xmlEmbed = XmlSerializer.Reload(file);
			return Task.CompletedTask;
		}

		public Task ResaveResources()
		{
			XmlSerializer.ReSave(file, xmlEmbed);
			return Task.CompletedTask;
		}
		public String ResourcePath() => @".\embed\WelcomeMessage.xml";
	}

	public class WelcomeMessagesCommands : CommandBase
	{
		public WelcomeMessages welcomeMessages { get; set; }

		[Command("Show Message")]
		[GUID("e90048d1-598e-4078-8fc2-da843ee91c65")]
		public async Task ShowMessage(ISocketMessageChannel messageChannel, SocketUser user)
		{
			await messageChannel.SendMessageAsync("", false, welcomeMessages.xmlEmbed.Data.GetEmbed(Context.Client.CurrentUser, user, null));
		}
		[Command("Show Message")]
		[GUID("0e9b2719-8c11-4bfa-a6f7-63706c641043")]
		public async Task ShowMessage(SocketUser user)
		{
			await Context.Guild.SystemChannel.SendMessageAsync("", false, welcomeMessages.xmlEmbed.Data.GetEmbed(Context.Client.CurrentUser, user, null));
		}
	}
}
