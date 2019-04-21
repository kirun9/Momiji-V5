using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Momiji.Bot.V5.Core
{
	public class BotKeyReader
	{
#if DEBUG
		private static readonly string FILE_PATH = Path.Combine("configs", "debug_botToken.key");
#else
		private static readonly string FILE_PATH = Path.Combine("configs", "botToken.key");
#endif
		private static bool readed = false;

		private static string botToken;
		internal static string BOT_TOKEN {
			get
			{
				if (readed) {
					return botToken;
				}
				else {
					try
					{
						throw new InvalidOperationException("Cannot get bot token without reading it from file.");
					}
					catch (InvalidOperationException ex)
					{
						throw new MomijiHeartException("Cannot continue with that exception", ex);
					}
				}
			}
		}

		internal static void ReadKey()
		{
			if (File.Exists(FILE_PATH))
			{
				botToken = File.ReadAllText(FILE_PATH);
				readed = true;
			}
			else
			{
				try
				{
					throw new FileNotFoundException($"File \"{FILE_PATH}\" containing bot token was not found.");
				}
				catch (FileNotFoundException ex)
				{
					throw new MomijiHeartException("Can not continue without file containing bot token", ex);
				}
			}
		}
	}
}
