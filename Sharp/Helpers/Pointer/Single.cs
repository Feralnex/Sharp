using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, float value)
        {
            if (length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, float value)
            => *(float*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, float value, bool bigEndian)
        {
            if (length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, float value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(float*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, float value)
        {
            if (length - index < sizeof(float))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, float value, bool bigEndian)
        {
            if (length - index < sizeof(float))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static float ToSingle(byte* source, int length, int index)
        {
            if (length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            return DangerousToSingle(source, index);
        }

        public static float DangerousToSingle(byte* source, int index)
            => *(float*)(source + index);

        public static float ToSingle(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            return DangerousToSingle(source, index, bigEndian);
        }

        public static float DangerousToSingle(byte* source, int index, bool bigEndian)
        {
            float value = DangerousToSingle(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToSingle(byte* source, int length, int index, out float value)
        {
            value = default;

            if (length - index < sizeof(float))
                return false;

            value = DangerousToSingle(source, index);

            return true;
        }

        public static bool TryToSingle(byte* source, int length, int index, bool bigEndian, out float value)
        {
            value = default;

            if (length - index < sizeof(float))
                return false;

            value = DangerousToSingle(source, index, bigEndian);

            return true;
        }
    }
}
