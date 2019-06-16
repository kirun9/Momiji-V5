using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core
{
	class MomijiHeartException : InvalidOperationException
	{
		public MomijiHeartException()
		{
		}

		public MomijiHeartException(String message) : base(message)
		{
		}

		public MomijiHeartException(String message, Exception innerException) : base(message, innerException)
		{
		}

		protected MomijiHeartException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
