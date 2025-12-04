using Sharp.Extensions;
using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, double value)
        {
            if (length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, double value)
            => *(double*)(destination + index) = value;

        public static void Insert(byte* destination, int length, int index, double value, bool bigEndian)
        {
            if (length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value, bigEndian);
        }

        public static void DangerousInsert(byte* destination, int index, double value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            *(double*)(destination + index) = value;
        }

        public static bool TryInsert(byte* destination, int length, int index, double value)
        {
            if (length - index < sizeof(double))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool TryInsert(byte* destination, int length, int index, double value, bool bigEndian)
        {
            if (length - index < sizeof(double))
                return false;

            DangerousInsert(destination, index, value, bigEndian);

            return true;
        }

        public static double ToDouble(byte* source, int length, int index)
        {
            if (length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            return DangerousToDouble(source, index);
        }

        public static double DangerousToDouble(byte* source, int index)
            => *(double*)(source + index);

        public static double ToDouble(byte* source, int length, int index, bool bigEndian)
        {
            if (length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            return DangerousToDouble(source, index, bigEndian);
        }

        public static double DangerousToDouble(byte* source, int index, bool bigEndian)
        {
            double value = DangerousToDouble(source, index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToDouble(byte* source, int length, int index, out double value)
        {
            value = default;

            if (length - index < sizeof(double))
                return false;

            value = DangerousToDouble(source, index);

            return true;
        }

        public static bool TryToDouble(byte* source, int length, int index, bool bigEndian, out double value)
        {
            value = default;

            if (length - index < sizeof(double))
                return false;

            value = DangerousToDouble(source, index, bigEndian);

            return true;
        }
    }
}
