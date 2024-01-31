using PresenceMe.classes;
using System;
using System.Buffers.Text;
using System.Collections.Generic;

namespace PresenceMe.LocalDatabase
{
    class DBPresenceMe
    {
        //Memory
        public static Dictionary<string, Person> People { get; set; }
        public static Dictionary<UInt32, string> RFIDs { get; set; }


        //Save Config
        public static string SaveFileLocation { get; set; }

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

        static DBPresenceMe()
        {
            People = new Dictionary<string, Person>();
            RFIDs = new Dictionary<UInt32, string>();
        }
    }
}