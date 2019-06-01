using System;
using System.IO;
using System.Security;
using Serial = System.Xml.Serialization.XmlSerializer;

namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	public class XmlSerializer
	{
		public static XmlObject<T> Load<T>(XmlSerializerConfig<T> config)
		{
			string path = config.FilePath;
			if (!File.Exists(path))
			{
				Save(config);
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

		public static void Save<T>(XmlSerializerConfig<T> config)
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
					serializer.Serialize(writer, config.Data);
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

		public static XmlObject<T> Reload<T>(XmlSerializerConfig<T> config)
		{
			try
			{
				XmlObject<T> obj = Load(config);
				config.Data = obj;
				Save(config);
				return obj;
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException("Serializer found exception during reloading resources", ex);
			}
		}

		public static XmlObject<T> ReSave<T>(XmlSerializerConfig<T> config)
		{
			try
			{
				Save(config);
				return Load(config);
			}
			catch (Exception ex)
			{
				throw new XmlSerializerException("Serializer found exception during resaving resources", ex);
			}
		}
	}
}
