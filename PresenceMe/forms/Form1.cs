using PresenceMe.classes;
using PresenceMe.database;
using PresenceMe.packages;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PresenceMe.forms
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        private StringBuilder dataBuffer;

        public Form1()
        {
            InitializeComponent();

            //Database database = new Database();

            serialPort = new SerialPort();
            serialPort.PortName = "COM6";
            serialPort.BaudRate = 9600;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.Open();

            dataBuffer = new StringBuilder();
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine();
            dataBuffer.Append(data);

            ushort _pass = 0;
            ;
            if (dataBuffer.Length >= 32)
            {
                Invoke(new Action(() =>
                {
                    try
                    {
                        string binaryStr = Regex.Replace(dataBuffer.ToString(), "[^01]", "");
                        binaryStr = binaryStr.Remove(0, 1);
                        binaryStr = binaryStr.PadLeft(32, '0');

                        db_PresenceMe.LatestRFID = (uint)Convert.ToInt32((binaryStr), 2);

                        Person _person = IdentityCheck.GetPerson();

                        if (_person != null)
                        {
                            lblSerialData.Text = $"{_person.FirstName} {_person.LastName} - {_person.IdNumber}";
                            dataBuffer.Clear();

                            AttendanceMananger.NewEntry();
                        lblOutput.Text = $"| Timestamp: {db_PresenceMe.LatestAttendance.Timestamp} | Department: {db_PresenceMe.LatestAttendance.Department}";
                        }
                        else
                        {
                            ;
                            lblSerialData.Text = $"Invalid RFID";
                            dataBuffer.Clear();
                        }
                        dataBuffer.Clear();


                    }
                    catch
                    {
                        ;
                        lblSerialData.Text = $"Unexpected Error";
                        dataBuffer.Clear();
                    }





                }));
                dataBuffer.Clear();
            }
            else
            {
                if (_pass >= 4)
                {
                    dataBuffer.Clear ();
                }
                _pass += 1;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort.Close();
        }
    }
}
