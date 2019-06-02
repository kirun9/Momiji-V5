using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.Interface
{
	public interface IRecieveWarningEvents
	{
		void OnDependModuleWarning(Guid sender, ModuleStateChangedArgs args);
	}
}
