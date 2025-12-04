using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, decimal value)
        {
            if (length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, decimal value)
            => *(decimal*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, decimal value, bool bigEndian)
        {
            if (length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, decimal value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(decimal*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, decimal value)
        {
            if (length - index < sizeof(decimal))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, decimal value, bool bigEndian)
        {
            if (length - index < sizeof(decimal))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static decimal ToDecimal(byte* source, int length, int index)
        {
            if (length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            return DangerousToDecimal(source, index);
        }

        public static decimal DangerousToDecimal(byte* source, int index)
            => *(decimal*)(source + index);

        public static decimal ToDecimal(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            return DangerousToDecimal(source, index, bigEndian);
        }

        public static decimal DangerousToDecimal(byte* source, int index, bool bigEndian)
        {
            decimal value = DangerousToDecimal(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToDecimal(byte* source, int length, int index, out decimal value)
        {
            value = default;

            if (length - index < sizeof(decimal))
                return false;

            value = DangerousToDecimal(source, index);

            return true;
        }

        public static bool TryToDecimal(byte* source, int length, int index, bool bigEndian, out decimal value)
        {
            value = default;

            if (length - index < sizeof(decimal))
                return false;

            value = DangerousToDecimal(source, index, bigEndian);

            return true;
        }
    }
}
