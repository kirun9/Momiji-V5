using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.FortuneModule
{
	public class DailyFortune
	{
		[XmlElement("Fortune")]
		public string FortuneMessage { get; set; }
		[XmlElement("ID")]
		public int FortuneID { get; set; }
		[XmlElement("Time")]
		public DateTime Time { get; set; }

		public DailyFortune() { }

		public DailyFortune(string message, int id, DateTime time)
		{
			FortuneMessage = message;
			FortuneID = id;
			Time = time;
		}
	}
}
