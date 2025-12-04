using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, double value)
        {
            if (destination.Length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, double value)
            => Unsafe.As<byte, double>(ref destination[index]) = value;

        public static void Insert(this byte[] destination, int index, double value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, double value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            Unsafe.As<byte, double>(ref destination[index]) = value;
        }

        public static bool TryInsert(this byte[] destination, int index, double value)
        {
            if (destination.Length - index < sizeof(double))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, double value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(double))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static double ToDouble(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            return source.DangerousToDouble(index);
        }

        public static double DangerousToDouble(this byte[] source, int index)
            => Unsafe.ReadUnaligned<double>(ref source[index]);

        public static double ToDouble(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(double))
                throw new IndexOutOfRangeException();

            return source.DangerousToDouble(index, bigEndian);
        }

        public static double DangerousToDouble(this byte[] source, int index, bool bigEndian)
        {
            double value = source.DangerousToDouble(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToDouble(this byte[] source, int index, out double value)
        {
            value = default;

            if (source.Length - index < sizeof(double))
                return false;

            value = source.DangerousToDouble(index);

            return true;
        }

        public static bool TryToDouble(this byte[] source, int index, bool bigEndian, out double value)
        {
            value = default;

            if (source.Length - index < sizeof(double))
                return false;

            value = source.DangerousToDouble(index, bigEndian);

            return true;
        }
    }
}
