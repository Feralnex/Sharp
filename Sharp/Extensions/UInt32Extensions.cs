using System;

namespace Sharp.Extensions
{
    public static class UInt32Extensions
    {
        public static uint Reverse(this uint value)
        {
            return ((value & 0x000000FF) << 24)
                | ((value & 0x0000FF00) << 8)
                | ((value & 0x00FF0000) >> 8)
                | ((value & 0xFF000000) >> 24);
        }

        public static byte[] ToBytes(this uint value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this uint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
