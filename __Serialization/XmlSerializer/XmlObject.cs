namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	/// <summary>
	/// Holds information about data version and stores data for serialization.
	/// </summary>
	/// <typeparam name="T">Object where the data will be stored</typeparam>
	public class XmlObject<T>
	{
		/// <summary>
		/// Version of data. Other version means that data could be not compatible.
		/// </summary>
		public XmlSerializerVersion Version { get; set; }
		/// <summary>
		/// Data to serialize
		/// </summary>
		public T Data { get; set; }
		/// <summary>
		/// Default constructor
		/// </summary>
		public XmlObject() { }
	}
}
