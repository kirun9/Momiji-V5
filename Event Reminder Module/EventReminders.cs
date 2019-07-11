using Momiji.Bot.V3.Serialization.XmlSerializer;
using Momiji.Bot.V5.Core.InternalServer;
using Momiji.Bot.V5.Modules.Interface;
using Momiji.Bot.V5.Modules.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules.EventReminderModule
{
	public class EventReminders : MomijiModuleBase, ICommandModule, ITimerEvents, IExternalResources
	{
		#region Module Initialization ...
		public override string ModuleName { get; } = "Event Reminder";
		public override Guid Guid { get; } = new Guid("68081921-f7bc-4b1f-8e73-eb0ec32fbadd");

		public EventReminders() { }
		public EventReminders(Guid callerGuid, IConsole console) : base(callerGuid, console) { }

		public void LogMessage(string message) => Log(message);

		#region Initialize methods
		public override Task Initialize() => Task.CompletedTask;
		public override Task PostInitialize() => Task.CompletedTask;
		public override Task PreInitialize() => Task.CompletedTask;
		#endregion
		#endregion

		#region ICommandModule ...
		public Type GetCommandClass() => typeof(EventReminderCommands);
		#endregion

		#region ITimerEvents
		public void OnTimer(TimerType type)
		{
			if (type == TimerType.On1Minute)
			{
				foreach (var event in xmlObject.Data.Events)
				{
					if (event.StartDate > DateTime.NowUTC.AddMinutes(1))
					{
						LogMessage("Can display");
					}
				}
			}
		}
		#endregion

		#region IExternalResources ...

		public XmlObject<Reminder> xmlObject = new XmlObject<Reminder>()
		{
			Data = new Reminder()
			{
				Events = new List<Event>(),
				Maintenances = new List<Maintenance>()
			}
		};
		public XmlSerializerConfig<Reminder> serializerConfig = new XmlSerializerConfig<Reminder>()
		{
			Directory = "data",
			FileName = "EventReminders.xml",
		};

		public Task LoadResources()
		{
			xmlObject = XmlSerializer.Load(serializerConfig, xmlObject);
			return Task.CompletedTask;
		}
		public Task ReloadResources()
		{
			xmlObject = XmlSerializer.Reload(serializerConfig);
			return Task.CompletedTask;
		}
		public Task ResaveResources()
		{
			XmlSerializer.ReSave(serializerConfig, xmlObject);
			return Task.CompletedTask;
		}
		public Task SaveResources()
		{
			XmlSerializer.Save(serializerConfig, xmlObject);
			return Task.CompletedTask;
		}
		public String ResourcePath() => @".\data\EventReminders.xml";
		#endregion

	}
}
