using System.Xml.Serialization;

namespace Momiji.Bot.V3.Modules.Embed
{
	public class XmlEmbedColor
	{
		[XmlAttribute]
		public uint Value = 0;

		public XmlEmbedColor(Discord.Color c)
		{
			Value = c.RawValue;
		}

		public XmlEmbedColor() {

		}

		public static implicit operator Discord.Color(XmlEmbedColor c) => new Discord.Color(c.Value);
		public static implicit operator XmlEmbedColor(Discord.Color c) => new XmlEmbedColor() { Value = c.RawValue };
		public static implicit operator uint(XmlEmbedColor c) => c.Value;
		public static implicit operator XmlEmbedColor(uint c) => new XmlEmbedColor() { Value = c };
	}
}
