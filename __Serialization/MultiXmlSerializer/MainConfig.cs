using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Momiji.Bot.V3.Serialization.MultiXmlSerializer
{
	public class MainConfig : IXmlCustomTypes
	{
		[XmlArray("Modules_Config")]
		[XmlArrayItem("Module", typeof(MultiXmlSerializationConfig))]
		public List<MultiXmlSerializationConfig> Configs { get; set; } = new List<MultiXmlSerializationConfig>();

		public Type[] GetCustomTypes()
		{
			List<Type> types = new List<Type>();
			foreach (var config in Configs)
			{
				if (!types.Contains(config.GetType()))
				{
					types.Add(config.GetType());
				}
			}
			return types.ToArray();
		}
	}
}
