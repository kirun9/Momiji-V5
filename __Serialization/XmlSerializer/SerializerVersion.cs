using System;
using System.Xml.Serialization;

namespace Momiji.Bot.V3.Serialization.XmlSerializer
{
	[Serializable]
	public class XmlSerializerVersion
	{
		[XmlIgnore]
		public int Build { get; set; }
		[XmlIgnore]
		public int Major { get; set; }
		[XmlIgnore]
		public int Minor { get; set; }
		[XmlIgnore]
		public int Revision { get; set; }
		[XmlAttribute("Version")]
		public string Version {
			get => string.Format("v{0}.{1}.{2}.{3}", Major, Minor, Build, Revision);
			set {
				var v = value;
				if (v.Length < 7)
					throw new ArgumentException("This is not a valid version format");
				if (v.StartsWith("v", true, System.Globalization.CultureInfo.CurrentCulture))
				{
					v = v.Substring(1);
				}
				var a = v.Split('.');
				Major = Int32.Parse(a[0]);
				Minor = Int32.Parse(a[1]);
				Build = Int32.Parse(a[2]);
				Revision = Int32.Parse(a[3]);
			}
		}

		public XmlSerializerVersion() { }

		public XmlSerializerVersion(string version)
		{
			this.Version = version;
		}

		public override string ToString()
		{
			return string.Format("v{0}.{1}.{2}.{3}", Major, Minor, Build, Revision);
		}

		public static implicit operator XmlSerializerVersion(string s)
		{
			return new XmlSerializerVersion(s);
		}

		public static implicit operator string(XmlSerializerVersion version)
		{
			return version.ToString();
		}

		public static bool operator ==(XmlSerializerVersion v1, XmlSerializerVersion v2) {
			return v1.Major == v2.Major && v1.Minor == v2.Minor && v1.Revision == v2.Revision && v1.Build == v2.Build;
		}
		public static bool operator !=(XmlSerializerVersion v1, XmlSerializerVersion v2) { return !(v1 == v2); }
		public static bool operator >(XmlSerializerVersion v1, XmlSerializerVersion v2)
		{
			if (v1.Major > v2.Major)
			{
				return true;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor > v2.Minor)
				{
					return true;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Revision > v2.Revision)
					{
						return true;
					}
					else if (v1.Revision == v2.Revision)
					{
						if (v1.Build > v2.Build)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		public static bool operator <(XmlSerializerVersion v1, XmlSerializerVersion v2)
		{
			if (v1.Major < v2.Major)
			{
				return true;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor < v2.Minor)
				{
					return true;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Revision < v2.Revision)
					{
						return true;
					}
					else if (v1.Revision == v2.Revision)
					{
						if (v1.Build < v2.Build)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public static bool operator >=(XmlSerializerVersion v1, XmlSerializerVersion v2)
		{
			if (v1.Major > v2.Major)
			{
				return true;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor > v2.Minor)
				{
					return true;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Revision > v2.Revision)
					{
						return true;
					}
					else if (v1.Revision == v2.Revision)
					{
						if (v1.Build > v2.Build)
						{
							return true;
						}
						else if (v1.Build == v2.Build)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
		public static bool operator <=(XmlSerializerVersion v1, XmlSerializerVersion v2)
		{
			if (v1.Major < v2.Major)
			{
				return true;
			}
			else if (v1.Major == v2.Major)
			{
				if (v1.Minor < v2.Minor)
				{
					return true;
				}
				else if (v1.Minor == v2.Minor)
				{
					if (v1.Revision < v2.Revision)
					{
						return true;
					}
					else if (v1.Revision == v2.Revision)
					{
						if (v1.Build < v2.Build)
						{
							return true;
						}
						else if (v1.Build == v2.Build)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
}
