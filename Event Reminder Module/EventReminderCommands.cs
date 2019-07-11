using Discord.Commands;
using Momiji.Bot.V3.Modules.Embed;
using Momiji.Bot.V5.Core.InternalServer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	[Group("Events")]
	public class EventReminderCommands : CommandBase
	{
		public EventReminders eventReminders { get; set; }
		
		public Reminder Data { get => eventReminders.xmlObject.Data; }
		public IConsole console { get; set; }
		
		[Command("T")]
		[GUID("4e470863-8a4b-472f-aaae-0ac3a3956bb4")]
		public async Task T()
		{
			string getTimeText(Event e) {
				var timeSpan = (e.StartDate - DateTime.UtcNow);
				if (timeSpan.TotalMinutes >= 60)
				{
					return ((int) timeSpan.TotalHours) + " hour" + (timeSpan.TotalHours == 1 ? "" : "s");
				}
				else
				{
					return ((int) timeSpan.TotalMinutes) + " minute" + (timeSpan.TotalMinutes == 1 ? "" : "s");
				}
			}

			var dictionary = new Dictionary<string, string>()
			{
				{ "{EventName}", Data.Events[0].EventName },
				{ "{timeText}", getTimeText(Data.Events[0]) },
				{ "{HTMl.EventName}", Data.Events[0].EventName.Replace(" ", "%20") },
				{ "{HTML.Time}", Data.Events[0].StartDate.ToString("yyyyMMddTHHmmss") }
			};
			await Context.Channel.SendMessageAsync("", false, eventReminders.xmlEmbedObject.Data.GetEmbed(Context.Client.CurrentUser, Context.User, dictionary));
		}

		[Command("AddEvent")]
		[Alias("Add Event")]
		[Summary("Adds new event to event reminder. <start date> <midway date> <endDate> <eventName> [Normal/NonRanked/RPS]\nMidway date can be empty string")]
		[GUID("2ed63712-dd98-415a-a2ee-fbdd0f65414e")]
		[RequireUserPermission(Discord.GuildPermission.ManageMessages)]
		public async Task AddEvent(string startDate, string midwayDate, string endDate, string eventName, string eventType = "Normal")
		{
			try
			{
				var sDate = DateTime.Parse(startDate);
				var mDate = midwayDate == "" ? DateTime.MinValue : DateTime.Parse(midwayDate);
				var eDate = DateTime.Parse(endDate);
				EventType type = EventType.Normal;
				Enum.TryParse(eventType, true, out type);
				if (!((sDate < mDate && mDate < eDate && mDate > DateTime.MinValue) || (sDate < eDate && mDate == DateTime.MinValue)))
				{
					await Context.Channel.SendMessageAsync("Cannot create event with wrong dates!");
				}
				else
				{
					Event e = new Event();
					e.StartDate = sDate;
					e.MidwayDate = mDate;
					e.EndDate = eDate;
					e.EventName = eventName;
					e.EventType = type;
					eventReminders.xmlObject.Data.Events.Add(e);
					await eventReminders.SaveResources();
					XMLEmbed embed = new XMLEmbed()
					{
						Color = Discord.Color.Green,
						Title = $"Event \"{eventName}\" added succesfully",
						Fields = new List<XMLEmbedField>()
						{
							new XMLEmbedField()
							{
								Inline = true,
								Name = "Start Date",
								Value = sDate.ToString(),
							},
							(mDate > DateTime.MinValue) ?
							new XMLEmbedField()
							{
								Inline = true,
								Name = "Midway Date",
								Value = mDate.ToString(),
							}
							: null
							,
							new XMLEmbedField()
							{
								Inline = true,
								Name = "End Date",
								Value = eDate.ToString(),
							},
							new XMLEmbedField()
							{
								Inline = false,
								Name = "Event Type",
								Value = Enum.GetName(typeof(EventType), type),
							}
						},
					};
					await Context.Channel.SendMessageAsync("", false, embed.GetEmbed(Context.Client.CurrentUser, Context.User, new Dictionary<string, string>()));
				}
			}
			catch (Exception ex)
			{
				eventReminders.LogMessage(ex.ToString());
			}
		}
	}
}
