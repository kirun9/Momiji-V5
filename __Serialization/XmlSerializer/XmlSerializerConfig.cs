using System.IO;

namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	public class XmlSerializerConfig<T>
	{
		public const string MainDir = "{BASE}";
		public string Directory { get; set; }
		public string FileName { get; set; }
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