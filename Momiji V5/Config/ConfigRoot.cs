using System.Collections.Generic;
using System.Xml.Serialization;

namespace Momiji.Bot.V5.Core.Config
{
	public class ConfigRoot
	{
		[XmlArray("Modules")]
		[XmlArrayItem("Module", typeof(ConfigModule))]
		public List<ConfigModule> ConfigModules { get; set; } = new List<ConfigModule>();
		public List<ConfigCommand> GetCommands()
		{
			List<ConfigCommand> temp = new List<ConfigCommand>();
			foreach (var module in ConfigModules)
			{
				foreach (var command in module.ConfigCommands)
				{
					temp.Add(command);
				}
			}
			return temp;
		}
	}
}
