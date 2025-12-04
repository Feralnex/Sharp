using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, int value)
        {
            if (length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, int value)
            => *(int*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, int value, bool bigEndian)
        {
            if (length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, int value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(int*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, int value)
        {
            if (length - index < sizeof(int))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, int value, bool bigEndian)
        {
            if (length - index < sizeof(int))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static int ToInt32(byte* source, int length, int index)
        {
            if (length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            return DangerousToInt32(source, index);
        }

        public static int DangerousToInt32(byte* source, int index)
            => *(int*)(source + index);

        public static int ToInt32(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            return DangerousToInt32(source, index, bigEndian);
        }

        public static int DangerousToInt32(byte* source, int index, bool bigEndian)
        {
            int value = DangerousToInt32(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt32(byte* source, int length, int index, out int value)
        {
            value = default;

            if (length - index < sizeof(int))
                return false;

            value = DangerousToInt32(source, index);

            return true;
        }

        public static bool TryToInt32(byte* source, int length, int index, bool bigEndian, out int value)
        {
            value = default;

            if (length - index < sizeof(int))
                return false;

            value = DangerousToInt32(source, index, bigEndian);

            return true;
        }
    }
}
