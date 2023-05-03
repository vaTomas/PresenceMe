using CsvHelper.Configuration.Attributes;
using System.Collections.Generic;

namespace PresenceMe.classes
{
    internal class ProtoPerson
    {
        [Name("user_id")]
        public int IdNumber { get; set; }

        [Name("first_name")]
        public string FirstName { get; set; }

        [Name("last_name")]
        public string LastName { get; set; }

        [Name("department")]
        public string Department { get; set; }

        [Name("facility_code")]
        public ushort? FacilityCode { get; set; }

        [Name("card_number")]
        public ushort? CardNumber { get; set; }


    }

    internal class Person
    {
        public int IdNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Department { get; set; }

        public List<RFID> RFIDs { get; set; }

        public Person(int idNumber, string firstName, string lastName, string department, List<RFID> rfids)
        {
            this.IdNumber = idNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Department = department;
            this.RFIDs = rfids;
        }

        public Person(int idNumber, string firstName, string lastName, string department, ushort cardNumber, byte facilityCode)
        {
            RFID _rfid = new RFID(CardNumber: cardNumber, FacilityCode: facilityCode);
            List<RFID> _rfids = new List<RFID>();
            _rfids.Add(_rfid);
            this.IdNumber = idNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Department = department;
            this.RFIDs = _rfids;
        }

    }
}
