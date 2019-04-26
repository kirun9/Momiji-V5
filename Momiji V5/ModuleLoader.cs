using Momiji.Bot.V5.Modules;
using Momiji.Bot.V5.Core.Discord;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core
{
	class ModuleLoader
	{
		public static readonly Version ActualVersion = new Version("0.1.0.0");
		public static readonly Version LastCompatibility = new Version("0.1.0.0");

		private static readonly Guid CallerGuid = Guid.NewGuid();

		public static List<MomijiModuleBase> Modules = new List<MomijiModuleBase>();


		public async Task LoadModules()
		{
			var path = Path.Combine("modules");
			if (Directory.Exists(path))
			{
				List<Assembly> assemblies = new List<Assembly>();
				DirectoryInfo info = new DirectoryInfo(path);
				var DLLModuleFiles = Directory.GetFiles(info.FullName, "*.dll", SearchOption.AllDirectories);

				foreach (var DLLModuleFile in DLLModuleFiles)
				{
					var assembly = Assembly.LoadFile(DLLModuleFile);
					assemblies.Add(assembly);
				}
				int found = 0;
				foreach (var assembly in assemblies)
				{
					foreach (var type in assembly.GetExportedTypes())
					{
						if (type.IsSubclassOf(typeof(MomijiModuleBase)))
						{
							AppDomain.CurrentDomain.Load(assembly.GetName()); // Can it be there?
							try
							{
								found++;
								var moduleBase = assembly.CreateInstance(type.FullName, false, BindingFlags.CreateInstance, null, new object[] { CallerGuid }, System.Globalization.CultureInfo.CurrentCulture, null) as MomijiModuleBase;
								//moduleBase = assembly.CreateInstance(type.FullName) as MomijiModuleBase;
								var compatibility = CheckCompatibility(moduleBase);
								if (compatibility == ModuleCompatible.Match)
								{
									Modules.Add(moduleBase);
								}
								else
								{
									if (compatibility == ModuleCompatible.New)
									{
										Log("Module " + moduleBase.FullModuleName + " will not be loaded.\nModule is not supported yet.\nModule is probably designed for newer versions of module loader.");
									}
									else
									{
										Log("Module " + moduleBase.FullModuleName + " will not be loaded.\nModule is not longer supported and need be updated.");
									}
								}
							}
							catch (Exception ex)
							{
								Log(ex);
							}
						}
						else if (IsSubclassOf(type, "MomijiBot.ModuleManager.MomijiModuleBase"))
						{
							found++;
							Log("Module of type " + type.FullName + " cannot be loaded because it is designed for previous version of Momiji and is not longer compatible.");
						}
					}
				}
				foreach (var module in Modules)
				{
					module.LogEvent += DiscordInitializer.ModuleBase_LogEvent;
				}
				Log("Found " + found + " module" + GetS(found));
				Log("Loading " + Modules.Count + " module" + GetS(Modules.Count));
				foreach (var module in Modules)
				{
					module.Initialize();
				}
			}
			else
			{
				Directory.CreateDirectory(path);
			}
		}

		public ModuleCompatible CheckCompatibility(MomijiModuleBase module)
		{
			if (module.ModuleBase < LastCompatibility)
			{
				return ModuleCompatible.Old;
			}
			else if (module.ModuleBase > ActualVersion)
			{
				return ModuleCompatible.New;
			}
			else
			{
				return ModuleCompatible.Match;
			}
		}

		public string GetS(int num)
		{
			if (num == 1)
			{
				return "";
			}
			else
			{
				return "s";
			}
		}

		public bool IsSubclassOf(Type type, string name)
		{
			do
			{
				if (type.FullName.Equals(name)) return true;
			}
			while ((type = type.BaseType) != null);
			return false;
		}

		public static void Log(string message)
		{
			InternalServer.Server.Log("Module Manager", message, InternalServer.ConsoleMessageType.Heart);
		}
		public static void Log(Exception ex)
		{
			InternalServer.Server.Log("Module Manager", ex.ToString(), InternalServer.ConsoleMessageType.Warning);
		}
	}
}
