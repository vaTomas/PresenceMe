using System;
using System.Collections.Generic;

namespace PresenceMe.classes
{    internal class Person
    {
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Program { get; set; }
        public Person(int idNumber, string firstName, string lastName, string program)
        {
            this.IdNumber = idNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Program = program;
        }
    }
}
