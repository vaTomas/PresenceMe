using System;
using System.IO.Ports;

namespace SerialReadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure the serial port
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = "COM3";  // Replace with the name of your serial port
            serialPort.BaudRate = 9600;   // Set the baud rate
            serialPort.DataBits = 8;      // Set the data bits
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.Open();            // Open the serial port

            // Read data from the serial port
            while (true)
            {
                string data = serialPort.ReadLine();
                Console.WriteLine(data);
            }
        }
    }
}
