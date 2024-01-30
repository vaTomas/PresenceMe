using PresenceMe.classes;
using PresenceMe.database;
using System;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace PresenceMe.forms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) {
                UInt32 rfid = Convert.ToUInt32(txtInput.Text);
                txtInput.Text = "";

                byte[] ulid = Ulid.NewUlid().ToByteArray();
                db_PresenceMe.LatestRFID = rfid;
                db_PresenceMe.RFIDs.Add(rfid, ulid);
                lblSerialData.Text = rfid.ToString();

                JsonSerializerOptions options = new JsonSerializerOptions(); 
                options.WriteIndented = true;

                string jsonString = JsonSerializer.Serialize<Dictionary<UInt32, byte[]>>(db_PresenceMe.RFIDs, options);
                File.WriteAllText("txtInput.json", jsonString);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
