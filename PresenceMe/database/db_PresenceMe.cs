using PresenceMe.classes;
using System.Collections.Generic;

namespace PresenceMe.database
{
    class db_PresenceMe
    {
        public static List<Person> People { get; set; }
        public static uint LatestRFID { get; set; }
        public static Person LatestPerson { get; set; }
        public static Attendance LatestAttendance { get; set; }
        //public static fileRecord AccessFile { get; set; }
        //public static fileRecord TempFile { get; set; }
        //public static zc_Defaults Defaults { get; set; }


        //public static void CheckIntegrity()
        //{
        //    if (AccessFile == null) { AccessFile = new fileRecord(); }
        //    if (TempFile == null) { TempFile = new fileRecord(); }
        //    if (Accounts == null) { Accounts = new List<Account>(); }
        //    if (Defaults == null) { Defaults = new zc_Defaults(); }
        //}

        //public static void Reset()
        //{
        //    Accounts = new List<Account>();
        //    TempFile = new fileRecord();
        //    AccessFile = new fileRecord();
        //}
    }
}