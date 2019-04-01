namespace Momiji.Bot.V5.Core.InternalServer
{
	public static class HTMLStringExtension
	{
		public static string PreventInjection(this string text)
		{
			return text
				.Replace("&", "&amp")
				.Replace("<", "&lt")
				.Replace(">", "&gt;")
				.Replace("\"", "&quot;")
				.Replace("'", "&apos;")
				.Replace("\r", "");
		}
	}
}
