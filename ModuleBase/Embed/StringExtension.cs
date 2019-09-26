using Discord;
using System.Collections.Generic;

namespace Momiji.Bot.V3.Modules.Embed.Extensions
{
	internal static class StringExtension
	{
		public static string FormatString(this string s, IUser bot, IUser user, Dictionary<string, string> args)
		{
			string nickname(IUser u)
			{
				if (u is IGuildUser gu)
					return gu.Nickname ?? gu.Username;
				else
					return u.Username;
			}

			string temp = s;
			temp = temp.Replace("{bot.username}", bot.Username);
			temp = temp.Replace("{bot.nickname}", nickname(bot));
			temp = temp.Replace("{user.username}", user.Username);
			temp = temp.Replace("{user.nickname}", nickname(user));

			foreach (var entry in args ?? new Dictionary<string, string>())
			{
				temp = temp.Replace("{" + entry.Key.Trim('{', '}') + "}", entry.Value);
			}
			return temp;
		}
	}

	public static class EmbedExtension
	{
		public static EmbedBuilder GetEmbedBuilder(this Discord.Embed embed)
		{
			EmbedBuilder builder = new EmbedBuilder();
			builder.WithAuthor(new EmbedAuthorBuilder()
			{
				IconUrl = embed.Author?.IconUrl,
				Name = embed.Author?.Name,
				Url = embed.Author?.Url,
			});
			builder.WithColor(embed.Color ?? Color.Blue);
			builder.WithDescription(embed.Description);
			builder.WithFooter(new EmbedFooterBuilder()
			{
				IconUrl = embed.Footer?.IconUrl,
				Text = embed.Footer?.Text,
			});
			builder.WithImageUrl(embed.Image?.Url);
			builder.WithThumbnailUrl(embed.Thumbnail?.Url);
			builder.WithCurrentTimestamp();
			builder.WithTitle(embed.Title);
			builder.WithUrl(embed.Url);
			foreach (var field in embed.Fields)
			{
				builder.AddField(new EmbedFieldBuilder()
				{
					IsInline = field.Inline,
					Name = field.Name,
					Value = field.Value,
				});
			}
			return builder;
		}
	}
}