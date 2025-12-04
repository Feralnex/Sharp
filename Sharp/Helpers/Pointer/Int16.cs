using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, short value)
        {
            if (length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, short value)
            => *(short*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, short value, bool bigEndian)
        {
            if (length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, short value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(short*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, short value)
        {
            if (length - index < sizeof(short))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, short value, bool bigEndian)
        {
            if (length - index < sizeof(short))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static short ToInt16(byte* source, int length, int index)
        {
            if (length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            return DangerousToInt16(source, index);
        }

        public static short DangerousToInt16(byte* source, int index)
            => *(short*)(source + index);

        public static short ToInt16(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            return DangerousToInt16(source, index, bigEndian);
        }

        public static short DangerousToInt16(byte* source, int index, bool bigEndian)
        {
            short value = DangerousToInt16(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt16(byte* source, int length, int index, out short value)
        {
            value = default;

            if (length - index < sizeof(short))
                return false;

            value = DangerousToInt16(source, index);

            return true;
        }

        public static bool TryToInt16(byte* source, int length, int index, bool bigEndian, out short value)
        {
            value = default;

            if (length - index < sizeof(short))
                return false;

            value = DangerousToInt16(source, index, bigEndian);

            return true;
        }
    }
}
