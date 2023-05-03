using System;
using System.IO.Ports;
using System.Threading;

namespace PresenceMe
{
    internal class SerialRead
    {
        private static SerialPort _serialPort;
        public static void New(string PortnName)
        {


            _serialPort = new SerialPort();
            _serialPort.PortName = "COM6";//Set your board COM
            _serialPort.BaudRate = 9600;
            _serialPort.Open();
            while (true)
            {
                string a = _serialPort.ReadExisting();
                Console.WriteLine(a);
                Thread.Sleep(200);
            }
        }
    }
}