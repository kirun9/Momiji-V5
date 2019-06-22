using System;
using System.Linq;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Config
{
	public class ConfigCommand
	{
		[XmlAttribute]
		public Guid Guid { get; set; }
		[XmlAttribute]
		public bool Enabled { get; set; }
		[XmlAttribute]
		public string Name { get; set; }
		public ConfigModule ConfigModule
		{
			get
			{
				return Settings.Config.ConfigModules.FirstOrDefault((e) => e.ConfigCommands.FirstOrDefault((f) => f == this) != null);
			}
		}
	}
}
