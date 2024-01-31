using PresenceMe.classes;
using PresenceMe.LocalDatabase;
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
using PresenceMe.MyPackages;
using PresenceMe.src;

namespace PresenceMe.Forms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UInt32 rfid = Convert.ToUInt32(txtInput.Text);
                txtInput.Text = "";

                //lblSerialData.Text = $"We Found {RFIDManager.findMatchingKey(rfid).ToString()}";

                string owner = RFIDManager.RetrieveOwner(rfid);
                if(owner != null)
                {
                    lblSerialData.Text = $"We Found {RFIDManager.RetrieveOwner(rfid).ToString()} {DBPresenceMe.LocalData.People[owner].IdNumber}";
                }
                else
                {
                    lblSerialData.Text = "ID Not found";
                }
                

                //UInt32 referenceNumber = BitwiseOperationHelpers.ConcatenateBits("2D", "26AE");


                //bool test_result = MyPackages.CompareBits.Compare(rfid, referenceNumber, 0, 23);
                //lblSerialData.Text = $"{rfid} is {test_result} {referenceNumber}";

                //byte[] ulid = Ulid.NewUlid().ToByteArray();
                //db_PresenceMe.LatestRFID = rfid;
                //db_PresenceMe.RFIDs.Add(rfid, ulid);
                //lblSerialData.Text = rfid.ToString();



                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void fromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1; // Set the default filter to "Excel files (*.xlsx)"

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Get the selected file path
                string filePath = openFileDialog.FileName;

                ImportManager.ReadExcelFile(filePath);

                JsonSerializerOptions options = new JsonSerializerOptions();

                options.WriteIndented = true;

                string jsonString = JsonSerializer.Serialize<Dictionary<string, Person>>(DBPresenceMe.LocalData.People, options);
                File.WriteAllText("people.json", jsonString);

                jsonString = JsonSerializer.Serialize<Dictionary<UInt32, string>>(DBPresenceMe.LocalData.RFIDs, options);
                File.WriteAllText("rfids.json", jsonString);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.SaveAs();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.Save();
        }

        private void oPenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveManager.Open();
        }
    }
}
