using PresenceMe.classes;
using PresenceMe.database;

namespace PresenceMe.packages
{
    static class IdentityCheck
    {
        public static Person GetPerson(uint UID)
        {
            UID = BitwiseHelper.ReplaceLast8BitsWithZero(UID);


            foreach (var person in db_PresenceMe.People)
            {
                foreach (var rfid in person.RFIDs)
                {
                    if (rfid.UID == UID)
                    {
                        db_PresenceMe.LatestPerson = person;
                        return person;
                    }
                }
            }
            return null;
        }


        public static Person GetPerson()
        {
            return GetPerson(db_PresenceMe.LatestRFID);
        }
    }








    static class BitwiseHelper
    {
        public static uint ReplaceLast8BitsWithZero(uint input)
        {
            uint mask = 0xFFFFFF00; // set the last 8 bits to 0
            uint result = input & mask;
            return result;
        }
    }




}
