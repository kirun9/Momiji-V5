using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;

namespace Momiji.Bot.V5.Modules
{
    public class CommandBase<U> : ModuleBase<SocketCommandContext> where U : MomijiModuleBase
	{
		public U ModuleBase { get; set; }
		protected override void BeforeExecute(CommandInfo command)
		{
			base.BeforeExecute(command);
			ModuleBase = (U) MomijiModuleBase.Instance;
		}
	}
}
