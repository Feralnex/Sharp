using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, ulong value)
        {
            if (length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, ulong value)
            => *(ulong*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, ulong value, bool bigEndian)
        {
            if (length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, ulong value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(ulong*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, ulong value)
        {
            if (length - index < sizeof(ulong))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, ulong value, bool bigEndian)
        {
            if (length - index < sizeof(ulong))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static ulong ToUInt64(byte* source, int length, int index)
        {
            if (length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            return DangerousToUInt64(source, index);
        }

        public static ulong DangerousToUInt64(byte* source, int index)
            => *(ulong*)(source + index);

        public static ulong ToUInt64(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            return DangerousToUInt64(source, index, bigEndian);
        }

        public static ulong DangerousToUInt64(byte* source, int index, bool bigEndian)
        {
            ulong value = DangerousToUInt64(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToUInt64(byte* source, int length, int index, out ulong value)
        {
            value = default;

            if (length - index < sizeof(ulong))
                return false;

            value = DangerousToUInt64(source, index);

            return true;
        }

        public static bool TryToUInt64(byte* source, int length, int index, bool bigEndian, out ulong value)
        {
            value = default;

            if (length - index < sizeof(ulong))
                return false;

            value = DangerousToUInt64(source, index, bigEndian);

            return true;
        }
    }
}
