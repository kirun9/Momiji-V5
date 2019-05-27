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
		public static readonly Version ActualVersion = new Version("0.1.2.0");
		public static readonly Version LastCompatibility = new Version("0.1.0.0");

		private static readonly Guid CallerGuid = Guid.NewGuid();

		internal static List<MomijiModuleBase> Modules = new List<MomijiModuleBase>();

		public static async Task LoadModules()
		{
			try
			{
				while (!DiscordInitializer.Instance.Initialized)
				{
					await Task.Delay(1);
				}
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
					if (Modules.Count == 0)
					{
						Log("Skiping process of loading modules due to lack of modules!", InternalServer.ConsoleMessageType.Attention);
						return;
					}
					Modules = SortModules(Modules);
					Log("Loading " + Modules.Count + " module" + GetS(Modules.Count));
					Log("PreInitializing modules");
					foreach (var module in Modules)
					{
						await module.p_PreInitialize();
						while (module.InitializationState != InitializationState.PreInitialized)
						{
							await Task.Delay(1);
						}
					}
					Log("Initializing modules");
					foreach (var module in Modules)
					{
						await module.p_Initialize();
						while (module.InitializationState != InitializationState.Initialized)
						{
							await Task.Delay(1);
						}
					}
					Log("Postinitializing modules");
					foreach (var module in Modules)
					{
						await module.p_PostInitialize();
						while (module.InitializationState != InitializationState.Completed)
						{
							await Task.Delay(1);
						}
					}

				}
				else
				{
					Directory.CreateDirectory(path);
				}
			}
			catch (Exception ex)
			{
				throw new MomijiHeartException("Caught exception during module initialization. Cannot continue.", ex);
			}
		}

		private static ModuleCompatible CheckCompatibility(MomijiModuleBase module)
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

		private static string GetS(int num)
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

		private static bool IsSubclassOf(Type type, string name)
		{
			do
			{
				if (type.FullName.Equals(name)) return true;
			}
			while ((type = type.BaseType) != null);
			return false;
		}

		private static List<MomijiModuleBase> SortModules(List<MomijiModuleBase> modules)
		{
			List<TempModule> Items = Translate(modules);
			List<TempModule> Sorted = new List<TempModule>();

			while (Items.Count > 0)
			{
				for (int i = 0; i < Items.Count; i++)
				{
					TempModule item = Items[i];
					int found = 0;
					int found2 = 0;
					for (int j = 0; j < item.Parents.Count; j++)
					{
						if (item.Parents[j] != item.Guid)
						{
							for (int k = 0; k < Items.Count; k++)
							{
								if (item.Parents[j] == Items[k].Guid)
								{
									found++;
								}
							}
							for (int k = 0; k < Sorted.Count; k++)
							{
								if (item.Parents[j] == Sorted[k].Guid)
								{
									found++;
									found2++;
								}
							}
						}
						else
						{
							Items.Remove(item);
							Log("Module cannot have itself as dependecy module!\nModule " + item.Name + " will not be loaded.", InternalServer.ConsoleMessageType.Attention);
						}
					}
					if (found < item.Parents.Count)
					{
						Items.Remove(item);
						Log("Module " + item.Name + " will not be loaded. Cannot find all modules on which this module depends on!", InternalServer.ConsoleMessageType.Attention);
					}
					else if (found2 == item.Parents.Count)
					{
						Sorted.Add(item);
						Items.Remove(item);
					}
				}
			}
			if (Sorted.Count != modules.Count)
				throw new MomijiHeartException("Number of sorted modules is different than unsorted.");

			return Translate(Sorted, modules);
		}

		private static List<TempModule> Translate(List<MomijiModuleBase> modules)
		{
			List<TempModule> temp = new List<TempModule>();
			foreach (var module in modules)
			{
				TempModule m = new TempModule(module.Guid, module.ModuleName);
				foreach (var dependOn in module.DependsOn)
				{
					m.AddParent(dependOn);
				}
				temp.Add(m);
			}
			if (temp.Count != modules.Count)
				throw new MomijiHeartException("Something went wrong during translating unsorted modules. Number of modules does not match.");
			return temp;
		}

		private static List<MomijiModuleBase> Translate(List<TempModule> tempModules, List<MomijiModuleBase> modules)
		{
			List<MomijiModuleBase> temp = new List<MomijiModuleBase>();
			foreach (var tempModule in tempModules)
			{
				foreach (var module in modules)
				{
					if (tempModule.Guid == module.Guid)
					{
						temp.Add(module);
					}
				}
			}
			if (temp.Count != modules.Count)
				throw new MomijiHeartException("Something went wrong during translating sorted modules. Number of modules does not match.");
			return temp;
		}

		public static void Log(string message)
		{
			InternalServer.Server.Log("Module Manager", message, InternalServer.ConsoleMessageType.Heart);
		}
		public static void Log(string message, InternalServer.ConsoleMessageType type)
		{
			InternalServer.Server.Log("Module Manager", message, type);
		}
		public static void Log(Exception ex)
		{
			InternalServer.Server.Log("Module Manager", ex.ToString(), InternalServer.ConsoleMessageType.Warning);
		}
	}
}
