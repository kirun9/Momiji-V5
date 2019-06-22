using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface IExternalResources
	{
		Task LoadResources();
		Task SaveResources();
		Task ReloadResources();
		Task ResaveResources();
		string ResourcePath();
	}
}
