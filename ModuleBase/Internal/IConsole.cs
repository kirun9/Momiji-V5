namespace Momiji.Bot.V5.Core.InternalServer
{
	public interface IConsole
	{
		void Append(string moduleName, string message, ConsoleMessageType type);
	}
}