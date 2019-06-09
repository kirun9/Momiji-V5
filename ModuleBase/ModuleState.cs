using System;

namespace Momiji.Bot.V5.Modules
{
	[Flags]
	public enum ModuleState
	{
		None = 0,
		ThrowWarningOnChilds = 1,
		ChangedByInternalScript  = 2,
		DisableModule = 4,

		Enabled = None,
		Disabled = ThrowWarningOnChilds | DisableModule,
		Warning = ThrowWarningOnChilds | ChangedByInternalScript,
		Error = ThrowWarningOnChilds | ChangedByInternalScript | DisableModule
	}
}
