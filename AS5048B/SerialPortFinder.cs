using System;
using System.Collections.Generic;

namespace AS5048B
{
	public class SerialPortFinder
	{
		public SerialPortFinder ()
		{

		}

		public void RefreshPorts()
		{
			var foundPorts = new List<System.IO.Ports.SerialPort> ();
			var bauds = new [] { 4800, 9600, 19200, 38400, 57600, 115200, 230400 };
			var names = System.IO.Ports.SerialPort.GetPortNames ();
			foreach (var name in names)
			{
				var port = new System.IO.Ports.SerialPort (name);

				foreach (var rate in bauds) 
				{
					var expectedString = "AS5048B";
					var expectedBuffer = expectedString.ToCharArray();
					var actualBuffer = new char[expectedString.Length];
					port.BaudRate = rate;
					var read = port.Read (actualBuffer, 0, buffer.Length);
					if (read == 7) {
						try {
							var actualString = new string (actualBuffer);
							if (actualString.Equals (expectedString)) {
								foundPorts.Add (port);
							}
						} catch {
						}
					}
				}
			}
		}
	}
}

