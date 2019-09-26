using Momiji.Bot.V5.Core.InternalServer;
using System;
using System.Threading.Tasks;
using Momiji.Bot.V3.Serialization.XmlSerializer;
using Momiji.Bot.V5.Modules.Interface;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace Momiji.Bot.V5.Modules.MomijiTalkModule
{
	public class MomijiTalkModule : MomijiModuleBase, IExternalResources, ICommandModule
	{
		public override string ModuleName { get; } = "Momiji Talk Module";
		public override Guid Guid { get; } = new Guid("1fd3ca46-b483-47bb-83dd-76fefdea6000");
		public List<MomijiTalkAnswers> Answers { get => xmlAnswersObject.Data; }

		public XmlObject<List<MomijiTalkAnswers>> xmlAnswersObject = new XmlObject<List<MomijiTalkAnswers>>()
		{
			Data = new List<MomijiTalkAnswers>()
			{
				new MomijiTalkAnswers()
				{
					Answer = "Test",
					Type = MomijiTalkQuestionType.When
				},
				new MomijiTalkAnswers()
				{
					Answer = "Test2",
					Type = MomijiTalkQuestionType.YesNo
				}
			}
		};

		private XmlSerializerConfig<List<MomijiTalkAnswers>> serializerConfig = new XmlSerializerConfig<List<MomijiTalkAnswers>>()
		{
			Directory = "data",
			FileName = "MomijiTalkAnswers.xml",
		};

		public MomijiTalkModule() : base() { }
		public MomijiTalkModule(Guid callerGuid, IConsole console) : base(callerGuid, console) { }

		public override Task Initialize()
		{
			Log("Connected");
			return Task.CompletedTask;
		}

		public override Task PostInitialize() => Task.CompletedTask;

		public override Task PreInitialize()
		{
			if (KeyReader.CheckForKey())
			{
				KeyReader.ReadKey();
			}
			else
			{
				KeyReader.SaveKey("JSON KEY GOES HERE");
				ModuleState = ModuleState.Disabled;
			}
			return Task.CompletedTask;
		}

		public Task LoadResources()
		{
			xmlAnswersObject = XmlSerializer.Load(serializerConfig, xmlAnswersObject);
			return Task.CompletedTask;
		}
		public Task SaveResources()
		{
			XmlSerializer.Save(serializerConfig, xmlAnswersObject);
			return Task.CompletedTask;
		}
		public Task ReloadResources()
		{
			xmlAnswersObject = XmlSerializer.Reload(serializerConfig);
			return Task.CompletedTask;
		}
		public Task ResaveResources()
		{
			xmlAnswersObject = XmlSerializer.ReSave(serializerConfig, xmlAnswersObject);
			return Task.CompletedTask;
		}
		public String ResourcePath() => @".\data\MomijiTalkAnswers.xml";
		public Type GetCommandClass() => typeof(MomijiTalkModuleCommands);

		public string ParseFallbackMessage(string message)
		{
			var temp = Regex.Replace(message, "[^0-9a-zA-Z]+", "").ToLower();
			message = message.ToLower();
			if (message.EndsWith("?") && temp.Length > 2)
			{
				if (message.StartsWith("who"))
				{

					return Reply(MomijiTalkQuestionType.Who);
				}
				else if (message.StartsWith("what"))
				{
					return Reply(MomijiTalkQuestionType.What);
				}
				else if (message.StartsWith("when"))
				{
					return Reply(MomijiTalkQuestionType.When);
				}
				else if (message.StartsWith("where"))
				{
					return Reply(MomijiTalkQuestionType.Where);
				}
				else if (message.StartsWith("why"))
				{
					return Reply(MomijiTalkQuestionType.Why);
				}
				else if (message.StartsWith("how"))
				{
					return Reply(MomijiTalkQuestionType.How);
				}
				else
				{
					return Reply(MomijiTalkQuestionType.YesNo);
				}
			}
			char c = (char)0x18;
			return c.ToString();
		}
		private string Reply(MomijiTalkQuestionType type)
		{
			var list = Answers.Where((a) => (a.Type & type) != 0).Select((a) => a.Answer).ToList();
			if (list.Count == 0)
			{
				return "Is this a question at all?";
			}

			Random random = new Random((int)DateTime.Now.Ticks);
			int rand = random.Next(0, list.Count);
			return list[rand];
		}
	}
}
