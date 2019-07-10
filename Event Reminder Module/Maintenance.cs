using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class Maintenance
	{
		[XmlElement]
		public DateTime StartDate { get; set; }
		[XmlElement]
		public DateTime EndDate { get; set; }
	}
}
