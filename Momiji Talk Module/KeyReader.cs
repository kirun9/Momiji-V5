using System;
using System.IO;

namespace Momiji.Bot.V5.Modules.MomijiTalkModule
{
	internal class KeyReader
	{
		private static readonly string FILE_PATH = Path.Combine("configs", "DialogFlowToken.key");

		private static bool readed = false;

		private static string dialogFlowToken;
		internal static string DIALOGFLOW_TOKEN
		{
			get
			{
				if (readed)
				{
					return dialogFlowToken;
				}
				else
				{
					throw new InvalidOperationException("Cannot get DialogFlow token without reading it from file.");
				}
			}
		}

		internal static bool CheckForKey()
		{
			return File.Exists(FILE_PATH);
		}

		internal static void SaveKey(string botToken)
		{
			if (!Directory.GetParent(FILE_PATH).Exists)
			{
				Directory.GetParent(FILE_PATH).Create();
			}
			File.WriteAllText(FILE_PATH, botToken);
		}

		internal static void ReadKey()
		{
			if (File.Exists(FILE_PATH))
			{
				dialogFlowToken = File.ReadAllText(FILE_PATH);
				readed = true;
			}
			else
			{
				throw new FileNotFoundException($"File \"{FILE_PATH}\" containing bot token was not found.");
			}
		}
	}
}
