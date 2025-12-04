using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class Int64Extensions
    {
        public static long Reverse(this long value)
        {
            ulong result = Unsafe.As<long, ulong>(ref value);
            result = result.Reverse();

            return Unsafe.As<ulong, long>(ref result);
        }

        public static byte[] ToBytes(this long value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this long value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
