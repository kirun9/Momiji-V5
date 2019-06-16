using System;

namespace Momiji.Bot.V5.Modules
{
	public class ModuleStateChangedArgs : EventArgs
	{
		public ModuleState NewState { get; private set; }
		public ModuleState OldState { get; private set; }

		public ModuleStateChangedArgs(ModuleState newState, ModuleState oldState)
		{
			NewState = newState;
			OldState = oldState;
		}
	}
}