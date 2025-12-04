using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, ulong value)
        {
            if (destination.Length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, ulong value)
            => Unsafe.As<byte, ulong>(ref destination[index]) = value;

        public static void Insert(this byte[] destination, int index, ulong value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, ulong value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            Unsafe.As<byte, ulong>(ref destination[index]) = value;
        }

        public static bool TryInsert(this byte[] destination, int index, ulong value)
        {
            if (destination.Length - index < sizeof(ulong))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, ulong value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(ulong))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static ulong ToUInt64(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt64(index);
        }

        public static ulong DangerousToUInt64(this byte[] source, int index)
            => Unsafe.ReadUnaligned<ulong>(ref source[index]);

        public static ulong ToUInt64(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(ulong))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt64(index, bigEndian);
        }

        public static ulong DangerousToUInt64(this byte[] source, int index, bool bigEndian)
        {
            ulong value = source.DangerousToUInt64(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToUInt64(this byte[] source, int index, out ulong value)
        {
            value = default;

            if (source.Length - index < sizeof(ulong))
                return false;

            value = source.DangerousToUInt64(index);

            return true;
        }

        public static bool TryToUInt64(this byte[] source, int index, bool bigEndian, out ulong value)
        {
            value = default;

            if (source.Length - index < sizeof(ulong))
                return false;

            value = source.DangerousToUInt64(index, bigEndian);

            return true;
        }
    }
}
