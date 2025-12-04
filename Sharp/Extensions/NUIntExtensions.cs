using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class NUIntExtensions
    {
        public unsafe static nuint Reverse(this nuint value)
        {
            if (sizeof(nuint) == sizeof(uint))
            {
                uint result = Unsafe.As<nuint, uint>(ref value);
                result = result.Reverse();

                return Unsafe.As<uint, nuint>(ref result);
            }
            else
            {
                ulong result = Unsafe.As<nuint, ulong>(ref value);
                result = result.Reverse();

                return Unsafe.As<ulong, nuint>(ref result);
            };
        }

        public static byte[] ToBytes(this nuint value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this nuint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
