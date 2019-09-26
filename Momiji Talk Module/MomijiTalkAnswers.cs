using System.Xml.Serialization;

namespace Momiji.Bot.V5.Modules.MomijiTalkModule
{
	public class MomijiTalkAnswers
	{
		[XmlAttribute("Type")]
		public MomijiTalkQuestionType Type { get; set; }
		[XmlElement("Answer")]
		public string Answer { get; set; }
	}
}
