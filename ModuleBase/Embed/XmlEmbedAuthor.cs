using Discord;
using System.Xml.Serialization;

namespace Momiji.Bot.V3.Modules.Embed
{
	public class XmlEmbedAuthor
	{
		[XmlElement("Name")]
		public string Name { get; set; }
		[XmlElement("Url")]
		public string Url { get; set; }
		[XmlElement("Icon")]
		public XmlEmbedImage Icon { get; set; }
		
		public EmbedAuthorBuilder GetAuthor(IUser bot, IUser user)
		{
			EmbedAuthorBuilder builder = new EmbedAuthorBuilder();
			builder.Name = Name;
			builder.Url = Url;
			builder.IconUrl = Icon.GetUrl(bot, user);
			return builder;
		}
	}

}