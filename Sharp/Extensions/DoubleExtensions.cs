using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class DoubleExtensions
    {
        public static double Reverse(this double value)
        {
            ulong result = Unsafe.As<double, ulong>(ref value);
            result = result.Reverse();

            return Unsafe.As<ulong, double>(ref result);
        }

        public static byte[] ToBytes(this double value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this double value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
