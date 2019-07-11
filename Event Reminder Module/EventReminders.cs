using Momiji.Bot.V3.Modules.Embed;
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
		public override Task Initialize()
		{
			return Task.CompletedTask;
		}
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
			if (type == TimerType.On10Seconds)
			{
				foreach (var e in xmlObject.Data.Events)
				{
					if ((e.StartDate - DateTime.UtcNow).TotalMinutes > 0)
					{

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
		public XmlObject<XMLEmbed> xmlEmbedObject = new XmlObject<XMLEmbed>()
		{
			Data = new XMLEmbed()
			{
				Color = 0x0ABCDE,
				Title = "{EventName}",
				Description = "**Starts in {timeText}**",
				Fields = new List<XMLEmbedField>()
				{
					new XMLEmbedField()
					{
						Name = "*Check your local timezone*",
						Value = "*[Click Here](https://www.timeanddate.com/worldclock/fixedtime.html?msg={HTMl.EventName}&iso={HTML.Time})*",
					}
				},
			}
		};
		public XmlSerializerConfig<Reminder> serializerConfig = new XmlSerializerConfig<Reminder>()
		{
			Directory = "data",
			FileName = "EventReminders.xml",
		};
		public XmlSerializerConfig<XMLEmbed> embedConfig = new XmlSerializerConfig<XMLEmbed>()
		{
			Directory = "embed",
			FileName = "EventReminders.xml",
		};

		public Task LoadResources()
		{
			xmlObject = XmlSerializer.Load(serializerConfig, xmlObject);
			xmlEmbedObject = XmlSerializer.Load(embedConfig, xmlEmbedObject);
			return Task.CompletedTask;
		}
		public Task ReloadResources()
		{
			xmlObject = XmlSerializer.Reload(serializerConfig);
			xmlEmbedObject = XmlSerializer.Reload(embedConfig);
			return Task.CompletedTask;
		}
		public Task ResaveResources()
		{
			XmlSerializer.ReSave(serializerConfig, xmlObject);
			XmlSerializer.ReSave(embedConfig, xmlEmbedObject);
			return Task.CompletedTask;
		}
		public Task SaveResources()
		{
			XmlSerializer.Save(serializerConfig, xmlObject);
			XmlSerializer.Save(embedConfig, xmlEmbedObject);
			return Task.CompletedTask;
		}
		public String ResourcePath() => @".\data\EventReminders.xml";
		#endregion

	}
}
