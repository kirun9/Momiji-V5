using System;
using System.IO;
using System.Security;
using Serial = System.Xml.Serialization.XmlSerializer;

namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	public class XmlSerializer
	{
		/// <summary>
		/// Reads and loads a serialized file. It will save and load default type values if file is not existing. See <seealso cref="Load{T}(XmlSerializerConfig{T}, XmlObject{T})"/> for user defined default data.
		/// </summary>
		/// <typeparam name="T">Object where the data will be stored</typeparam>
		/// <param name="config">Serializer config <see cref="XmlSerializerConfig{T}"/></param>
		/// <returns>Object that holds informations about deserialized data and data version. <see cref="XmlObject{T}"/></returns>
		public static XmlObject<T> Load<T>(XmlSerializerConfig<T> config)
		{
			string path = config.FilePath;
			if (!File.Exists(path))
			{
				Save(config, new XmlObject<T>());
			}
			Serial serializer = new Serial(typeof(XmlObject<T>), "MomijiXmlSerializer");
			StreamReader reader = null;
			XmlObject<T> obj = new XmlObject<T>();
			try
			{
				using (reader = new StreamReader(path))
				{
					obj = (XmlObject<T>)serializer.Deserialize(reader);
				}
			}
			#region catch () { ... }
			catch (ArgumentNullException ex)
			{
				throw new XmlSerializerException("Serializer found null argument", ex);
			}
			catch (ArgumentException ex)
			{
				throw new XmlSerializerException(ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new XmlSerializerException("Serializer does not found destination directory", ex);
			}
			catch (IOException ex)
			{
				throw new XmlSerializerException(ex);
			}
			catch (InvalidOperationException ex)
			{
				throw new XmlSerializerException("Serializer found invalid operation", ex);
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException(ex);
			}
			#endregion

			return obj;
		}
		/// <summary>
		/// Reads and loads a serialized file. It will save and load user default values if file is not existing. See <seealso cref="Load{T}(XmlSerializerConfig{T})"/> for default type values.
		/// </summary>
		/// <typeparam name="T">Object where the data will be stored</typeparam>
		/// <param name="config">Serializer config <see cref="XmlSerializerConfig{T}"/></param>
		/// <param name="defaultData">Object containing default values for serialization when file is not exiting.</param>
		/// <returns>Object that holds informations about deserialized data and data version. <see cref="XmlObject{T}"/></returns>

		public static XmlObject<T> Load<T>(XmlSerializerConfig<T> config, XmlObject<T> defaultData)
		{
			string path = config.FilePath;
			if (!File.Exists(path))
			{
				Save(config, defaultData);
			}
			Serial serializer = new Serial(typeof(XmlObject<T>), "MomijiXmlSerializer");
			StreamReader reader = null;
			XmlObject<T> obj = new XmlObject<T>();
			try
			{
				using (reader = new StreamReader(path))
				{
					obj = (XmlObject<T>)serializer.Deserialize(reader);
				}
			}
			#region catch () { ... }
			catch (ArgumentNullException ex)
			{
				throw new XmlSerializerException("Serializer found null argument", ex);
			}
			catch (ArgumentException ex)
			{
				throw new XmlSerializerException(ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new XmlSerializerException("Serializer does not found destination directory", ex);
			}
			catch (IOException ex)
			{
				throw new XmlSerializerException(ex);
			}
			catch (InvalidOperationException ex)
			{
				throw new XmlSerializerException("Serializer found invalid operation", ex);
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException(ex);
			}
			#endregion

			return obj;
		}
		/// <summary>
		/// Serializes and saves data to file.
		/// </summary>
		/// <typeparam name="T">Object where the data will be stored</typeparam>
		/// <param name="config">Serializer config. <see cref="XmlSerializerConfig{T}"/></param>
		/// <param name="data">Deserialized object to save. <see cref="XmlObject{T}"/></param>
		public static void Save<T>(XmlSerializerConfig<T> config, XmlObject<T> data)
		{
			string path = config.FilePath;
			if (!File.Exists(path))
			{
				CreateFile(path);
			}
			Serial serializer = new Serial(typeof(XmlObject<T>), "MomijiXmlSerializer");
			StreamWriter writer = null;
			try
			{
				using (writer = new StreamWriter(path))
				{
					serializer.Serialize(writer, data);
				}
			}
			#region catch() { ... }
			catch (UnauthorizedAccessException ex)
			{
				throw new XmlSerializerException("Serializer found unauthorized access to system resources", ex);
			}
			catch (ArgumentNullException ex)
			{
				throw new XmlSerializerException("Serializer found null argument", ex);
			}
			catch (ArgumentException ex)
			{
				throw new XmlSerializerException(ex);
			}
			catch (PathTooLongException ex)
			{
				throw new XmlSerializerException("Serializer found to long path", ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new XmlSerializerException("Serializer does not found destination directory", ex);
			}
			catch (IOException ex)
			{
				throw new XmlSerializerException(ex);
			}
			catch (SecurityException ex)
			{
				throw new XmlSerializerException("Serializer found security issues", ex);
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException(ex);
			}
			#endregion
		}

		private static void CreateFile(string path)
		{
			if (!File.Exists(path))
			{
				var directory = Path.GetDirectoryName(path);
				if (!Directory.Exists(directory) && directory != "")
				{
					Directory.CreateDirectory(directory);
				}
				try
				{
					File.Create(path).Dispose();
				}
				#region catch () {}
				catch (UnauthorizedAccessException ex)
				{
					throw new XmlSerializerException("Serializer found unauthorized access to system resources", ex);
				}
				catch (ArgumentNullException ex)
				{
					throw new XmlSerializerException("Serializer found null argument", ex);
				}
				catch (ArgumentException ex)
				{
					throw new XmlSerializerException(ex);
				}
				catch (PathTooLongException ex)
				{
					throw new XmlSerializerException("Serializer found to long path", ex);
				}
				catch (DirectoryNotFoundException ex)
				{
					throw new XmlSerializerException("Serializer does not found destination directory", ex);
				}
				catch (IOException ex)
				{
					throw new XmlSerializerException(ex);
				}
				catch (NotSupportedException ex)
				{
					throw new XmlSerializerException("Serializer method is not suported", ex);
				}
				catch (Exception ex)
				{
					throw new XmlSerializerException(ex);
				}
				#endregion
			}
		}
		/// <summary>
		/// Loads and saves data. See <see cref="Load{T}(XmlSerializerConfig{T})"/> and <see cref="Save{T}(XmlSerializerConfig{T}, XmlObject{T})"/> for more info.
		/// </summary>
		/// <typeparam name="T">Object where the data will be stored</typeparam>
		/// <param name="config">Serializer config. <see cref="XmlSerializerConfig{T}"/></param>
		/// <returns>Object that holds informations about deserialized data and data version. <see cref="XmlObject{T}"/></returns>
		public static XmlObject<T> Reload<T>(XmlSerializerConfig<T> config)
		{
			try
			{
				XmlObject<T> data = Load(config);
				Save(config, data);
				return data;
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException("Serializer found exception during reloading resources", ex);
			}
		}
		/// <summary>
		/// Saves and loads data. See <see cref="Save{T}(XmlSerializerConfig{T}, XmlObject{T})"/> and <see cref="Load{T}(XmlSerializerConfig{T})"/> for more info.
		/// </summary>
		/// <typeparam name="T">Object where the data will be stored</typeparam>
		/// <param name="config">Serializer config. <see cref="XmlSerializerConfig{T}"/></param>
		/// <param name="data">Deserialized object to save. <see cref="XmlObject{T}"/></param>
		/// <returns>Object that holds informations about deserialized data and data version. <see cref="XmlObject{T}"/></returns>
		public static XmlObject<T> ReSave<T>(XmlSerializerConfig<T> config, XmlObject<T> data)
		{
			try
			{
				Save(config, data);
				return Load(config);
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException("Serializer found exception during resaving resources", ex);
			}
		}
	}
}
