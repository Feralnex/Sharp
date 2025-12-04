using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, ushort value)
        {
            if (length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, ushort value)
            => *(ushort*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, ushort value, bool bigEndian)
        {
            if (length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, ushort value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(ushort*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, ushort value)
        {
            if (length - index < sizeof(ushort))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, ushort value, bool bigEndian)
        {
            if (length - index < sizeof(ushort))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static ushort ToUInt16(byte* source, int length, int index)
        {
            if (length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            return DangerousToUInt16(source, index);
        }

        public static ushort DangerousToUInt16(byte* source, int index)
            => *(ushort*)(source + index);

        public static ushort ToUInt16(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            return DangerousToUInt16(source, index, bigEndian);
        }

        public static ushort DangerousToUInt16(byte* source, int index, bool bigEndian)
        {
            ushort value = DangerousToUInt16(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToUInt16(byte* source, int length, int index, out ushort value)
        {
            value = default;

            if (length - index < sizeof(ushort))
                return false;

            value = DangerousToUInt16(source, index);

            return true;
        }

        public static bool TryToUInt16(byte* source, int length, int index, bool bigEndian, out ushort value)
        {
            value = default;

            if (length - index < sizeof(ushort))
                return false;

            value = DangerousToUInt16(source, index, bigEndian);

            return true;
        }
    }
}
