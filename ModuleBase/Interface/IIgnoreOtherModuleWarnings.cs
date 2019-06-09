using System;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface IRecieveWarningEvents
	{
		void OnDependModuleWarning(Guid sender, ModuleStateChangedArgs args);
	}
}
