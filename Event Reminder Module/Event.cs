using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class Event
	{
		[XmlElement]
		public DateTime StartDate { get; set; }
		[XmlElement]
		public DateTime MidwayDate { get; set; }
		[XmlElement]
		public DateTime EndDate { get; set; }
		[XmlElement]
		public string EventName { get; set; }
		[XmlAttribute]
		public EventType EventType { get; set; }
	}
}
