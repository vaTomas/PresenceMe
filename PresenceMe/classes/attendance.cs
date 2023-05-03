using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceMe.classes
{
    internal class Attendance
    {
        public byte[] Hash { get; set; }// hash of current attendance
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Timestamp { get; set; }
        public string Department { get; set; }
        public byte[] PreHash { get; set; } //hash of previous attendance
    }
}
