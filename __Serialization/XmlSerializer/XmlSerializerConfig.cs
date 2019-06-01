using System.IO;

namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	/// <summary>
	/// Object that holds information for serializer
	/// </summary>
	/// <typeparam name="T">Object where the data will be stored</typeparam>
	public class XmlSerializerConfig<T>
	{
		/// <summary>
		/// Indicator of Program main directory.
		/// </summary>
		public const string MainDir = "{BASE}";
		/// <summary>
		/// Durectory where file with data should be located. Directory path can contain <see cref="MainDir"/> constant at begining to indicate that file is located relative to program main directory.
		/// </summary>
		public string Directory { get; set; }
		/// <summary>
		/// Name of file that should contain serialized data. That file name should contain only file name. For file location <see cref="Directory"/>.
		/// </summary>
		public string FileName { get; set; }
		/// <summary>
		/// Path where file is located. It is constructed from combining <see cref="Directory"/> and <see cref="FileName"/>.
		/// </summary>
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
