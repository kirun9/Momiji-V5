using Momiji.Bot.V3.Serialization.XmlSerializer;
using System.Threading.Tasks;
using XmlSerializer = Momiji.Bot.V3.Serialization.XmlSerializer.XmlSerializer;

namespace Momiji.Bot.V5.Core.Config
{
	public class Settings
	{
		private static bool readed = false;
		private static XmlObject<ConfigRoot> config = new XmlObject<ConfigRoot>() { Version = new XmlSerializerVersion("1.0.0.0") };
		internal static ConfigRoot Config
		{
			get
			{
				if (readed)
					return config.Data;
				else
					throw new MomijiHeartException("Cannot return unreaded settings!");
			}
			set
			{
				config.Data = value;
			}
		}
		internal static XmlSerializerConfig<ConfigRoot> xmlSerializerConfig = new XmlSerializerConfig<ConfigRoot>()
		{
			Directory = "configs",
			FileName = "BotConfig.xml"
		};

		internal static Task ReadSettings()
		{
			try
			{
				config = XmlSerializer.Load(xmlSerializerConfig);
				//if (config.Data != null)
				//{
					readed = true;
				//}
				//else
				//	return Task.FromException(new System.IO.IOException("Config wasn't loaded correctly"));
			}
			catch (XmlSerializerException ex)
			{
				return Task.FromException(ex);
			}
			return Task.CompletedTask;
		}

		internal static Task SaveConfig()
		{
			try
			{
				XmlSerializer.Save(xmlSerializerConfig, config);
			}
			catch (XmlSerializerException ex)
			{
				return Task.FromException(ex);
			}
			return Task.CompletedTask;
		}
	}
}
