using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class SingleExtensions
    {
        public static float Reverse(this float value)
        {
            uint result = Unsafe.As<float, uint>(ref value);
            result = result.Reverse();

            return Unsafe.As<uint, float>(ref result);
        }

        public static byte[] ToBytes(this float value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this float value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
