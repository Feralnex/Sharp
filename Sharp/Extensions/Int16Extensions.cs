using System;

namespace Sharp.Extensions
{
    public static class Int16Extensions
    {
        public static short Reverse(this short value)
        {
            uint result = (uint)value;

            result = ((result & 0xFFFF00FF) << 8)
                | ((result & 0xFF00FF00) >> 8);

            return (short)result;
        }

        public static byte[] ToBytes(this short value)
            => BitConverter.GetBytes(value);

        public static byte[] ToBytes(this short value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return BitConverter.GetBytes(value);
        }
    }
}
