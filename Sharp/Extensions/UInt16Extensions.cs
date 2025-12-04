using System;

namespace Sharp.Extensions
{
    public static class UInt16Extensions
    {
        public static ushort Reverse(this ushort value)
        {
            uint result = value;
            result = ((result & 0xFFFF00FF) << 8)
                | ((result & 0xFF00FF00) >> 8);

            return (ushort)result;
        }

        public static byte[] ToBytes(this ushort value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this ushort value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
