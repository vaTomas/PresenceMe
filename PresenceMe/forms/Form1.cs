using PresenceMe.classes;
using PresenceMe.database;
using PresenceMe.packages;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
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
        }


        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                lblSerialData.Text = txtInput.Text;
                txtInput.Text = "";


                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
