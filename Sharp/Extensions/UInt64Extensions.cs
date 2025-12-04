using System;

namespace Sharp.Extensions
{
    public static class UInt64Extensions
    {
        public static ulong Reverse(this ulong value)
        {
            return ((value & 0x00000000000000FF) << 56)
                | ((value & 0x000000000000FF00) << 40)
                | ((value & 0x0000000000FF0000) << 24)
                | ((value & 0x00000000FF000000) << 8)
                | ((value & 0x000000FF00000000) >> 8)
                | ((value & 0x0000FF0000000000) >> 24)
                | ((value & 0x00FF000000000000) >> 40)
                | ((value & 0xFF00000000000000) >> 56);
        }

        public static byte[] ToBytes(this ulong value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this ulong value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
