using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Momiji.Bot.V3.Modules.Embed;
using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.GuildData;
using Momiji.Bot.V5.Modules;
using Momiji.Bot.V5.Modules.Interface;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __TestModule
{
	public class Class1 : MomijiModuleBase, ICustomToolStrip, ICommandModule
	{
		public Class1(Guid callerGuid, IConsole console) : base(callerGuid, console) { }

		public override string ModuleName { get; } = "Test Module";
		public override Guid Guid { get; } = Guid.Parse("fd8e0d76-ba55-4d90-9dc6-3daba8cd7292");

		public override Task Initialize()
		{
			Log("This is " + FullModuleName);
			return Task.CompletedTask;
		}
		public override Task PreInitialize() { return Task.CompletedTask; }
		public override Task PostInitialize() { return Task.CompletedTask; }

		public ToolStripMenuItem GetCustomMenuItem()
		{
			ToolStripMenuItem item = new ToolStripMenuItem()
			{
				Name = "item",
				Text = "CustomItem",
				BackColor = System.Drawing.Color.Black,
				ForeColor = System.Drawing.Color.Aqua,
				DisplayStyle = ToolStripItemDisplayStyle.Text
			};
			return item;
		}

		public Type GetCommandClass()
		{
			return typeof(Commands);
		}

		public async Task RegisterCommands(CommandService service, IServiceProvider provider)
		{
			var moduleInfo = await service.AddModuleAsync(typeof(Commands), provider);
			Log(moduleInfo.ToString());
		}
	}

	public class Commands : CommandBase
	{
		public Class1 ModuleBase { get; set; }

		[Command("Test")]
		public async Task TestCommand()
		{
			
		}
	}
}
