using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, uint value)
        {
            if (destination.Length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, uint value)
            => Unsafe.As<byte, uint>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static void Insert(this byte[] destination, int index, uint value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, uint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

			destination.DangerousInsert(index, value);
		}

        public static bool TryInsert(this byte[] destination, int index, uint value)
        {
            if (destination.Length - index < sizeof(uint))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, uint value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(uint))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static uint ToUInt32(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt32(index);
        }

        public static uint DangerousToUInt32(this byte[] source, int index)
            => Unsafe.ReadUnaligned<uint>(ref source.DangerousGetReferenceAt(index));

        public static uint ToUInt32(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(uint))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt32(index, bigEndian);
        }

        public static uint DangerousToUInt32(this byte[] source, int index, bool bigEndian)
        {
            uint value = source.DangerousToUInt32(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToUInt32(this byte[] source, int index, out uint value)
        {
            value = default;

            if (source.Length - index < sizeof(uint))
                return false;

            value = source.DangerousToUInt32(index);

            return true;
        }

        public static bool TryToUInt32(this byte[] source, int index, bool bigEndian, out uint value)
        {
            value = default;

            if (source.Length - index < sizeof(uint))
                return false;

            value = source.DangerousToUInt32(index, bigEndian);

            return true;
        }
    }
}
