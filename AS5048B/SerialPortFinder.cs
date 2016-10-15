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
				foundPorts.Add (port);
				foreach (var rate in bauds) 
				{
					var buffer = new byte[] { 0x3F, 0x3F, 0x3F, 0x3F };
					var expectedBuffer = new byte[] { 0xBB, 0xBB, 0xBB, 0xBB };
					port.BaudRate = rate;
					port.Write (buffer, 0, buffer.Length);
					port.Read (buffer, 0, buffer.Length);
					for (int i = 0; i < buffer.Length; i++) {
						if (buffer [i] != expectedBuffer [i]) {
							foundPorts.Remove (port);
							break;
						}
					}
				}
			}
		}
	}
}

