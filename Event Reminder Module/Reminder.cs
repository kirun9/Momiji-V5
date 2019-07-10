using System.Collections.Generic;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class Reminder
	{
		[XmlArray("Events")]
		[XmlArrayItem("Item", typeof(Event))]
		public List<Event> Events { get; set; }
		[XmlArray("Maintenances")]
		[XmlArrayItem("Item", typeof(Maintenance))]
		public List<Maintenance> Maintenances { get; set; }
	}
}
