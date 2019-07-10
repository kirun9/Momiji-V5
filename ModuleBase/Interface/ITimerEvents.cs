using Momiji.Bot.V5.Modules.Internal;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface ITimerEvents
	{
		void OnTimer(TimerType type);
	}
}
