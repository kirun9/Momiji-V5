using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class CurrentEvent
	{
		public ulong MessageID { get; set; }
		public Event Event { get; set; }
		public Maintenance Maintenance { get; set; }
		public int MuntesLeft { get; set; }
	}
}
