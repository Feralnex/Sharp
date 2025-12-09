using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class SpanOfBytesExtensions
    {
        public static void Insert(this Span<byte> destination, int index, long value)
        {
            if (destination.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, long value)
            => Unsafe.As<byte, long>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static void Insert(this Span<byte> destination, int index, long value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, long value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            destination.DangerousInsert(index, value);
        }

        public static bool TryInsert(this Span<byte> destination, int index, long value)
        {
            if (destination.Length - index < sizeof(long))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this Span<byte> destination, int index, long value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(long))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static long ToInt64(this Span<byte> source, int index)
        {
            if (source.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt64(index);
        }

        public static long ToInt64(this ReadOnlySpan<byte> source, int index)
        {
            if (source.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt64(index);
        }

        public static long DangerousToInt64(this Span<byte> source, int index)
            => Unsafe.ReadUnaligned<long>(ref source.DangerousGetReferenceAt(index));

        public static long DangerousToInt64(this ReadOnlySpan<byte> source, int index)
            => Unsafe.ReadUnaligned<long>(ref source.DangerousGetReferenceAt(index));

        public static long ToInt64(this Span<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt64(index, bigEndian);
        }

        public static long ToInt64(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(long))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt64(index, bigEndian);
        }

        public static long DangerousToInt64(this Span<byte> source, int index, bool bigEndian)
        {
            long value = source.DangerousToInt64(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static long DangerousToInt64(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            long value = source.DangerousToInt64(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt64(this Span<byte> source, int index, out long value)
        {
            value = default;

            if (source.Length - index < sizeof(long))
                return false;

            value = source.DangerousToInt64(index);

            return true;
        }

        public static bool TryToInt64(this ReadOnlySpan<byte> source, int index, out long value)
        {
            value = default;

            if (source.Length - index < sizeof(long))
                return false;

            value = source.DangerousToInt64(index);

            return true;
        }

        public static bool TryToInt64(this Span<byte> source, int index, bool bigEndian, out long value)
        {
            value = default;

            if (source.Length - index < sizeof(long))
                return false;

            value = source.DangerousToInt64(index, bigEndian);

            return true;
        }

        public static bool TryToInt64(this ReadOnlySpan<byte> source, int index, bool bigEndian, out long value)
        {
            value = default;

            if (source.Length - index < sizeof(long))
                return false;

            value = source.DangerousToInt64(index, bigEndian);

            return true;
        }
    }
}
