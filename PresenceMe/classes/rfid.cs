using System;

namespace PresenceMe.classes
{
    class RFID
    {
        //Variables
        public uint UID { get; set; }

        public byte FacilityCode { get; set; }

        public ushort CardNumber { get; set; }

        //Initialization
        public RFID(ushort CardNumber, byte FacilityCode)
        {
            this.FacilityCode = FacilityCode;
            this.CardNumber = CardNumber;

            byte[] cardNumber = BitConverter.GetBytes(this.CardNumber);

            this.UID = (uint)((cardNumber[0] << 24) | (cardNumber[1] << 16) | (this.FacilityCode << 8));
        }

    }
}