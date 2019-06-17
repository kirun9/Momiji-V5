using Discord.Commands;
using Discord.WebSocket;
using Momiji.Bot.V5.Core.Config;
using Momiji.Bot.V5.Core.Discord;
using Momiji.Bot.V5.Modules;
using Momiji.Bot.V5.Modules.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Core
{
	class ModuleLoader
	{
		public static readonly Version ActualVersion = new Version("0.1.6.0");
		public static readonly Version LastCompatibility = new Version("0.1.5.0");

		private static readonly Guid CallerGuid = Guid.NewGuid();
		private static string Key = Security.GetHash(BotKeyReader.BOT_TOKEN);

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
									var moduleBase = assembly.CreateInstance(type.FullName, false, BindingFlags.CreateInstance, null, new object[] { CallerGuid, MomijiHeart.GetServer }, System.Globalization.CultureInfo.CurrentCulture, null) as MomijiModuleBase;
									moduleBase.SetHash(Security.GetHash(Key + moduleBase.Guid));
									
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
							/*else if (IsSubclassOf(type, "MomijiBot.ModuleManager.MomijiModuleBase"))
							{
								found++;
								Log("Module of type " + type.FullName + " cannot be loaded because it is designed for previous version of Momiji and is not longer compatible.");
							}*/
						}
					} 

					if (Settings.Config == null)//Creating settings if null
					{
						ConfigRoot configRoot = new ConfigRoot();
						configRoot.ConfigModules = new List<ConfigModule>();
						foreach (var module in Modules)
						{
							ConfigModule cModule = new ConfigModule();
							cModule.Enabled = true;
							cModule.Guid = module.Guid;
							cModule.Name = module.ModuleName;
							cModule.ConfigCommands = new List<ConfigCommand>();
							/*if (module is ICommandModule moduleBase)
							{
								foreach (var command in moduleBase.getCommands())
								{
									ConfigCommand c = new ConfigCommand();
									c.Enabled = true;
									c.Guid = command.Guid;
									c.Name = command.Name;
									cModule.ConfigCommands.Add(c);
								}
							}*/
							configRoot.ConfigModules.Add(cModule);
						}
						Settings.Config = configRoot;
						await Settings.SaveConfig();
					}

					foreach (var module in Modules) // Changing state of modules based on config
					{
						module.LogEvent += DiscordInitializer.ModuleBase_LogEvent;
						foreach (var config in Settings.Config?.ConfigModules)
						{
							if (config.Guid == module.Guid)
							{
								module.ModuleState = config.Enabled ? ModuleState.Enabled : ModuleState.Disabled;
								if (!config.Enabled) Log("Module \"" + module.ModuleName + "\" is disabled in config. This module will be skipped during initialization process.", InternalServer.ConsoleMessageType.Info);
							}
						}
						module.ModuleStateEvent += ModuleStateChanged;
					}
					// Get Modules using LINQ
					var EnabledModules = Modules.Where((m) => { return m.Enabled; }).ToList();
					var ConfigModules = Modules.Where((m) => { return m is IConfig; }).ToList();

					Log("Found " + found + " module" + GetS(found));
					if (Modules.Count == 0)
					{
						Log("Skiping process of loading modules due to lack of modules!", InternalServer.ConsoleMessageType.Attention);
						return;
					}

					// Sort Modules
					Modules = SortModules(Modules);

					Log("Loading " + EnabledModules.Count + " module" + GetS(Modules.Count));

					// Load configs on declared modules
					if (ConfigModules.Count > 0)
					{
						Log("Loading configs");
						foreach (var module in ConfigModules)
						{
							await ((IConfig) module).LoadConfig();
						}
					}
					// Update and PreInitialize enabled Modules
					EnabledModules = Modules.Where((m) => { return m.Enabled; }).ToList();
					if (EnabledModules.Count > 0)
					{
						Log("PreInitializing modules");
						foreach (var module in EnabledModules)
						{
							await module.p_PreInitialize(Key + module.Guid);
							while (module.InitializationState != InitializationState.PreInitialized)
							{
								await Task.Delay(1);
							}
						}
					}
					// Update and Load Modules resources
					EnabledModules = Modules.Where((m) => { return m.Enabled; }).ToList();
					foreach (var module in EnabledModules)
					{
						await module.SetServices(
							MomijiHeart.ServiceCollection.First((service) => { return service.ServiceType == typeof(CommandService); }).ImplementationInstance as CommandService,
							MomijiHeart.ServiceCollection.First((service) => { return service.ServiceType == typeof(DiscordSocketClient); }).ImplementationInstance as DiscordSocketClient,
							Key + module.Guid);
					}
					// Add all Modules into Form
					foreach (var module in Modules)
					{
						Program.mainForm.AddModule(module);
					}
					// Update and Load Modules resources
					EnabledModules = Modules.Where((m) => { return m.Enabled; }).ToList();
					if (EnabledModules.Count > 0)
					{
						Log("Loading Modules resources");
						foreach (var module in EnabledModules)
						{
							if (module is IExternalResources resources)
							{
								await resources.LoadResources();
							}
						}
					}
					// Update and Initialize Modules
					EnabledModules = Modules.Where((m) => { return m.Enabled; }).ToList();
					if (EnabledModules.Count > 0)
					{
						Log("Initializing modules");
						foreach (var module in EnabledModules)
						{
							await module.p_Initialize(Key + module.Guid);
							while (module.InitializationState != InitializationState.Initialized)
							{
								await Task.Delay(1);
							}
						}
					}
					// Update and postInitialize modules
					EnabledModules = Modules.Where((m) => { return m.Enabled; }).ToList();
					if (EnabledModules.Count > 0)
					{
						Log("Postinitializing modules");
						foreach (var module in EnabledModules)
						{
							await module.p_PostInitialize(Key + module.Guid);
							while (module.InitializationState != InitializationState.Completed)
							{
								await Task.Delay(1);
							}
						}
					}
					var CommandModules = Modules.Where((m) => { return m is ICommandModule; }).ToList();
					if (CommandModules.Count > 0)
					{
						Log("Adding Commands");
						foreach (var module in CommandModules)
						{
							await DiscordInitializer.Instance.AddCommands(module, ((ICommandModule)module).GetCommandClass());
							//var commandModule = module as ICommandModule;
							//await commandModule.RegisterCommands(DiscordInitializer.Instance.CommandService, DiscordInitializer.Instance.ServiceProvider);
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

		internal static void EnableModule(MomijiModuleBase module)
		{
			Task task = new Task(async () => {
				module.ModuleState = ModuleState.Enabled;
				if (module is IConfig cModule)
				{
					Log("Loading module config: \"" + module.ModuleName + "\"");
					await cModule.LoadConfig();
				}
				Log("PreInitializing module: \"" + module.ModuleName + "\"");
				await module.p_PreInitialize(Key + module.Guid);
				while (module.InitializationState != InitializationState.PreInitialized)
				{
					await Task.Delay(1);
				}
				if (module is IExternalResources resources)
				{
					Log("Loading Module resources: \"" + module.ModuleName + "\"");
					await resources.LoadResources();
				}
				Log("Initializing module: \"" + module.ModuleName + "\"");
				await module.p_Initialize(Key + module.Guid);
				while (module.InitializationState != InitializationState.Initialized)
				{
					await Task.Delay(1);
				}
				Log("Postinitializing module: \"" + module.ModuleName + "\"");
				await module.p_PostInitialize(Key + module.Guid);
				while (module.InitializationState != InitializationState.Completed)
				{
					await Task.Delay(1);
				}
			});
			task.Start();
		}

		internal static void DisableModule(MomijiModuleBase module)
		{
			Task task = new Task(async () =>
			{
				if (module is IConfig cModule)
				{
					await cModule.SaveConfig();
				}
				if (module is IExternalResources rModule)
				{
					await rModule.SaveResources();
				}
				if (module is ICustomDisable cdModule)
				{
					await cdModule.Disable();
				}
			});
			task.Start();
		}

		private static void ModuleStateChanged(MomijiModuleBase sender, ModuleStateChangedArgs args)
		{
			var configModule = Settings.Config.ConfigModules.First((m) => { return m.Guid == sender.Guid; });
			configModule.Enabled = !args.NewState.HasFlag(ModuleState.DisableModule);

			foreach (var module in Modules)
			{
				if (module.Guid == sender.Guid)
					continue;
				ModuleState state = 0;
				foreach (var guid in module.DependsOn)
				{
					if (guid == sender.Guid)
					{
						if (module.ModuleState.HasFlag(ModuleState.ThrowWarningOnChilds))
						{
							state |= ModuleState.ThrowWarningOnChilds | ModuleState.ChangedByInternalScript;
						}
					}
				}
				if (module is IRecieveWarningEvents mod)
				{
					mod.OnDependModuleWarning(sender.Guid, args);
				}
				module.ModuleState = state;
			}
			Settings.SaveConfig();
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
			Log("Please check and eventually fix Sort Module funcion!\n" +
				"Known things to do:\n" +
				" • Check if warning is thrown on others modules\n" +
				" • Check with more modules (even with names like \"A\", \"B\", \"C\")", InternalServer.ConsoleMessageType.Attention);
			List<TempModule> Modules = Translate(modules);
			List<TempModule> Sorted = new List<TempModule>();

			while (Modules.Count > 0)
			{
				for (int i = 0; i < Modules.Count; i++)
				{
					TempModule module = Modules[i];
					int found = 0;
					int found2 = 0;
					for (int j = 0; j < module.Parents.Count; j++)
					{
						if (module.Parents[j] != module.Guid)
						{
							for (int k = 0; k < Modules.Count; k++)
							{
								if (module.Parents[j] == Modules[k].Guid)
								{
									if (Modules[k].State.HasFlag(ModuleState.ThrowWarningOnChilds))
									{
										module.State |= ModuleState.ThrowWarningOnChilds | ModuleState.ChangedByInternalScript;
									}
									found++;
								}
							}
							for (int k = 0; k < Sorted.Count; k++)
							{
								if (module.Parents[j] == Sorted[k].Guid)
								{
									if (Sorted[k].State.HasFlag(ModuleState.ThrowWarningOnChilds))
									{
										module.State |= ModuleState.ThrowWarningOnChilds | ModuleState.ChangedByInternalScript;
									}
									found++;
									found2++;
								}
							}
						}
						else
						{
							Modules.Remove(module);
							Log("Module cannot have itself as dependecy module!\nModule " + module.Name + " will not be loaded.", InternalServer.ConsoleMessageType.Attention);
						}
					}
					if (found < module.Parents.Count)
					{
						Modules.Remove(module);
						Log("Module " + module.Name + " will not be loaded. Cannot find all modules on which this module depends on!", InternalServer.ConsoleMessageType.Attention);
					}
					else if (found2 == module.Parents.Count)
					{
						Sorted.Add(module);
						Modules.Remove(module);
					}
				}
			}

			/*int disabledModules = 0;
			for (var i = 0; i < Sorted.Count; i++)
			{
				var item = Sorted[i];
				if (item.State.HasFlag(ModuleState.DisableModule))
				{
					Sorted.Remove(item);
					disabledModules++;
					i--;
				}
			}*/
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
				m.State = module.ModuleState;
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
						module.ModuleState = tempModule.State;
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
			Console.Log("Module Manager", message, InternalServer.ConsoleMessageType.Heart);
		}
		public static void Log(string message, InternalServer.ConsoleMessageType type)
		{
			Console.Log("Module Manager", message, type);
		}
		public static void Log(Exception ex)
		{
			Console.Log("Module Manager", ex.ToString(), InternalServer.ConsoleMessageType.Warning);
		}
	}
}
