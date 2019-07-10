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
		public IConsole console { get; set; }
		
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
