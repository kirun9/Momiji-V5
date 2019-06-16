using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.Core.Config;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Momiji.Bot.V5.Core
{
	public class MomijiHeart
	{
		internal static IServiceCollection ServiceCollection { get; set; } = new ServiceCollection();
		internal static IServiceProvider ServiceProvider { get => ServiceCollection.BuildServiceProvider(); }


		private const bool ConnectToDiscord = true;

		private static CancellationTokenSource cancellationToken = new CancellationTokenSource();

		internal static IConsole GetServer
		{
			get
			{
				foreach (var service in ServiceCollection)
				{
					if (service.ServiceType == typeof(IConsole))
					{
						return service.ImplementationInstance as Server;
					}
				}
				throw new MomijiHeartException("Cannot find " + typeof(Server).FullName + " in ServiceCollection. Cannot continue!");
			}
		}

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
				Console.Log("Momiji Heart", ex.ToString(), ConsoleMessageType.Error);
			}
			catch (OperationCanceledException)
			{

			}
			catch (Exception ex)
			{
				Console.Log("Momiji Heart", ex.ToString(), ConsoleMessageType.Error);
				//Run();
			}
		}

		public async Task StartBotAsync()
		{
			ServiceCollection.AddSingleton(typeof(IConsole), Server.Instance);

			Console.Log("Momiji Heart", "Initialization process started", ConsoleMessageType.Module);
			BotKeyReader.ReadKey();

			await Discord.DiscordInitializer.InitializeDiscord(ConnectToDiscord);
			await Settings.ReadSettings();
			await ModuleLoader.LoadModules();

			Console.Log("Momiji Heart", "Initialization process ended", ConsoleMessageType.Module);
			Console.Log("Momiji Heart", "Have Fun!", ConsoleMessageType.Module);
			await Task.Delay(-1, cancellationToken.Token);
		}
	}

	internal static class Console
	{
		internal static void Log(string moduleName, string message, ConsoleMessageType type = ConsoleMessageType.Info)
		{
			MomijiHeart.GetServer.Append(moduleName, message, type);
		}
		
		internal static void Log(string moduleName, string message, Exception exception, ConsoleMessageType type = ConsoleMessageType.Warning)
		{
			Log(moduleName, message + " " + exception.ToString(), type);
		}
	}
}
