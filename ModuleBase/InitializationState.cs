namespace Momiji.Bot.V5.Modules
{
	public enum InitializationState
	{
		NotStarted,
		PreInitializing ,
		PreInitialized,
		Initializing,
		Initialized,
		PostInitializing,
		Completed
	}
}