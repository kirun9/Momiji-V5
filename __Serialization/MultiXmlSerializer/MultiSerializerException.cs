using System;
using System.IO;

namespace Momiji.Bot.V3.Serialization.MultiXmlSerializer
{
	[Serializable]
	public class MultiXmlSerializerException : IOException
	{
		public MultiXmlSerializerException() { }
		public MultiXmlSerializerException(string message) : base(message) { }
		public MultiXmlSerializerException(string message, Exception inner) : base(message, inner) { }
		public MultiXmlSerializerException(Exception inner) : base("Serializer found an exception", inner) { }
		protected MultiXmlSerializerException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
