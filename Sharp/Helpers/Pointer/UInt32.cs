using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, uint value)
        {
            if (length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, uint value)
            => *(uint*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, uint value, bool bigEndian)
        {
            if (length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, uint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(uint*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, uint value)
        {
            if (length - index < sizeof(uint))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, uint value, bool bigEndian)
        {
            if (length - index < sizeof(uint))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static uint ToUInt32(byte* source, int length, int index)
        {
            if (length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            return DangerousToUInt32(source, index);
        }

        public static uint DangerousToUInt32(byte* source, int index)
            => *(uint*)(source + index);

        public static uint ToUInt32(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            return DangerousToUInt32(source, index, bigEndian);
        }

        public static uint DangerousToUInt32(byte* source, int index, bool bigEndian)
        {
            uint value = DangerousToUInt32(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToUInt32(byte* source, int length, int index, out uint value)
        {
            value = default;

            if (length - index < sizeof(uint))
                return false;

            value = DangerousToUInt32(source, index);

            return true;
        }

        public static bool TryToUInt32(byte* source, int length, int index, bool bigEndian, out uint value)
        {
            value = default;

            if (length - index < sizeof(uint))
                return false;

            value = DangerousToUInt32(source, index, bigEndian);

            return true;
        }
    }
}
