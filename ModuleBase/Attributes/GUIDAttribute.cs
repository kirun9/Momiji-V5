using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
	public class GUIDAttribute : Attribute
	{
		public Guid Guid { get; private set; }

		public GUIDAttribute(Guid guid)
		{
			Guid = guid;
		}

		public GUIDAttribute(string guid)
		{
			Guid = new Guid(guid);
		}

		public GUIDAttribute(byte[] guid)
		{
			Guid = new Guid(guid);
		}

		public GUIDAttribute(int a, short b, short c, byte[] d)
		{
			Guid = new Guid(a, b, c, d);
		}

		public GUIDAttribute(int a, short b, short c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
		{
			Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
		}

		public GUIDAttribute(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
		{
			Guid = new Guid(a, b, c, d, e, f, g, h, i, j, k);
		}
	}
}
