using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momiji.Bot.V5.Modules
{
	public abstract class MomijiModuleBase : MarshalByRefObject
	{
		public static Guid CallerGuid { get; private set; } = Guid.Empty;
		public virtual bool Enabled { get; private set; } = true;
		public virtual Guid Guid { get; } = Guid.NewGuid();
		public virtual string ModuleName { get; } = "BlankModule";
		public Version ModuleBase { get; } = new Version("0.1.0.0");
		public virtual Version Version { get; } = new Version("1.0.0.0");
		public string FullModuleName { get { return ModuleName + " " + Version; } }

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

		public abstract void Initialize();

		protected void Log(string message)
		{
			LogEvent?.Invoke(this, message);
		}

		public event LogEventHandler LogEvent;
		public delegate void LogEventHandler(MomijiModuleBase sender, string message);
	}
}
