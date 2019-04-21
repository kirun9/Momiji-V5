using System;
using System.IO;

namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	[Serializable]
	public class XmlSerializerException : IOException
	{
		public XmlSerializerException() { }
		public XmlSerializerException(string message) : base(message) { }
		public XmlSerializerException(string message, Exception inner) : base(message, inner) { }
		public XmlSerializerException(Exception inner) : base("Serializer found an exception", inner) { }
		protected XmlSerializerException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}