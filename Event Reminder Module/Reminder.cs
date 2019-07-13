using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class Reminder
	{
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
		[XmlAttribute]
		public ulong MessageId { get; set; }
		[XmlAttribute]
		public ulong ChannelId { get; set; }
		[XmlIgnore]
		public int MinutesLeft { get; set; }
	}
	public enum EventAction { Start, End }
}