using Momiji.Bot.V5.Modules;
using System;
using System.Collections.Generic;

namespace Momiji.Bot.V5.Core
{
	public class TempModule
	{
		public Guid Guid { get; private set; }
		public string Name { get; private set; }
		public List<Guid> Parents { get; private set; } = new List<Guid>();
		public ModuleState State { get; set; } = ModuleState.Enabled;

		public TempModule(Guid Guid, string name)
		{
			this.Guid = Guid;
			this.Name = name;
		}

		public void AddParent(Guid parent)
		{
			Parents.Add(parent);
		}

		public void AddParent(TempModule parent) => AddParent(parent.Guid);
	}
}
