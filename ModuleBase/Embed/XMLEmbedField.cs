using Discord;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Momiji.Bot.V3.Modules.Embed
{
	public class XMLEmbedField
	{
		[XmlElement("Name")]
		public string Name { get; set; }
		[XmlElement("value")]
		public string Value { get; set; }
		[XmlAttribute("Inline")]
		public bool Inline { get; set; } = false;

		public EmbedFieldBuilder GetField(IUser bot, IUser user, Dictionary<string, string> args)
		{
			EmbedFieldBuilder builder = new EmbedFieldBuilder();
			builder.WithIsInline(Inline);
			builder.WithName(Value.FormatString(bot, user, args));
			builder.WithValue(Value.FormatString(bot, user, args));
			return builder;
		}

	}

}