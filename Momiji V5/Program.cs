using System;
using System.Windows.Forms;
using Momiji.Bot.V5.Core.Controls.Installer;

namespace Momiji.Bot.V5.Core
{
	static class Program
	{
		public static readonly bool ENABLE_FILE_LOGGING = true;
		public static MainForm mainForm;
		private static ApplicationContext applicationContext;
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			
			new InternalServer.Server();
			InternalServer.Server.StartServer(); //Global error logging

			#region Globalization - Change program language
			var culture = new System.Globalization.CultureInfo("en-US");
			System.Globalization.CultureInfo.DefaultThreadCurrentCulture = culture;
			System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = culture;
			System.Threading.Thread.CurrentThread.CurrentCulture = culture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
			#endregion

			Application.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (!BotKeyReader.CheckForKey())
			{
				applicationContext = new ApplicationContext(new FirstForm());
			}
			else
			{
				applicationContext = new ApplicationContext(mainForm = new MainForm());
			}

			Config.Settings.ReadSettings();

			Application.Run(applicationContext);

			/*Application.Run(new FirstForm());*/
		}
		internal static void ChangeForm(Form form)
		{
			var tForm = applicationContext.MainForm;
			applicationContext.MainForm = form;
			tForm.Close();
			applicationContext.MainForm.Show();
			if (form is MainForm)
			{
				mainForm = form as MainForm;
			}
		}
	}
}
