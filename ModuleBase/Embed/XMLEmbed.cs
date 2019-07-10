using Discord;
using Momiji.Bot.V3.Modules.Embed.Extensions;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Momiji.Bot.V3.Modules.Embed
{
	public class XMLEmbed
	{
		[XmlElement("Color", Order = 1)]
		public Color Color { get; set; }
		[XmlElement("Title", Order = 6)]
		public string Title { get; set; }
		[XmlElement("Description", Order = 2)]
		public string Description { get; set; }
		[XmlElement("Thumbnail", Order = 5)]
		public XmlEmbedImage Thumbnail { get; set; }
		[XmlArray("Fields", Order = 3)]
		[XmlArrayItem("Field", typeof(XMLEmbedField))]
		public List<XMLEmbedField> Fields { get; set; }
		[XmlElement("Image", Order = 4)]
		public XmlEmbedImage Image { get; set; }
		[XmlElement("Url", Order = 7)]
		public string Url { get; set; }

		public Discord.Embed GetEmbed(IUser bot, IUser user, Dictionary<string, string> args)
		{
			EmbedBuilder builder = new EmbedBuilder();

			if (bot is IGuildUser guildBot)
			{
				builder.WithAuthor(guildBot.Nickname == null ? guildBot.Username : guildBot.Nickname, guildBot.GetAvatarUrl());
			}
			else
			{
				builder.WithAuthor(bot.Username, bot.GetAvatarUrl());
			}
			builder.WithColor(Color);
			builder.WithCurrentTimestamp();
			builder.WithDescription(Description?.FormatString(bot, user, args));
			foreach (var field in Fields)
			{
				if (field != null)
					builder.AddField(field.GetField(bot, user, args));
			}
			builder.WithFooter("Momiji v5 coded by kirun9");
			builder.WithImageUrl(Image?.GetUrl(bot, user));
			builder.WithThumbnailUrl(Thumbnail?.GetUrl(bot, user));
			builder.WithTitle(Title?.FormatString(bot, user, args));
			builder.WithUrl(Url);
			return builder.Build();
		}
	}
}