using PresenceMe.classes;
using System;
using System.Collections.Generic;

namespace PresenceMe.LocalDatabase
{
    internal class DBPile
    {
        public Dictionary<string, Person> People { get; set; } = new Dictionary<string, Person>();
        public Dictionary<UInt32, string> RFIDs { get; set; } = new Dictionary<UInt32, string>();
    }
}