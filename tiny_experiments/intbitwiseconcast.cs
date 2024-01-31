using System;

class Program
{
    static void Main()
    {
        ushort num1 = 123;
        ushort num2 = 652;

        uint result = ConcatenateBits(num1, num2);

        Console.WriteLine($Concatenated bits of {num1} and {num2} {result});
    }

    static uint ConcatenateBits(ushort num1, ushort num2)
    {
         Convert ushort to uint and concatenate the bits
        uint result = ((uint)num1  16)  num2;

        return result;
    }
}