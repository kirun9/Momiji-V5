using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Config
{
	public class ConfigCommand
	{
		[XmlAttribute]
		public Guid Guid { get; set; }
		[XmlAttribute]
		public string Name { get; set; }
		[XmlAttribute]
		public bool Enabled { get; set; }
	}
}
