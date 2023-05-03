using System;

namespace PresenceMe.classes
{
    class abada
    {
        //Variables
        public uint UID { get; set; }
        public byte FacilityCode { get; set; }
        public ushort CardNumber { get; set; }

        //Initialization
        public abada(byte FacilityCode, ushort CardNumber)
        {
            this.FacilityCode = FacilityCode;
            this.CardNumber = CardNumber;

            byte[] cardNumber = BitConverter.GetBytes(this.CardNumber);

            this.UID = (uint)((cardNumber[1] << 24) | (cardNumber[0] << 16) | (this.FacilityCode << 8));
        }

    }
}
