using Discord.WebSocket;
using DiscordSocketClient = Momiji.Bot.V5.Modules.MyDiscord.DiscordSocketClient;
using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Discord;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class Reminder
	{
		[XmlAttribute]
		public long EventId { get; set; }
		[XmlAttribute]
		public DateTime TriggerDate { get; set; }
		[XmlAttribute]
		public DateTime StartDate { get; set; }
		[XmlElement]
		public String Name { get; set; }
		[XmlElement]
		public string Info { get; set; }
		[XmlAttribute]
		public EventAction Action { get; set; }
		[XmlElement]
		public ulong MessageId { get; set; }
		[XmlElement]
		public ulong ChannelId { get; set; }
		[XmlAttribute]
		public AfterReminder After { get; set; }
		[XmlAttribute]
		public AfterReminderTime AfterTime { get; set; }
		[XmlElement]
		public string ImageUrl { get; set; }
		[XmlIgnore]
		public int MinutesLeft { get; set; }
		[XmlIgnore]
		public DateTime ExpirationDate
		{
			get
			{
				if (After.HasFlag(AfterReminder.AfterTime))
				{
					return TriggerDate.AddHours((AfterTime == AfterReminderTime.After12Hours ? 12 : 24));
				}
				else
				{
					if (After.HasFlag(AfterReminder.OnNewReminder))
					{
						return DateTime.MaxValue;
					}
					return TriggerDate;
				}
			}
		}

		public async Task Expire(DiscordSocketClient client)
		{
			var channel = client.GetChannel(ChannelId) as ISocketMessageChannel;
			var message = await channel?.GetMessageAsync(MessageId, CacheMode.AllowDownload) as IUserMessage;
			if (After.HasFlag(AfterReminder.Unpin))
			{
				await message?.UnpinAsync();
			}
			if (After.HasFlag(AfterReminder.Delete))
			{
				await message?.DeleteAsync();
			}
		}

	}
	public enum EventAction { Start, End, MidwayEnd }
	[Flags]
	public enum AfterReminder {
		Unpin = 0x1,
		Delete = 0x2,
		AfterTime = 0x4,
		OnNewReminder = 0x8,
	}
	public enum AfterReminderTime
	{
		After12Hours = 0, After24Hours = 1
	}
}