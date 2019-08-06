using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Momiji.Bot.V3.Modules.Embed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	[Group("Events")]
	public class EventReminderCommands : CommandBase
	{
		public EventReminders eventReminders { get; set; }
		public List<Reminder> Data { get => eventReminders.tempXmlObject.Data; }

		/*[Command("HappyBirthday")]
		[GUID("be65e91d-142d-4e62-84e7-d054f944eee2")]
		public async Task HappyBirthday(ISocketMessageChannel channel, IGuildUser user)
		{
			XMLEmbed embed = new XMLEmbed()
			{
				Color = Color.Purple,
				Description = "A wish for you on your birthday,\n" +
								"whatever you ask may you receive,\n" +
								"whatever you seek may you find,\n" +
								"whatever you wish may it be fulfilled\n" +
								"on your birthday and always.",
				Title = "Happy Birthday {user.nickname}",
			};
			Embed e = embed.GetEmbed(Context.Client.CurrentUser, user, new Dictionary<string, string>());
			await channel.SendMessageAsync(user.Mention, false, e);
		}*/
		
		[Command("DeleteEvent")]
		[Alias("Delete Event", "Remove Event")]
		[Summary("Removes event reminder.")]
		[Remarks("<event id>")]
		[GUID("053770d5-0d9d-44c6-84ed-de3b139538aa")]
		[RequireUserPermission(GuildPermission.ManageChannels)]
		public async Task RemoveEvent(long eventId)
		{
			var reminders = Data.Where(r => r.EventId == eventId);
			foreach (var reminder in reminders)
			{
				await reminder.Expire(eventReminders.GetDiscordSocketClient());
			}
			var removed = Data.RemoveAll(r => r.EventId == eventId);
			if (removed > 0)
			{
				await Context.Channel.SendMessageAsync($"Event reminder{(removed != 1 ? "s" : "")} with ID {eventId} {(removed != 1 ? "was" : "were")} successfuly deleted.");
			}
		}

		[Command("AddEvent")]
		[Alias("Add Event")]
		[Summary("Adds new event to event reminder.")]
		[Remarks("<start date> <midway date> <end date> <event name> [bannerUrl] [channelId] [Normal/NonRanked] \nMidway date can be empty string, and must be in PDT or PST. Date must be provided in ISO 8601 format")]
		[GUID("2ed63712-dd98-415a-a2ee-fbdd0f65414e")]
		[RequireUserPermission(GuildPermission.ManageMessages)]
		public async Task AddEvent(string startDate, string midwayDate, string endDate, string eventName, string bannerUrl = "", ISocketMessageChannel channel = null, string eventType = "Normal")
		{
			try
			{
				var attachment = Context.Message.Attachments.FirstOrDefault();
				channel = channel ?? Context.Channel;
				var url = bannerUrl != "" ? bannerUrl : null;
				var sDate = DateTime.Parse(startDate);
				var mDate = DateTime.MinValue;
				if (midwayDate != "")
				{
					TimeZoneInfo info = TimeZoneInfo.Utc;
					if (midwayDate.Contains("PST") || midwayDate.Contains("PDT"))
					{
						midwayDate = midwayDate.Replace("PST", "").Replace("PDT", "");
						info = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
					}
					var tempDate = DateTime.Parse(midwayDate);
					mDate = TimeZoneInfo.ConvertTimeToUtc(tempDate, info);
				}
				var eDate = DateTime.Parse(endDate);
				EventType type = EventType.Normal;
				Enum.TryParse(eventType, true, out type);
				var newId = (Data.Count > 0) ? Data.Select(reminder => reminder.EventId).Max() + 1 : 1;
				if (!((sDate < mDate && mDate < eDate && mDate > DateTime.MinValue) || (sDate < eDate && mDate == DateTime.MinValue)))
				{
					await Context.Channel.SendMessageAsync("Cannot create event with wrong dates!");
					return;
				}
				else
				{
					if (type == EventType.RPS)
					{
						return;
					}
					Reminder temp = new Reminder()
					{
						ChannelId = channel.Id,
						Name = eventName,
						Action = EventAction.Start,
						StartDate = sDate.AddDays(-1),
						TriggerDate = sDate,
						EventId = newId,
						ImageUrl = attachment?.Url ?? url ?? "",
						After = AfterReminder.Delete | AfterReminder.Unpin | AfterReminder.AfterTime,
						AfterTime = AfterReminderTime.After24Hours,
					};
					Data.Add(temp);
					if (mDate > DateTime.MinValue)
					{
						temp = new Reminder()
						{
							ChannelId = channel.Id,
							Name = eventName,
							Action = EventAction.End,
							StartDate = mDate.AddDays(-1),
							TriggerDate = mDate,
							EventId = newId,
							ImageUrl = attachment?.Url ?? url ??"",
							After = AfterReminder.Delete | AfterReminder.Unpin | AfterReminder.AfterTime,
							AfterTime = AfterReminderTime.After12Hours,
						};
						Data.Add(temp);
					}
					temp = new Reminder()
					{
						ChannelId = channel.Id,
						Name = eventName,
						StartDate = eDate.AddDays(-3),
						Action = EventAction.End,
						TriggerDate = eDate,
						Info = "Final Fever active!",
						EventId = newId,
						ImageUrl = attachment?.Url ?? url ?? "",
						After = AfterReminder.Delete | AfterReminder.Unpin | AfterReminder.AfterTime,
						AfterTime = AfterReminderTime.After12Hours,
					};
					Data.Add(temp);
					await eventReminders.ResaveResources();
				}
				#region XMLEmbed embed = ...
				XmlEmbed embed = new XmlEmbed()
				{
					Color = Color.Green,
					Title = $"Event \"{eventName}\" added succesfully\nEvent id: \"{newId}\"",
					Fields = new List<XmlEmbedField>()
					{
						new XmlEmbedField()
						{
							Inline = true,
							Name = "Start Date",
							Value = sDate.ToString(),
						},
						((mDate > DateTime.MinValue) ?
						new XmlEmbedField()
						{
							Inline = true,
							Name = "Midway Date",
							Value = mDate.ToString(),
						}
						: null)
						,
						new XmlEmbedField()
						{
							Inline = true,
							Name = "End Date",
							Value = eDate.ToString(),
						},
						new XmlEmbedField()
						{
							Inline = false,
							Name = "Event Type",
							Value = Enum.GetName(typeof(EventType), type),
						}
					},
					Image = ((attachment?.Url ?? url) != null ?
					(attachment?.Url != null) ? new XmlEmbedImage() { Type = XmlEmbedImageType.File, Url = attachment.Url } :
					new XmlEmbedImage() { Type = XmlEmbedImageType.URL, Url = url }
					: null),
				};
				var message = await Context.Channel.SendMessageAsync("", false, embed.GetEmbed(Context.Client.CurrentUser, Context.User, new Dictionary<string, string>()));
				#endregion
			}
			catch (Exception ex)
			{
				eventReminders.LogMessage(ex.ToString());
			}
		}

		[Command("EditEventImage")]
		[Alias("Edit Event Image", "EditImage")]
		[Summary("Edits image in selected event.")]
		[Remarks("<eventName> <image as attachment>")]
		[GUID("2ed63712-dd98-415a-a2ee-fbdd0f65414e")]
		[RequireUserPermission(GuildPermission.ManageMessages)]
		public async Task EditEventImage(long eventId)
		{
			var attachment = Context.Message.Attachments.FirstOrDefault();
			var reminders = Data.Where(r => r.EventId == eventId);
			foreach (var reminder in reminders)
			{
				reminder.ImageUrl = attachment?.Url ?? "";
			}
			await eventReminders.SaveResources();
			await Context.Channel.SendMessageAsync("Images edited\nNew Url: " + attachment?.Url ?? "");
		}

		[Command("EditEventImage")]
		[Alias("Edit Event Image", "EditImage")]
		[Summary("Edits image in selected event.")]
		[Remarks("<eventName> <image url>")]
		[GUID("56a3df6c-26a7-4e42-9fea-01c4d24a284b")]
		[RequireUserPermission(GuildPermission.ManageMessages)]
		public async Task EditEventImage(long eventId, string url = "")
		{
			var reminders = Data.Where(r => r.EventId == eventId);
			foreach (var reminder in reminders)
			{
				reminder.ImageUrl = url;
			}
			await eventReminders.SaveResources();
			await Context.Channel.SendMessageAsync("Images edited\nNew Url: " + url ?? "");
		}
	}
}
