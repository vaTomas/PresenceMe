using CsvHelper;
using PresenceMe.classes;
using PresenceMe.database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace PresenceMe.src
{
    internal class Database
    {

        public List<Person> People { get; set; }

        public Database()
        {
            using (var streamReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, "people.csv")))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var _protoPersons = csvReader.GetRecords<ProtoPerson>().ToList();



                    var peopleList = new List<Person>();



                    foreach (var _protoPerson in _protoPersons)
                    {
                        ushort _cardNumber = _protoPerson.CardNumber ?? default(ushort);
                        byte _facilityCode = (byte)(_protoPerson.FacilityCode ?? 0);


                        var existingPerson = peopleList.FirstOrDefault(p => p.IdNumber == _protoPerson.IdNumber);


                        int index = peopleList.FindIndex(p => p.IdNumber == _protoPerson.IdNumber);

                        if (index >= 0)
                        {
                            RFID _rfid = new RFID(CardNumber: _cardNumber, FacilityCode: _facilityCode);
                            peopleList[index].RFIDs.Add(_rfid);

                        }
                        else
                        {
                            Person _person = new Person(idNumber: _protoPerson.IdNumber, firstName: _protoPerson.FirstName, lastName: _protoPerson.LastName, department: _protoPerson.Department, cardNumber: _cardNumber, facilityCode: _facilityCode);

                            peopleList.Add(_person);
                        }

                    }
                    db_PresenceMe.People = peopleList;
                }
            }
        }
    }
}
