using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.FortuneModule
{
	public class DailyFortuneUser
	{
		[XmlElement("UserID")]
		public ulong UserID { get; set; }
		[XmlElement("Time")]
		public DateTime Time { get; set; }
		[XmlElement("FortuneID")]
		public int FortuneID { get; set; }

		public DailyFortuneUser() { }

		public DailyFortuneUser(ulong userID, DateTime time, int fortuneID)
		{
			UserID = userID;
			Time = time;
			FortuneID = fortuneID;
		}
	}
}
