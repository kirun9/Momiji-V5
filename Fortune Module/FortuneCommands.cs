using Discord.Commands;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.FortuneModule
{
	public class FortuneCommands : CommandBase
	{
		public FortuneModule FortuneModule { get; set; }

		[Command("fortune")]
		[GUID("4d0787bb-14a9-40a8-a7e1-fa327d3adb64")]
		public async Task Fortune()
		{
			await Context.Channel.SendMessageAsync(embed: FortuneModule.GetFortuneEmbed(Context.Client.CurrentUser, Context.User));
		}
	}
}