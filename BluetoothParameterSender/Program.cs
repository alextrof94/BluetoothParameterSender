using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BluetoothParameterSender
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (File.Exists("BluetoothParameterSender.txt"))
			{
				try
				{
					List<string> strs = new List<string>(Environment.GetCommandLineArgs());
					strs.Add(DateTime.Now.Ticks.ToString());
					File.WriteAllLines("BluetoothParameterSender.txt", strs);
				}
				catch
				{

				}
				return;
			} 
			else
			{
				var fs = File.Create("BluetoothParameterSender.txt");
				fs.Close();
			}
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			File.Delete("BluetoothParameterSender.txt");
		}
	}
}
