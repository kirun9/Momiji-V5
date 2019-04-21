namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	public class XmlObject<T>
	{
		public XmlSerializerVersion Version { get; set; }
		public T Data { get; set; }

		public XmlObject() { }
	}
}
