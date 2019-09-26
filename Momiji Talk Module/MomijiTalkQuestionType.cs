using System;

namespace Momiji.Bot.V5.Modules.MomijiTalkModule
{
	[Flags]
	public enum MomijiTalkQuestionType
	{
		YesNo = 0x2,
		W =		0x4,
		Who =	0x8,
		What =  0x15,
		When =  0x20,
		Where = 0x40,
		Why =	0x80,
		How =	0x100,
		All =	0x1,
	}
}
