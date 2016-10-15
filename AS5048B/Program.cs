using System;
using Gtk;

namespace AS5048B
{
	class MainClass
	{
		internal static SerialPortFinder portFinder;
		public static void Main (string[] args)
		{
			portFinder = new SerialPortFinder ();
			portFinder.RefreshPorts ();

			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();


		}
	}
}
