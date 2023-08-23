using PresenceMe.classes;
using PresenceMe.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PresenceMe.packages
{
    static class AttendanceMananger
    {
        public static void NewEntry(int idNumber)
        {

            foreach (var person in db_PresenceMe.People)
            {
                if (person.IdNumber == idNumber)
                {
                    Attendance _attendance = new Attendance();
                    _attendance.FirstName = person.FirstName;
                    _attendance.LastName = person.LastName;
                    _attendance.Id = idNumber;
                    _attendance.Timestamp = DateTime.Now;
                    _attendance.Department = person.Department;
                    

                    //if (db_PresenceMe.LatestAttendance != null && db_PresenceMe.LatestAttendance.Hash.Length == 0)
                    //{
                    //    db_PresenceMe.LatestAttendance.Hash = new byte[] { (byte)1, (byte)0, (byte)1, (byte)0 };
                    //}


                    //_attendance.PreHash = db_PresenceMe.LatestAttendance.Hash;
                    //_attendance.Hash = Encryption.ComputeSha256Hash(_attendance);
                    db_PresenceMe.LatestAttendance = _attendance;

                    FileManager.AppendSave();
                }

            }
        }

        public static void NewEntry()
        {
            NewEntry(idNumber: db_PresenceMe.LatestPerson.IdNumber);
        }
    }
}
