using PresenceMe.classes;
using System;
using System.Collections.Generic;

namespace PresenceMe.LocalDatabase
{
    static class DBPresenceMe
    {
        // Memory
        public static DBPile LocalData { get; set; }

        // Save Config
        public static string SaveFileLocation { get; set; }

        static DBPresenceMe()
        {
            LocalData = new DBPile
            {
                People = LocalData?.People ?? new Dictionary<string, Person>(),
                RFIDs = LocalData?.RFIDs ?? new Dictionary<UInt32, string>()
            };
        }
    }
}