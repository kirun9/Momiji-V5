using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Momiji.Bot.V3.Modules.Embed;
using Momiji.Bot.V3.Modules.Embed.Extensions;
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
				IEnumerable<Reminder> reminders = tempXmlObject.Data.Where(r => r.StartDate <= DateTime.UtcNow && r.MessageId == 0 && r.TriggerDate >= DateTime.UtcNow);
				foreach (var reminder in reminders)
				{
					var timeSpan = (reminder.TriggerDate - DateTime.UtcNow);
					reminder.MinutesLeft = (int)Math.Ceiling(timeSpan.TotalMinutes);
					var channel = GetDiscordSocketClient().GetChannel(reminder.ChannelId) as ISocketMessageChannel;
					var bot = GetDiscordSocketClient().CurrentUser;
					var time = (timeSpan.TotalMinutes > 90 ? (int)Math.Ceiling(timeSpan.TotalHours) : (int)Math.Ceiling(timeSpan.TotalMinutes));
					var timeunit = (timeSpan.TotalMinutes > 90 ? "hour" : "minute") + (time == 1 ? "" : "s");
					var dictionary = new Dictionary<string, string>()
					{
						{ "{eventname}", reminder.Name },
						{ "{action}" , (reminder.Action == EventAction.Start ? "Start" : (reminder.Action == EventAction.End ? "Ends" : (reminder.Action == EventAction.MidwayEnd ? "Midway ends" : "Ends"))) },
						{ "{action2}", (reminder.Action == EventAction.Start ? "started" : (reminder.Action == EventAction.End ? "ended" : (reminder.Action == EventAction.MidwayEnd ? "Midway ended" : "ended"))) },
						{ "{time}", time + "" },
						{ "{unit}", timeunit },
						{ "{info}", reminder.Info },
						{ "{HTML.EventName}", reminder.Name.Replace(" ", "%20") },
						{ "{HTML.Time}", reminder.TriggerDate.ToString("yyyy-MM-ddTHH:mm:ss") },
						{ "{HTML.Action}",  (reminder.Action == EventAction.Start ? "s" : (reminder.Action == EventAction.End ? "e" : (reminder.Action == EventAction.MidwayEnd ? "me" : "e"))) },
						{ "{HTML.EventId}", reminder.DgfEventId + "" },
						{ "{ImageUrl}" , reminder.ImageUrl },
					};
					var message = await channel.SendMessageAsync("", false, xmlEmbedObject.Data.GetEmbed(bot, bot, dictionary));
					reminder.MessageId = message.Id;
					if (reminder.After.HasFlag(AfterReminder.Unpin))
					{
						await message.PinAsync();
					}
					foreach (var expired in tempXmlObject.Data.Where(r => r.After.HasFlag(AfterReminder.OnNewReminder)))
					{
						await expired.Expire(GetDiscordSocketClient());
					}
					await SaveResources();
				}

				reminders = tempXmlObject.Data.Where((r) =>
				{
					var timeSpan = (r.TriggerDate - DateTime.UtcNow);
					var minutesLeft = (int)Math.Ceiling(timeSpan.TotalMinutes);
					var value = (r.StartDate < DateTime.UtcNow && r.MessageId != 0 && r.TriggerDate >= DateTime.UtcNow)
					&& ((r.MinutesLeft > 90 && r.MinutesLeft % 60 == 0) ? (r.MinutesLeft != minutesLeft) : (r.MinutesLeft <= 90 && r.MinutesLeft != minutesLeft));
					if (r.MinutesLeft != minutesLeft)
					{
						r.MinutesLeft = minutesLeft;
					}
					return value;
				});
				foreach (var reminder in reminders)
				{
					var timeSpan = (reminder.TriggerDate - DateTime.UtcNow);
					reminder.MinutesLeft = (int)Math.Ceiling(timeSpan.TotalMinutes);
					var channel = GetDiscordSocketClient().GetChannel(reminder.ChannelId) as ISocketMessageChannel;
					var message = await channel.GetMessageAsync(reminder.MessageId, CacheMode.AllowDownload) as IUserMessage;
					if (message is null)
					{
						reminder.MessageId = 0;
						continue;
					}
					var bot = GetDiscordSocketClient().CurrentUser;
					var time = (timeSpan.TotalMinutes > 90 ? (int)Math.Ceiling(timeSpan.TotalHours) : (int)Math.Ceiling(timeSpan.TotalMinutes));
					var timeunit = (timeSpan.TotalMinutes > 90 ? "hour" : "minute") + (time == 1 ? "" : "s");
					var dictionary = new Dictionary<string, string>()
					{
						{ "{eventname}", reminder.Name },
						{ "{action}" , (reminder.Action == EventAction.Start ? "Start" : (reminder.Action == EventAction.End ? "Ends" : (reminder.Action == EventAction.MidwayEnd ? "Midway ends" : "Ends"))) },
						{ "{action2}", (reminder.Action == EventAction.Start ? "started" : (reminder.Action == EventAction.End ? "ended" : (reminder.Action == EventAction.MidwayEnd ? "Midway ended" : "ended"))) },
						{ "{time}", time + "" },
						{ "{unit}", timeunit },
						{ "{info}", reminder.Info },
						{ "{HTML.EventName}", reminder.Name.Replace(" ", "%20") },
						{ "{HTML.Time}", reminder.TriggerDate.ToString("yyyy-MM-ddTHH:mm:ss") },
						{ "{HTML.Action}",  (reminder.Action == EventAction.Start ? "s" : (reminder.Action == EventAction.End ? "e" : (reminder.Action == EventAction.MidwayEnd ? "me" : "e"))) },
						{ "{HTML.EventId}", reminder.DgfEventId + "" },
						{ "{ImageUrl}" , reminder.ImageUrl },
					};
					await message.ModifyAsync((m) => {
						var builder = (new List<IEmbed>(message.Embeds)[0] as Embed).GetEmbedBuilder();
						builder.Description = (reminder.MinutesLeft > 0 ? "{action} in **{time}** {unit}\n{info}" : "This event has {action2}!");
						foreach (var entry in dictionary)
						{
							builder.Description = builder.Description.Replace("{" + entry.Key.Trim('{', '}') + "}", entry.Value);
						}
						m.Embed = builder.Build();
					});
					await SaveResources();
				}
				
				var remindersToRemove = tempXmlObject.Data.Where(e => e.ExpirationDate < DateTime.UtcNow);
				foreach (var reminder in remindersToRemove)
				{
					await reminder.Expire(GetDiscordSocketClient());
					await SaveResources();
				}
				var removed = tempXmlObject.Data.RemoveAll(e => e.ExpirationDate < DateTime.UtcNow);
				if (removed > 0)
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
		public XmlObject<XmlEmbed> xmlEmbedObject = new XmlObject<XmlEmbed>()
		{
			Data = new XmlEmbed()
			{
				Color = 0x0ABCDE,
				Title = "{eventname}",
				Description = "{action} in **{time}** {unit}\n{info}",
				Fields = new List<XmlEmbedField>()
				{
					new XmlEmbedField()
					{
						Name = "*Check your local timezone*",
						Value = "*[Click Here](http://momiji.website/time.html?datetime={HTML.Time}&eventname={HTML.EventName}&action={HTML.Action}&eventId={HTML.EventId})*",
					}
				},
				Image = new XmlEmbedImage()
				{
					Type = XmlEmbedImageType.URL,
					Url = "{ImageUrl}",
				},
			}
		};
		public XmlSerializerConfig<XmlEmbed> embedConfig = new XmlSerializerConfig<XmlEmbed>()
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
	}
}
