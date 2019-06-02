using System;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules
{
	public abstract class MomijiModuleBase : MarshalByRefObject
	{
		private ModuleState _moduleState = ModuleState.Enabled;
		/// <summary>
		/// Version on which module base this module was created for
		/// </summary>
		public Version ModuleBase { get; private set; } = new Version("0.1.5.0");
		private string Hash { get; set; } = "";
		/// <summary>
		/// Guid of main program. It must always be the same as Main program Guid
		/// </summary>
		public Guid CallerGuid { get; private set; } = Guid.Empty;
		/// <summary>
		/// Indendicates if module is enabled and actions can be performed on it
		/// </summary>
		public virtual bool Enabled { get; private set; } = true;
		/// <summary>
		/// Guid of this module. This Guid is indentifing module acros whole program. It is used for example in module searching
		/// </summary>
		public virtual Guid Guid { get; } = Guid.NewGuid();
		/// <summary>
		/// User set module name
		/// </summary>
		public virtual string ModuleName { get; } = "BlankModule";
		/// <summary>
		/// Version of module
		/// </summary>
		public virtual Version Version { get; } = new Version("1.0.0.0");
		/// <summary>
		/// Full module name → Module name folowed by module version
		/// </summary>
		public string FullModuleName { get { return ModuleName + " " + Version; } }
		/// <summary>
		/// Array of Guids on which that module depends on
		/// </summary>
		public virtual Guid[] DependsOn { get; } = { };
		/// <summary>
		/// Indicates in which initialization state this module is in. Cannot be set by user
		/// </summary>
		public InitializationState InitializationState { get; private set; }
		/// <summary>
		/// Indicates if module is enabled, disabled, throwed bigger warning or exception
		/// </summary>
		public ModuleState ModuleState
		{
			get { return _moduleState; }
			set
			{
				OnModuleStateChanged(value, _moduleState);
				_moduleState = value;
			}
		}

		/// <summary>
		/// Default constructor. Shouldn't be called by user. <see cref="MomijiModuleBase.MomijiModuleBase(Guid)"/>
		/// </summary>
		protected MomijiModuleBase()
		{
			try
			{
				if (CallerGuid == Guid.Empty)
				{
					throw new System.Security.SecurityException("Cannot call module for the first time without passing caller GUID");
				}
				else
				{
					throw new System.Security.SecurityException("Cannot call module constructor after first initialization");
				}
			}
			catch { throw; }
		}

		/// <summary>
		/// MomijiModuleBase constructor. This one should be called instead of default.
		/// </summary>
		/// <param name="callerGuid">guid of caller</param>
		protected MomijiModuleBase(Guid callerGuid)
		{
			if (CallerGuid == Guid.Empty)
			{
				CallerGuid = callerGuid;
			}
			else
			{
				throw new System.Security.SecurityException("Cannot call module constructor after first initialization. Caller GUID" + callerGuid);
			}
		}
		/// <summary>
		/// function that shouldn't be called by user
		/// </summary>
		/// <param name="hash"></param>
		public void SetHash(string hash)
		{
			if (Hash == "")
			{
				Hash = hash;
			}
			else
			{
				throw new System.Security.SecurityException("Cannot set module hash after first method call");
			}
		}

		public async Task p_PreInitialize(string key)
		{
			if (!Security.CheckKey(key, Hash))
				throw new System.Security.SecurityException("Found unauthorized call to PreInitialize function");
			InitializationState = InitializationState.PreInitializing;
			await PreInitialize();
			InitializationState = InitializationState.PreInitialized;
		}
		public async Task p_Initialize(string key)
		{
			if (!Security.CheckKey(key, Hash))
				throw new System.Security.SecurityException("Found unauthorized call to Initialize function");
			InitializationState = InitializationState.Initializing;
			await Initialize();
			InitializationState = InitializationState.Initialized;
		}
		public async Task p_PostInitialize(string key)
		{
			if (!Security.CheckKey(key, Hash))
				throw new System.Security.SecurityException("Found unauthorized call to PostInitialize function");
			InitializationState = InitializationState.PostInitializing;
			await PostInitialize();
			InitializationState = InitializationState.Completed;
		}

		/// <summary>
		/// You can run thing like loading config, parsing data before initialization
		/// </summary>
		/// <returns>Task</returns>
		public abstract Task PreInitialize();
		/// <summary>
		/// You can run all main tasks here and/or tasks that depends on other uninitialized modules
		/// </summary>
		/// <returns>Task</returns>
		public abstract Task Initialize();
		/// <summary>
		/// You can run all tasks that depends on other initialized modules
		/// </summary>
		/// <returns>Task</returns>
		public abstract Task PostInitialize();

		public virtual void ChangeState(MomijiModuleBase sender, ModuleStateChangedArgs args)
		{
			
		}
		/// <summary>
		/// Logs message into console
		/// </summary>
		/// <param name="message">message to log</param>
		protected void Log(string message)
		{
			LogEvent?.Invoke(this, message);
		}

		private void OnModuleStateChanged(ModuleState newState, ModuleState oldState)
		{
			ModuleStateEvent?.Invoke(this, new ModuleStateChangedArgs(newState, oldState));
		}

		public event LogEventHandler LogEvent;
		public event ModuleStateHandler ModuleStateEvent;
		public delegate void LogEventHandler(MomijiModuleBase sender, string message);
		public delegate void ModuleStateHandler(MomijiModuleBase sender, ModuleStateChangedArgs args);
	}
}
