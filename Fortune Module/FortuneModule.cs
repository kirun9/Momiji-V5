using Discord;
using kirun9.libs;
using Momiji.Bot.V3.Modules.Embed;
using Momiji.Bot.V3.Serialization.XmlSerializer;
using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.Modules.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.FortuneModule
{
	public class FortuneModule : MomijiModuleBase, IExternalResources, ICommandModule
	{
		private Randomizer randomizer;
		private XmlSerializerConfig<List<DailyFortune>> DailyFortuneConfig = new XmlSerializerConfig<List<DailyFortune>>()
		{
			Directory = "data",
			FileName = "fortunes.xml"
		};

		private XmlSerializerConfig<List<DailyFortuneUser>> DailyFortuneUserConfig = new XmlSerializerConfig<List<DailyFortuneUser>>()
		{
			Directory = "data",
			FileName = "fortuneUsers.xml"
		};

		private XmlSerializerConfig<XMLEmbed> EmbedConfig = new XmlSerializerConfig<XMLEmbed>()
		{
			Directory = "embed",
			FileName = "fortuneEmbed.xml",
		};

		internal XmlObject<List<DailyFortune>> Fortunes = new XmlObject<List<DailyFortune>>()
		{
			Data = new List<DailyFortune>() { new DailyFortune() { FortuneID = 1, FortuneMessage = "Test" } },
			Version = new XmlSerializerVersion("1.0.0.0")
		};

		internal XmlObject<List<DailyFortuneUser>> FortuneUsers = new XmlObject<List<DailyFortuneUser>>()
		{
			Data = new List<DailyFortuneUser>(),
			Version = new XmlSerializerVersion("1.0.0.0")
		};

		internal XmlObject<XMLEmbed> Embed = new XmlObject<XMLEmbed>()
		{
			Data = new XMLEmbed()
			{
				Color = new XmlEmbedColor(Color.Purple),
				Title = "Fortune",
				Fields = new List<XMLEmbedField>()
				{
					new XMLEmbedField()
					{
						Inline = false,
						Name = "Fortune #{fortuneNumber}",
						Value = "{fortune}",
					}
				},
				Description = "This is fortune for {user.nickname}",
			},
			Version = new XmlSerializerVersion("1.0.0.0")
		};

		public override Guid Guid { get; } = Guid.Parse("3b19494f-9ded-464c-a3ee-891a5c2da0d6");
		public override String ModuleName { get; } = "Fortunes";
		public override Version Version { get; } = new Version("1.0.0.0");
		
		public FortuneModule()
		{
		}

		public FortuneModule(Guid callerGuid, IConsole console) : base(callerGuid, console)
		{
		}

		public override async Task Initialize()
		{
			//await LoadResources();
			randomizer = new Randomizer();
			randomizer.Prepare(Fortunes.Data.Count);
		}

		public override Task PostInitialize()
		{
			return Task.CompletedTask;
		}
		public override Task PreInitialize()
		{
			return Task.CompletedTask;
		}

		public Task LoadResources()
		{
			Fortunes = XmlSerializer.Load(DailyFortuneConfig, Fortunes);
			FortuneUsers = XmlSerializer.Load(DailyFortuneUserConfig);
			Embed = XmlSerializer.Load(EmbedConfig, Embed);
			return Task.CompletedTask;
		}

		public Task SaveResources()
		{
			XmlSerializer.Save(DailyFortuneConfig, Fortunes);
			XmlSerializer.Save(DailyFortuneUserConfig, FortuneUsers);
			XmlSerializer.Save(EmbedConfig, Embed);
			return Task.CompletedTask;
		}
		public Task ReloadResources()
		{
			Fortunes = XmlSerializer.Reload(DailyFortuneConfig);
			FortuneUsers = XmlSerializer.Reload(DailyFortuneUserConfig);
			Embed = XmlSerializer.Reload(EmbedConfig);
			return Task.CompletedTask;
		}
		public Task ResaveResources()
		{
			Fortunes = XmlSerializer.ReSave(DailyFortuneConfig, Fortunes);
			FortuneUsers = XmlSerializer.ReSave(DailyFortuneUserConfig, FortuneUsers);
			Embed = XmlSerializer.ReSave(EmbedConfig, Embed);
			return Task.CompletedTask;
		}

		public String ResourcePath() => @".\data\fortunes.xml";

		public Type GetCommandClass() => typeof(FortuneCommands);

		public async Task RegisterCommands(global::Discord.Commands.CommandService service, IServiceProvider provider)
		{
			var moduleInfo = await service.AddModuleAsync(typeof(FortuneCommands), provider);
			Log(moduleInfo.ToString());
		}

		public Embed GetFortuneEmbed(ISelfUser bot, IUser user)
		{
			Dictionary<string, string> convert = new Dictionary<string, string>();
			var fUser = FortuneUsers.Data.FirstOrDefault((u) => { return u.UserID == user.Id; });
			DailyFortune f;
			if (fUser != null)
			{
				if (fUser.Time.ToUniversalTime().AddHours(2) > DateTime.UtcNow)
				{
					f = Fortunes.Data[fUser.FortuneID - 1];
					convert.Add("fortune", f.FortuneMessage);
					convert.Add("fortuneNumber", f.FortuneID + "");
				}
				else
				{
					f = Fortunes.Data[randomizer.Next];
					convert.Add("fortune", f.FortuneMessage);
					convert.Add("fortuneNumber", f.FortuneID + "");
					fUser.Time = DateTime.UtcNow;
					fUser.FortuneID = f.FortuneID;
					f.Time = DateTime.UtcNow;
				}
			}
			else
			{
				f = Fortunes.Data[randomizer.Next];
				convert.Add("fortune", f.FortuneMessage);
				convert.Add("fortuneNumber", f.FortuneID + "");
				f.Time = DateTime.UtcNow;
				fUser = new DailyFortuneUser()
				{
					FortuneID = f.FortuneID,
					UserID = user.Id,
					Time = DateTime.UtcNow,
				};
				FortuneUsers.Data.Add(fUser);
			}
			SaveResources();
			return Embed.Data.GetEmbed(bot, user, convert);
		}
	}
}
