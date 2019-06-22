namespace Momiji.Bot.V5.Core
{
	public enum ModuleCompatible
	{
		/// <summary>
		/// Module is not longer supported. Module should be updated.
		/// </summary>
		Old = 2,
		/// <summary>
		/// Module is not supported yet. Module is probably designed for newer versions of module loader.
		/// </summary>
		New = 3,
		/// <summary>
		/// Module is supported.
		/// </summary>
		Match = 1
	}
}
