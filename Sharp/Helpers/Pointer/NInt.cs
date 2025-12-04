using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, nint value)
        {
            if (length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, nint value)
            => *(nint*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, nint value, bool bigEndian)
        {
            if (length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, nint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(nint*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, nint value)
        {
            if (length - index < sizeof(nint))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, nint value, bool bigEndian)
        {
            if (length - index < sizeof(nint))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static nint ToNInt(byte* source, int length, int index)
        {
            if (length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            return DangerousToNInt(source, index);
        }

        public static nint DangerousToNInt(byte* source, int index)
            => *(nint*)(source + index);

        public static nint ToNInt(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            return DangerousToNInt(source, index, bigEndian);
        }

        public static nint DangerousToNInt(byte* source, int index, bool bigEndian)
        {
            nint value = DangerousToNInt(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToNInt(byte* source, int length, int index, out nint value)
        {
            value = default;

            if (length - index < sizeof(nint))
                return false;

            value = DangerousToNInt(source, index);

            return true;
        }

        public static bool TryToNInt(byte* source, int length, int index, bool bigEndian, out nint value)
        {
            value = default;

            if (length - index < sizeof(nint))
                return false;

            value = DangerousToNInt(source, index, bigEndian);

            return true;
        }
    }
}
