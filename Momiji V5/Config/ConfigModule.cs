using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Config
{
	public class ConfigModule
	{
		[XmlAttribute]
		public Guid Guid { get; set; }
		[XmlAttribute]
		public bool Enabled { get; set; }
		[XmlAttribute]
		public string Name { get; set; }
		[XmlArray("Commands")]
		[XmlArrayItem("Command", typeof(ConfigCommand))]
		public List<ConfigCommand> ConfigCommands { get; set; } = new List<ConfigCommand>();
	}
}
