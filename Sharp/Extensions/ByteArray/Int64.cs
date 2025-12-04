using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, long value)
        {
            if (destination.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, long value)
            => Unsafe.As<byte, long>(ref destination[index]) = value;

        public static void Insert(this byte[] destination, int index, long value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, long value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            Unsafe.As<byte, long>(ref destination[index]) = value;
        }

        public static bool TryInsert(this byte[] destination, int index, long value)
        {
            if (destination.Length - index < sizeof(long))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, long value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(long))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static long ToInt64(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt64(index);
        }

        public static long DangerousToInt64(this byte[] source, int index)
            => Unsafe.ReadUnaligned<long>(ref source[index]);

        public static long ToInt64(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt64(index, bigEndian);
        }

        public static long DangerousToInt64(this byte[] source, int index, bool bigEndian)
        {
            long value = source.DangerousToInt64(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt64(this byte[] source, int index, out long value)
        {
            value = default;

            if (source.Length - index < sizeof(long))
                return false;

            value = source.DangerousToInt64(index);

            return true;
        }

        public static bool TryToInt64(this byte[] source, int index, bool bigEndian, out long value)
        {
            value = default;

            if (source.Length - index < sizeof(long))
                return false;

            value = source.DangerousToInt64(index, bigEndian);

            return true;
        }
    }
}
