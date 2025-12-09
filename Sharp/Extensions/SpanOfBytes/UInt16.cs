using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class SpanOfBytesExtensions
    {
        public static void Insert(this Span<byte> destination, int index, ushort value)
        {
            if (destination.Length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, ushort value)
            => Unsafe.As<byte, ushort>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static void Insert(this Span<byte> destination, int index, ushort value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, ushort value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            destination.DangerousInsert(index, value);
        }

        public static bool TryInsert(this Span<byte> destination, int index, ushort value)
        {
            if (destination.Length - index < sizeof(ushort))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this Span<byte> destination, int index, ushort value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(ushort))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static ushort ToUInt16(this ReadOnlySpan<byte> source, int index)
        {
            if (source.Length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt16(index);
        }

        public static ushort ToUInt16(this Span<byte> source, int index)
        {
            if (source.Length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt16(index);
        }

        public static ushort DangerousToUInt16(this Span<byte> source, int index)
            => Unsafe.ReadUnaligned<ushort>(ref source.DangerousGetReferenceAt(index));

        public static ushort DangerousToUInt16(this ReadOnlySpan<byte> source, int index)
            => Unsafe.ReadUnaligned<ushort>(ref source.DangerousGetReferenceAt(index));

        public static ushort ToUInt16(this Span<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt16(index, bigEndian);
        }

        public static ushort ToUInt16(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(ushort))
                throw new IndexOutOfRangeException();

            return source.DangerousToUInt16(index, bigEndian);
        }

        public static ushort DangerousToUInt16(this Span<byte> source, int index, bool bigEndian)
        {
            ushort value = source.DangerousToUInt16(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static ushort DangerousToUInt16(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            ushort value = source.DangerousToUInt16(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToUInt16(this Span<byte> source, int index, out ushort value)
        {
            value = default;

            if (source.Length - index < sizeof(ushort))
                return false;

            value = source.DangerousToUInt16(index);

            return true;
        }

        public static bool TryToUInt16(this ReadOnlySpan<byte> source, int index, out ushort value)
        {
            value = default;

            if (source.Length - index < sizeof(ushort))
                return false;

            value = source.DangerousToUInt16(index);

            return true;
        }

        public static bool TryToUInt16(this Span<byte> source, int index, bool bigEndian, out ushort value)
        {
            value = default;

            if (source.Length - index < sizeof(ushort))
                return false;

            value = source.DangerousToUInt16(index, bigEndian);

            return true;
        }

        public static bool TryToUInt16(this ReadOnlySpan<byte> source, int index, bool bigEndian, out ushort value)
        {
            value = default;

            if (source.Length - index < sizeof(ushort))
                return false;

            value = source.DangerousToUInt16(index, bigEndian);

            return true;
        }
    }
}
