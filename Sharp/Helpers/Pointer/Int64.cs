using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, long value)
        {
            if (length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, long value)
            => *(long*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, long value, bool bigEndian)
        {
            if (length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, long value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(long*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, long value)
        {
            if (length - index < sizeof(long))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, long value, bool bigEndian)
        {
            if (length - index < sizeof(long))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static long ToInt64(byte* source, int length, int index)
        {
            if (length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return DangerousToInt64(source, index);
        }

        public static long DangerousToInt64(byte* source, int index)
            => *(long*)(source + index);

        public static long ToInt64(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return DangerousToInt64(source, index, bigEndian);
        }

        public static long DangerousToInt64(byte* source, int index, bool bigEndian)
        {
            long value = DangerousToInt64(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt64(byte* source, int length, int index, out long value)
        {
            value = default;

            if (length - index < sizeof(long))
                return false;

            value = DangerousToInt64(source, index);

            return true;
        }

        public static bool TryToInt64(byte* source, int length, int index, bool bigEndian, out long value)
        {
            value = default;

            if (length - index < sizeof(long))
                return false;

            value = DangerousToInt64(source, index, bigEndian);

            return true;
        }
    }
}
