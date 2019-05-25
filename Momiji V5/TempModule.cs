using System;
using System.Collections.Generic;

namespace Momiji.Bot.V5.Core
{
	public class TempModule
	{
		public Guid Guid { get; private set; }
		public List<Guid> Parents { get; private set; } = new List<Guid>();

		public TempModule(Guid Guid)
		{
			this.Guid = Guid;
		}

		public void AddParent(Guid parent)
		{
			Parents.Add(parent);
		}

		public void AddParent(TempModule parent) => AddParent(parent.Guid);
	}
}
