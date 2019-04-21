using System;
using System.Collections.Generic;
using System.IO;

namespace Momiji.Bot.V3.Serialization.MultiXmlSerializer
{
	public class MultiXmlSerializerConfig<T>
	{
		public const string MainDir = "{BASE}";

		public string Directory { get; set; }
		public string FileName { get; set; }
		public Type[] RegisteredTypes {
			get
			{
				if (Data != null)
				{
					List<Type> types = new List<Type>();
					if (Data is IXmlCustomTypes)
					{
						types.AddRange(((IXmlCustomTypes)Data).GetCustomTypes());
					}
					foreach (var type in types)
					{
						if (type.GetType().IsSubclassOf(typeof(IXmlCustomTypes)))
						{
							types.AddRange(((IXmlCustomTypes)Data).GetCustomTypes());
						}
					}
					return types.ToArray();
				}
				return new Type[0];
			}
		}
		
		public T Data { get; set; }
		
		public string FilePath { get => GetPath(); }

		private string GetPath()
		{
			if (Directory == "{BASE}")
			{
				return FileName;
			}
			else
			{
				return Path.Combine(Directory, FileName);
			}
		}
	}
}
