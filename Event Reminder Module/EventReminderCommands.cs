using Discord;
using Discord.Commands;
using Discord.WebSocket;
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
		public List<Reminder> Data { get => eventReminders.tempXmlObject.Data; }

		[Command("AddEvent")]
		[Alias("Add Event")]
		[Summary("Adds new event to event reminder. <start date> <midway date> <end date> <event name> [Normal/NonRanked/RPS]\nMidway date can be empty string, and must be in PDT or PST. Date must be provided in ISO 8601 format")]
		[GUID("2ed63712-dd98-415a-a2ee-fbdd0f65414e")]
		[RequireUserPermission(Discord.GuildPermission.ManageMessages)]
		public async Task AddEvent(string startDate, string midwayDate, string endDate, string eventName, ISocketMessageChannel channel = null, string eventType = "Normal")
		{
			try
			{
				channel = channel ?? Context.Channel;
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
				if (!((sDate < mDate && mDate < eDate && mDate > DateTime.MinValue) || (sDate < eDate && mDate == DateTime.MinValue)))
				{
					await Context.Channel.SendMessageAsync("Cannot create event with wrong dates!");
					return;
				}
				else
				{
					if (type == EventType.RPS)
					{
						await Context.Channel.SendMessageAsync("Option for creating RPS events is not created yet.");
						return;
					}
					Reminder temp = new Reminder()
					{
						ChannelId = channel.Id,
						Name = eventName,
						Action = EventAction.Start,
						StartDate = sDate.AddDays(-3),
						TriggerDate = sDate,
					};
					Data.Add(temp);
					if (mDate > DateTime.MinValue)
					{
						temp = new Reminder()
						{
							ChannelId = channel.Id,
							Name = eventName,
							Action = EventAction.End,
							StartDate = mDate.AddDays(-3),
							TriggerDate = mDate,
							Info = "Final Fever active!",
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
					};
					Data.Add(temp);
					await eventReminders.ResaveResources();
				}
				#region hide this ...
				XMLEmbed embed = new XMLEmbed()
				{
					Color = Color.Green,
					Title = $"Event \"{eventName}\" added succesfully",
					Fields = new List<XMLEmbedField>()
					{
						new XMLEmbedField()
						{
							Inline = true,
							Name = "Start Date",
							Value = sDate.ToString(),
						},
						((mDate > DateTime.MinValue) ?
						new XMLEmbedField()
						{
							Inline = true,
							Name = "Midway Date",
							Value = mDate.ToString(),
						}
						: null)
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
				var message = await Context.Channel.SendMessageAsync("", false, embed.GetEmbed(Context.Client.CurrentUser, Context.User, new Dictionary<string, string>()));
				await message.ModifyAsync((f) => {
					var e = new List<Embed>(message.Embeds)[0];

					EmbedBuilder builder = e.GetEmbedBuilder();
					builder.Description = "Updated " + builder.Description;
					f.Embed = builder.Build();
				});
				#endregion
			}
			catch (Exception ex)
			{
				eventReminders.LogMessage(ex.ToString());
			}
		}
	}

	public static class EmbedExtension
	{
		public static EmbedBuilder GetEmbedBuilder(this Embed embed)
		{
			EmbedBuilder builder = new EmbedBuilder();
			builder.WithAuthor(new EmbedAuthorBuilder()
			{
				IconUrl = embed.Author?.IconUrl,
				Name = embed.Author?.Name,
				Url = embed.Author?.Url,
			});
			builder.WithColor(embed.Color ?? Color.Blue);
			builder.WithDescription(embed.Description);
			builder.WithFooter(new EmbedFooterBuilder()
			{
				IconUrl = embed.Footer?.IconUrl,
				Text = embed.Footer?.Text,
			});
			builder.WithImageUrl(embed.Image?.Url);
			builder.WithThumbnailUrl(embed.Thumbnail?.Url);
			builder.WithCurrentTimestamp();
			builder.WithTitle(embed.Title);
			builder.WithUrl(embed.Url);
			foreach (var field in embed.Fields)
			{
				builder.AddField(new EmbedFieldBuilder()
				{
					IsInline = field.Inline,
					Name = field.Name,
					Value = field.Value,
				});
			}
			return builder;
		}
	}
}
