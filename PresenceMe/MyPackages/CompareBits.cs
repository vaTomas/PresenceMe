using System;

namespace PresenceMe.MyPackages
{
    internal static class CompareBits
    {
        public static bool Compare(uint obj, uint reference, int startBit, int endBit)
        {
            // Validate input parameters
            if (startBit < 0 || startBit > 31 || endBit < 0 || endBit > 31 || startBit > endBit)
            {
                throw new ArgumentException("Invalid start or end bit positions");
            }

            // Create a bitmask for the specified range
            uint mask = ((1u << (endBit - startBit + 1)) - 1) << startBit;

            // Extract and compare the bits in the specified range
            return (obj & mask) == (reference & mask);
        }
    }
}
