using System;
using System.Windows.Forms;

namespace Momiji.Bot.V5.Core
{
	static class Program
	{
		public static readonly bool ENABLE_FILE_LOGGING = false;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			new InternalServer.Server();
			InternalServer.Server.StartServer(); //Global error logging
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
