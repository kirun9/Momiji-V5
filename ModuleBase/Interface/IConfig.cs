using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface IConfig
	{
		Task LoadConfig();
		Task SaveConfig();
		string ConfigFileName();
	}
}
