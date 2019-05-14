using Momiji.Bot.V5.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __TestModule
{
	public class Class1 : MomijiModuleBase
	{
		public Class1(Guid callerGuid) : base(callerGuid) { }

		public Class1() { }

		public override string ModuleName { get; } = "Test Module";
		public override Guid Guid { get; } = Guid.Parse("fd8e0d76-ba55-4d90-9dc6-3daba8cd7292");

		public override Task Initialize()
		{
			//File.WriteAllText(Path.Combine("modules", "guid.txt"), Guid.ToString());
			Log("This is " + FullModuleName);
			return Task.CompletedTask;
		}
		public override Task PreInitialize() { return Task.CompletedTask; }
		public override Task PostInitialize() { return Task.CompletedTask; }
	}
}
