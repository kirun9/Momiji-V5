using System;
using System.IO;
using System.Security;
using Serial = System.Xml.Serialization.XmlSerializer;

namespace Momiji.Bot.V3.Serialization.MultiXmlSerializer
{
	public class MultiXmlSerializer
	{
		public static T Load<T>(MultiXmlSerializerConfig<T> config) where T : new()
		{
			string path = config.FilePath;
			if (!File.Exists(path))
			{
				Save(config);
			}
			Serial serializer = new Serial(typeof(T), config.RegisteredTypes);
			StreamReader reader = null;
			T obj = new T();
			try
			{
				using (reader = new StreamReader(path))
				{
					obj = (T)serializer.Deserialize(reader);
				}
			}
			#region catch () { ... }
			catch (ArgumentNullException ex)
			{
				throw new MultiXmlSerializerException("Serializer found null argument", ex);
			}
			catch (ArgumentException ex)
			{
				throw new MultiXmlSerializerException(ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new MultiXmlSerializerException("Serializer does not found destination directory", ex);
			}
			catch (IOException ex)
			{
				throw new MultiXmlSerializerException(ex);
			}
			catch (InvalidOperationException ex)
			{
				throw new MultiXmlSerializerException("Serializer found invalid operation", ex);
			}
			catch (Exception ex)
			{
				throw new MultiXmlSerializerException(ex);
			}
			#endregion

			return obj;
		}

		public static void Save<T>(MultiXmlSerializerConfig<T> config) where T : new()
		{
			string path = config.FilePath;
			if (!File.Exists(path))
			{
				CreateFile(path);
			}
			Serial serializer = new Serial(typeof(T), config.RegisteredTypes);
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
				throw new MultiXmlSerializerException("Serializer found unauthorized access to system resources", ex);
			}
			catch (ArgumentNullException ex)
			{
				throw new MultiXmlSerializerException("Serializer found null argument", ex);
			}
			catch (ArgumentException ex)
			{
				throw new MultiXmlSerializerException(ex);
			}
			catch (PathTooLongException ex)
			{
				throw new MultiXmlSerializerException("Serializer found to long path", ex);
			}
			catch (DirectoryNotFoundException ex)
			{
				throw new MultiXmlSerializerException("Serializer does not found destination directory", ex);
			}
			catch (IOException ex)
			{
				throw new MultiXmlSerializerException(ex);
			}
			catch (SecurityException ex)
			{
				throw new MultiXmlSerializerException("Serializer found security issues", ex);
			}
			catch (Exception ex)
			{
				throw new MultiXmlSerializerException(ex);
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
					throw new MultiXmlSerializerException("Serializer found unauthorized access to system resources", ex);
				}
				catch (ArgumentNullException ex)
				{
					throw new MultiXmlSerializerException("Serializer found null argument", ex);
				}
				catch (ArgumentException ex)
				{
					throw new MultiXmlSerializerException(ex);
				}
				catch (PathTooLongException ex)
				{
					throw new MultiXmlSerializerException("Serializer found to long path", ex);
				}
				catch (DirectoryNotFoundException ex)
				{
					throw new MultiXmlSerializerException("Serializer does not found destination directory", ex);
				}
				catch (IOException ex)
				{
					throw new MultiXmlSerializerException(ex);
				}
				catch (NotSupportedException ex)
				{
					throw new MultiXmlSerializerException("Serializer method is not suported", ex);
				}
				catch (Exception ex)
				{
					throw new MultiXmlSerializerException(ex);
				}
				#endregion
			}
		}
		public static T Reload<T>(MultiXmlSerializerConfig<T> config) where T : new()
		{
			try
			{
				T obj = Load<T>(config);
				config.Data = obj;
				Save<T>(config);
				return obj;
			}
			catch (Exception ex)
			{
				throw new MultiXmlSerializerException("Serializer found exception during reloading resources", ex);
			}
		}

		public static T ReSave<T>(MultiXmlSerializerConfig<T> config) where T : new()
		{
			try
			{
				Save(config);
				return Load(config);
			}
			catch (Exception ex)
			{
				throw new MultiXmlSerializerException("Serializer found exception during resaving resources", ex);
			}
		}
	}
}
