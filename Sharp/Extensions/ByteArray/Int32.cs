using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, int value)
        {
            if (destination.Length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, int value)
            => Unsafe.As<byte, int>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static void Insert(this byte[] destination, int index, int value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, int value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

			destination.DangerousInsert(index, value);
		}

        public static bool TryInsert(this byte[] destination, int index, int value)
        {
            if (destination.Length - index < sizeof(int))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, int value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(int))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static int ToInt32(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt32(index);
        }

        public static int DangerousToInt32(this byte[] source, int index)
            => Unsafe.ReadUnaligned<int>(ref source.DangerousGetReferenceAt(index));

        public static int ToInt32(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(int))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt32(index, bigEndian);
        }

        public static int DangerousToInt32(this byte[] source, int index, bool bigEndian)
        {
            int value = source.DangerousToInt32(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt32(this byte[] source, int index, out int value)
        {
            value = default;

            if (source.Length - index < sizeof(int))
                return false;

            value = source.DangerousToInt32(index);

            return true;
        }

        public static bool TryToInt32(this byte[] source, int index, bool bigEndian, out int value)
        {
            value = default;

            if (source.Length - index < sizeof(int))
                return false;

            value = source.DangerousToInt32(index, bigEndian);

            return true;
        }
    }
}
