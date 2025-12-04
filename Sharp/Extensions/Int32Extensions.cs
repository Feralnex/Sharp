using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class Int32Extensions
    {
        public static int Reverse(this int value)
        {
            uint result = Unsafe.As<int, uint>(ref value);
            result = result.Reverse();

            return Unsafe.As<uint, int>(ref result);
        }

        public static byte[] ToBytes(this int value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this int value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }

        public static int GetBucketValue(this int input)
        {
            if (input <= 0)
                return 0;

            // Check if input is already a power of two
            if ((input & (input - 1)) == 0)
                return input;

            // Use hardware-accelerated BitOperations
            int leadingZeros = BitOperations.LeadingZeroCount((uint)input);
            int nextPower = 1 << (32 - leadingZeros);

            return nextPower;
        }
    }
}
