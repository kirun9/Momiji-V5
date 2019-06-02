﻿using Momiji.Bot.V5.Modules;
using Momiji.Bot.V5.Modules.Interface;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace __TestModule
{
	public class Class1 : MomijiModuleBase, ICustomToolStrip
	{
		public Class1(Guid callerGuid) : base(callerGuid) { }

		public Class1() : base() { }

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

		public Task LoadConfig()
		{

			return Task.CompletedTask;
		}
		public Task SaveConfig()
		{

			return Task.CompletedTask;
		}
		public string ConfigPath()
		{
			return @"C:\Users\Krystian\Desktop\Empty file.txt";
		}

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
	}
}