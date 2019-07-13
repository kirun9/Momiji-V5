using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Momiji.Bot.V3.Modules.Embed;
using Momiji.Bot.V3.Serialization.XmlSerializer;
using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.Modules.Interface;
using Momiji.Bot.V5.Modules.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class EventReminders : MomijiModuleBase, ICommandModule, ITimerEvents, IExternalResources
	{
		#region Module Initialization ...
		public override string ModuleName { get; } = "Event Reminder";
		public override Guid Guid { get; } = new Guid("68081921-f7bc-4b1f-8e73-eb0ec32fbadd");

		public EventReminders() { }
		public EventReminders(Guid callerGuid, IConsole console) : base(callerGuid, console) { }

		public void LogMessage(string message) => Log(message);

		#region Initialize methods
		public override Task Initialize()
		{
			return Task.CompletedTask;
		}
		public override Task PostInitialize() => Task.CompletedTask;
		public override Task PreInitialize() => Task.CompletedTask;
		#endregion
		#endregion

		#region ICommandModule ...
		public Type GetCommandClass() => typeof(EventReminderCommands);
		#endregion

		#region ITimerEvents

		public async void OnTimer(TimerType type)
		{
			if (type == TimerType.On10Seconds)
			{
				List<Reminder> toRemove = new List<Reminder>();
				foreach (var e in tempXmlObject.Data)
				{
					if (e.StartDate <= DateTime.UtcNow)
					{
						var timeSpan = (e.TriggerDate - DateTime.UtcNow);
						if (e.MinutesLeft > (int)Math.Ceiling(timeSpan.TotalMinutes) || e.MinutesLeft <= 0)
						{
							e.MinutesLeft = (int) Math.Ceiling(timeSpan.TotalMinutes);
							var channel = GetDiscordSocketClient().GetChannel(e.ChannelId) as ISocketMessageChannel;
							var bot = GetDiscordSocketClient().CurrentUser;
							var time = (timeSpan.TotalMinutes > 90 ? (int) Math.Ceiling(timeSpan.TotalHours) : (int) Math.Ceiling(timeSpan.TotalMinutes));
							var timeunit = (timeSpan.TotalMinutes > 90 ? "hour" : "minute") + (time == 1 ? "" : "s");
							var dictionary = new Dictionary<string, string>()
							{
								{ "{eventname}", e.Name },
								{ "{action}" , (e.Action == EventAction.Start ? "Start" : (e.Action == EventAction.End ? "End" : "End")) },
								{ "{action2}", (e.Action == EventAction.Start ? "started" : (e.Action == EventAction.End ? "ended" : "ended")) },
								{ "{time}", time + "" },
								{ "{unit}", timeunit },
								{ "{info}", e.Info },
								{ "{HTMl.EventName}", e.Name.Replace(" ", "%20") },
								{ "{HTML.Time}", e.TriggerDate.ToString("yyyyMMddTHHmmss") },
							};
							IUserMessage message;
							if (e.MessageId == 0)
							{
								message = await channel.SendMessageAsync("", false, xmlEmbedObject.Data.GetEmbed(bot, bot, dictionary));
							}
							else
							{
								message = await channel.GetMessageAsync(e.MessageId, CacheMode.AllowDownload) as IUserMessage;
							}
							e.MessageId = message.Id;
							await message.ModifyAsync((f) => {
								EmbedBuilder builder = (new List<IEmbed>(message.Embeds)[0] as Embed).GetEmbedBuilder();
								builder.Description = (e.MinutesLeft > 0 ? "{action} in **{time}** {unit}\n{info}" : "This event has {action2}!");
								foreach (var entry in dictionary)
								{
									builder.Description = builder.Description.Replace("{" + entry.Key.Trim('{', '}') + "}", entry.Value);
								}
								f.Embed = builder.Build();
							});
							await SaveResources();
						}
					}
				}
				var i = tempXmlObject.Data.RemoveAll((elem) => { return elem.TriggerDate < DateTime.UtcNow; });
				if (i > 0)
				{
					await SaveResources();
				}
			}
		}
		#endregion

		#region IExternalResources ...

		public XmlObject<List<Reminder>> tempXmlObject = new XmlObject<List<Reminder>>()
		{
			Data = new List<Reminder>(),
		};

		public XmlSerializerConfig<List<Reminder>> tempSerializerConfig = new XmlSerializerConfig<List<Reminder>>()
		{
			Directory = "data",
			FileName = "EventTemp.xml",
		};
		public XmlObject<XMLEmbed> xmlEmbedObject = new XmlObject<XMLEmbed>()
		{
			Data = new XMLEmbed()
			{
				Color = 0x0ABCDE,
				Title = "{eventname}",
				Description = "{action} in **{time}** {unit}\n{info}",
				Fields = new List<XMLEmbedField>()
				{
					new XMLEmbedField()
					{
						Name = "*Check your local timezone*",
						Value = "*[Click Here](https://www.timeanddate.com/worldclock/fixedtime.html?msg={HTMl.EventName}&iso={HTML.Time})*",
					}
				},
			}
		};
		public XmlSerializerConfig<XMLEmbed> embedConfig = new XmlSerializerConfig<XMLEmbed>()
		{
			Directory = "embed",
			FileName = "EventReminders.xml",
		};

		public Task LoadResources()
		{
			tempXmlObject = XmlSerializer.Load(tempSerializerConfig, tempXmlObject);
			xmlEmbedObject = XmlSerializer.Load(embedConfig, xmlEmbedObject);
			return Task.CompletedTask;
		}
		public Task ReloadResources()
		{
			tempXmlObject = XmlSerializer.Load(tempSerializerConfig);
			xmlEmbedObject = XmlSerializer.Reload(embedConfig);
			return Task.CompletedTask;
		}
		public Task ResaveResources()
		{
			XmlSerializer.ReSave(tempSerializerConfig, tempXmlObject);
			XmlSerializer.ReSave(embedConfig, xmlEmbedObject);
			return Task.CompletedTask;
		}
		public Task SaveResources()
		{
			XmlSerializer.Save(tempSerializerConfig, tempXmlObject);
			XmlSerializer.Save(embedConfig, xmlEmbedObject);
			return Task.CompletedTask;
		}
		public String ResourcePath() => @".\data\EventReminders.xml";
		#endregion


		public void SortEvents()
		{
			tempXmlObject.Data.Sort((a, b) => {
				var now = DateTime.UtcNow;
				return ((int) ((a.TriggerDate - now) - (b.TriggerDate - now)).TotalMinutes);
			});
		}
	}
}
