using System;
using System.Windows.Forms;
using Momiji.Bot.V5.Core.Controls.Installer;

namespace Momiji.Bot.V5.Core
{
	static class Program
	{
		public static readonly bool ENABLE_FILE_LOGGING = true;
		private static ApplicationContext applicationContext;
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

			if (!BotKeyReader.CheckForKey())
			{
				applicationContext = new ApplicationContext(new FirstForm());
			}
			else
			{
				applicationContext = new ApplicationContext(new MainForm());
			}

			Application.Run(applicationContext);

			/*Application.Run(new FirstForm());*/
		}
		internal static void ChangeForm(Form form)
		{
			var tForm = applicationContext.MainForm;
			applicationContext.MainForm = form;
			tForm.Close();
			applicationContext.MainForm.Show();
		}
	}
}
