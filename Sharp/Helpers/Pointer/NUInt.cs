using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, nuint value)
        {
            if (length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, nuint value)
            => *(nuint*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, nuint value, bool bigEndian)
        {
            if (length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, nuint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(nuint*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, nuint value)
        {
            if (length - index < sizeof(nuint))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, nuint value, bool bigEndian)
        {
            if (length - index < sizeof(nuint))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static nuint ToNUInt(byte* source, int length, int index)
        {
            if (length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            return DangerousToNUInt(source, index);
        }

        public static nuint DangerousToNUInt(byte* source, int index)
            => *(nuint*)(source + index);

        public static nuint ToNUInt(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            return DangerousToNUInt(source, index, bigEndian);
        }

        public static nuint DangerousToNUInt(byte* source, int index, bool bigEndian)
        {
            nuint value = DangerousToNUInt(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToNUInt(byte* source, int length, int index, out nuint value)
        {
            value = default;

            if (length - index < sizeof(nuint))
                return false;

            value = DangerousToNUInt(source, index);

            return true;
        }

        public static bool TryToNUInt(byte* source, int length, int index, bool bigEndian, out nuint value)
        {
            value = default;

            if (length - index < sizeof(nuint))
                return false;

            value = DangerousToNUInt(source, index, bigEndian);

            return true;
        }
    }
}
