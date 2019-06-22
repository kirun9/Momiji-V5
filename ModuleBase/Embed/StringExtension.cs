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

			foreach (var entry in args)
			{
				temp = temp.Replace(entry.Key.Trim('{', '}'), entry.Value);
			}
			return temp;
		}
	}
}