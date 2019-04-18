using Momiji.Bot.V5.Core.InternalServer;
using System;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core
{
	public class MomijiHeart
	{
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
			catch (Exception ex)
			{
				Server.Log("Momiji Heart", ex.ToString(), ConsoleMessageType.Error);
				Run();
			}
		}
		public async Task StartBotAsync()
		{
			Server.Log("Momiji Heart", "Initialization process started", ConsoleMessageType.Module);
			throw new MomijiHeartException("There is no code to execute");
			await Task.Delay(-1);
		}
	}
}
