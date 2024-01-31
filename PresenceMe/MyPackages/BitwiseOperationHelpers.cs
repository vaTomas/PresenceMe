using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresenceMe.MyPackages
{
    internal static class BitwiseOperationHelpers
    {
        public static uint ConcatenateBits(ushort num1, ushort num2)
        {
            // Convert ushort to uint and concatenate the bits
            uint result = ((uint)num1 << 16) | num2;

            return result;
        }

        public static uint ConcatenateBits(string hex1, string hex2)
        {
            // Parse hexadecimal strings to UInt16
            ushort num1 = Convert.ToUInt16(hex1, 16);
            ushort num2 = Convert.ToUInt16(hex2, 16);

            // Convert UInt16 to UInt32 and concatenate the bits
            uint result = ((uint)num1 << 16) | num2;

            return result;
        }
    }

}
