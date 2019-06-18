using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Momiji.Bot.V5.Modules.MyDiscord
{
	public class CommandService
	{
		private Discord.Commands.CommandService _CommandService { get; set; }
		//
		// Summary:
		//     Represents all commands loaded within Discord.Commands.CommandService.
		public IEnumerable<CommandInfo> Commands { get => _CommandService.Commands; }
		//
		// Summary:
		//     Represents all modules loaded within Discord.Commands.CommandService.
		public IEnumerable<ModuleInfo> Modules { get => _CommandService.Modules; }
		//
		// Summary:
		//     Represents all Discord.Commands.TypeReader loaded within Discord.Commands.CommandService.
		public ILookup<Type, TypeReader> TypeReaders { get => _CommandService.TypeReaders; }

		public CommandService(Discord.Commands.CommandService service)
		{
			_CommandService = service;
		}
		//
		// Summary:
		//     Searches for the command.
		//
		// Parameters:
		//   context:
		//     The context of the command.
		//
		//   input:
		//     The command string.
		//
		// Returns:
		//     The result containing the matching commands.
		public SearchResult Search(ICommandContext context, String input) => _CommandService.Search(context, input);
		//
		// Summary:
		//     Searches for the command.
		//
		// Parameters:
		//   context:
		//     The context of the command.
		//
		//   argPos:
		//     The position of which the command starts at.
		//
		// Returns:
		//     The result containing the matching commands.
		public SearchResult Search(ICommandContext context, Int32 argPos) => _CommandService.Search(context, argPos);
		public SearchResult Search(String input) => _CommandService.Search(input);

	}
}
