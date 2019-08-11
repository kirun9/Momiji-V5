using System;

namespace Momiji.Bot.V5.Core.Controls.Panels.RunCommand
{
	internal class CommandTreeItem
	{
		public string Name { get; private set; }
		public ulong Id { get; private set; }
		public CommandTreeItem(string name, ulong id)
		{
			Name = name;
			Id = id;
		}
		public override String ToString() => Name;
	}
}
