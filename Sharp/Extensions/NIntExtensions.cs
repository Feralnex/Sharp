using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class NIntExtensions
    {
        public static nint Reverse(this nint value)
        {
            nuint result = Unsafe.As<nint, nuint>(ref value);
            result = result.Reverse();

            return Unsafe.As<nuint, nint>(ref result);
        }

        public static byte[] ToBytes(this nint value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this nint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
