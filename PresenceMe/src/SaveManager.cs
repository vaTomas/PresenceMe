using PresenceMe.classes;
using PresenceMe.LocalDatabase;
using PresenceMe.MyPackages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Windows.Forms;

namespace PresenceMe.src
{
    internal static class SaveManager //manages save files of the application
    {
        private static void StoreDataToFile()
        {
            DBPile saveFileObject = DBPresenceMe.LocalData;

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            
            byte[] jsonBytes = JsonSerializer.SerializeToUtf8Bytes<DBPile>(saveFileObject, options);
            File.WriteAllBytes(DBPresenceMe.SaveFileLocation, jsonBytes);

        }


        private static void LoadDataFromFile()
        {
            if (File.Exists(DBPresenceMe.SaveFileLocation))
            {
                byte[] jsonBytes = File.ReadAllBytes(DBPresenceMe.SaveFileLocation);
                DBPile saveFileObject = JsonSerializer.Deserialize<DBPile>(jsonBytes);

                DBPresenceMe.LocalData = saveFileObject;
            }
        }



        public static void Open()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PresenceMe Files (*.prem)|*.prem|All Files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Title = "Open File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DBPresenceMe.SaveFileLocation = openFileDialog.FileName;
                    LoadDataFromFile();
                }
            }
        }


        public static void Save() {
            try
            {
                if (!string.IsNullOrWhiteSpace(DBPresenceMe.SaveFileLocation))
                {
                    StoreDataToFile();
                }
                else
                {
                    SaveAs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public static void SaveAs()
        {
            try
            {
                // Create an instance of SaveFileDialog
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // Set properties for the SaveFileDialog
                    saveFileDialog.Filter = "PresenceMe Files (*.prem)|*.prem|All Files (*.*)|*.*";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.Title = "Save As";
                    saveFileDialog.FileName = "*.prem"; // Set a default file name if needed

                    if (!string.IsNullOrWhiteSpace(DBPresenceMe.SaveFileLocation))
                    {
                        saveFileDialog.FileName = Path.GetFileName(DBPresenceMe.SaveFileLocation);
                    }


                    // Show the SaveFileDialog and check if the user clicked OK
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        DBPresenceMe.SaveFileLocation = saveFileDialog.FileName;
                        StoreDataToFile();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
