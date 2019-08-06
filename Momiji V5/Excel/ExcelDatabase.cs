using System;
using System.IO;
using Discord.WebSocket;
using Microsoft.Office.Interop.Excel;

namespace Momiji.Bot.V5.Core.Excel
{
	public class ExcelDatabase
	{
		private static string path = @"C:\Users\Krystian\Desktop\TestFile.xlsx";
		private static Application excelClass = new Application();
		private static Workbook workbook;
		private static bool opened = false;
		private static void OpenWorkbook()
		{
			if (File.Exists(path))
			{
				workbook = excelClass.Workbooks.Open(path);
			}
			else
			{
				workbook = excelClass.Workbooks.Add();
			}
			opened = true;
		}
		public static void SaveAndCloseWorkbook()
		{
			workbook.Save();
			workbook.Close();
			excelClass.Quit();
			opened = false;
		}
		private static void UpdateWorksheet(string tableName, Action<Worksheet> action)
		{
			if (!opened)
				OpenWorkbook();
			Worksheet worksheet = null;
			for (int i = 1; i <= workbook.Worksheets.Count; i++)
			{
				Worksheet table = workbook.Worksheets.Item[i];
				if (table.Name == tableName)
				{
					worksheet = table;
				}
			}
			if (worksheet == null)
			{
				workbook.Worksheets.Add();
				workbook.Worksheets.Item[workbook.Worksheets.Count].Name = tableName;
				worksheet = workbook.Worksheets.Item[workbook.Worksheets.Count];
			}
			action.Invoke(worksheet);
			workbook.Save();
		}

		public static void CommandExecuted(Guid commandGuid, SocketUser user)
		{

			UpdateWorksheet("Commands", (tab) =>
			{
				System.Drawing.Point pos = new System.Drawing.Point(2, 2);
				System.Drawing.Rectangle range = new System.Drawing.Rectangle(2, 2, 0, 0);
				while (tab.Cells[1, range.Right].Value2?.ToString() != null)
				{
					range.Width++;
				}
				while (tab.Cells[range.Bottom, 1].Value2?.ToString() != null)
				{
					range.Height++;
				}
				while (pos.X < range.Right && tab.Cells[1, pos.X].Value2?.ToString() != commandGuid.ToString())
				{
					pos.X++;
				}
				while (pos.Y < range.Bottom && tab.Cells[pos.Y, 1].Value2?.ToString() != user.Id + "")
				{
					pos.Y++;
				}
				if (tab.Cells[1, pos.X].Value2?.ToString() == null)
				{
					tab.Cells[1, pos.X].Value2 = commandGuid.ToString();
					for (int y = range.Y; y < range.Bottom; y++)
					{
						tab.Cells[y, pos.X].Value2 = "0";
					}
					range.Width++;
				}
				if (tab.Cells[pos.Y, 1].Value2?.ToString() == null)
				{
					tab.Cells[pos.Y, 1].Value2 = user.Id;
					for (int x = range.X; x < range.Right; x++)
					{
						tab.Cells[pos.Y, x].Value2 = "0";
					}
					range.Height++;
				}
				var t = tab.Cells[pos.Y, pos.X].Value2?.ToString();
				Int32.TryParse(t, out int used);
				tab.Cells[pos.Y, pos.X].Value2 = (used + 1) + "";
			});
		}
	}
}
