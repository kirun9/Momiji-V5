using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.GuildData
{
	public class GuildData
	{
		[XmlArray("Entries")]
		[XmlArrayItem("entry", typeof(Guild))]
		List<Guild> Entries { get; set; }
	}
	public class Guild
	{
		[XmlElement]
		public ulong Id { get; set; }
		[XmlElement]
		public ulong DefaultChannel { get; set; }
	}
}
