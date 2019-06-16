using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.Core.Config;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core
{
	public class MomijiHeart
	{
		private const bool ConnectToDiscord = true;

		private static CancellationTokenSource cancellationToken = new CancellationTokenSource();
		public static void Stop()
		{
			cancellationToken.Cancel();
		}
		public static void Run()
		{
			try
			{
				new MomijiHeart().StartBotAsync().GetAwaiter().GetResult();
			}
			catch (MomijiHeartException ex)
			{
				Server.Log("Momiji Heart", ex.ToString(), ConsoleMessageType.Error);
			}
			catch (OperationCanceledException)
			{

			}
			catch (Exception ex)
			{
				Server.Log("Momiji Heart", ex.ToString(), ConsoleMessageType.Error);
				//Run();
			}
		}

		public async Task StartBotAsync()
		{
			Server.Log("Momiji Heart", "Initialization process started", ConsoleMessageType.Module);
			BotKeyReader.ReadKey();

			await Discord.DiscordInitializer.InitializeDiscord(ConnectToDiscord);
			await Settings.ReadSettings();
			await ModuleLoader.LoadModules();

			Server.Log("Momiji Heart", "Initialization process ended", ConsoleMessageType.Module);
			Server.Log("Momiji Heart", "Have Fun!", ConsoleMessageType.Module);
			await Task.Delay(-1, cancellationToken.Token);
		}
	}
}
