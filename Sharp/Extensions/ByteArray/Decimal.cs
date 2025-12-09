using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, decimal value)
        {
            if (destination.Length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, decimal value)
            => Unsafe.As<byte, decimal>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static void Insert(this byte[] destination, int index, decimal value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, decimal value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            destination.DangerousInsert(index, value);
        }

        public static bool TryInsert(this byte[] destination, int index, decimal value)
        {
            if (destination.Length - index < sizeof(decimal))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, decimal value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(decimal))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static decimal ToDecimal(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            return source.DangerousToDecimal(index);
        }

        public static decimal DangerousToDecimal(this byte[] source, int index)
            => Unsafe.ReadUnaligned<decimal>(ref source.DangerousGetReferenceAt(index));

        public static decimal ToDecimal(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(decimal))
                throw new IndexOutOfRangeException();

            return source.DangerousToDecimal(index, bigEndian);
        }

        public static decimal DangerousToDecimal(this byte[] source, int index, bool bigEndian)
        {
            decimal value = source.DangerousToDecimal(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToDecimal(this byte[] source, int index, out decimal value)
        {
            value = default;

            if (source.Length - index < sizeof(decimal))
                return false;

            value = source.DangerousToDecimal(index);

            return true;
        }

        public static bool TryToDecimal(this byte[] source, int index, bool bigEndian, out decimal value)
        {
            value = default;

            if (source.Length - index < sizeof(decimal))
                return false;

            value = source.DangerousToDecimal(index, bigEndian);

            return true;
        }
    }
}
