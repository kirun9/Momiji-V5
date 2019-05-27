using System.Windows.Forms;

namespace Momiji.Bot.V5.Modules
{
	public interface ICustomModuleItem
	{
		Control CustomControl { get; }
		bool TwoRowModuleItem { get; }
	}
}
