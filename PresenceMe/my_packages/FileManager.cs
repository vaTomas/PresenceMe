using CsvHelper;
using PresenceMe.classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Globalization;
using PresenceMe.database;
using CsvHelper.Configuration;

namespace PresenceMe.packages
{
    static class FileManager
    {
        public static void AppendSave()
        {
            var csvPath = Path.Combine(Environment.CurrentDirectory, "attendanceSheet.csv");
            var data = db_PresenceMe.LatestAttendance;
            File.AppendAllText(csvPath, $"{data.Hash},{data.Timestamp},{data.Id},{data.LastName},{data.FirstName},{data.Department},{data.PreHash}\n");

        }
    }
}
