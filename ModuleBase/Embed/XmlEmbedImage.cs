using Discord;
using System.Xml.Serialization;

namespace Momiji.Bot.V3.Modules.Embed
{
	public class XmlEmbedImage
	{
		[XmlAttribute("Type")]
		public XmlEmbedImageType Type { get; set; }
		[XmlElement("Url")]
		public string Url { get; set; }

		public string GetUrl(IUser bot, IUser user)
		{
			switch (Type)
			{
				case XmlEmbedImageType.BotProfile: return bot.GetAvatarUrl();
				case XmlEmbedImageType.URL: return Url;
				case XmlEmbedImageType.UserProfile: return user.GetAvatarUrl();
				case XmlEmbedImageType.File: return "attachment://" + Url;
				default: return Url;
			}
		}
	}

}