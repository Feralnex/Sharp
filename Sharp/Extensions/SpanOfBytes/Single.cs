using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class SpanOfBytesExtensions
    {
        public static void Insert(this Span<byte> destination, int index, float value)
        {
            if (destination.Length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, float value)
            => Unsafe.As<byte, float>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static void Insert(this Span<byte> destination, int index, float value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, float value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            destination.DangerousInsert(index, value);
        }

        public static bool TryInsert(this Span<byte> destination, int index, float value)
        {
            if (destination.Length - index < sizeof(float))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this Span<byte> destination, int index, float value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(float))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static float ToSingle(this Span<byte> source, int index)
        {
            if (source.Length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            return source.DangerousToSingle(index);
        }

        public static float ToSingle(this ReadOnlySpan<byte> source, int index)
        {
            if (source.Length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            return source.DangerousToSingle(index);
        }

        public static float DangerousToSingle(this Span<byte> source, int index)
            => Unsafe.ReadUnaligned<float>(ref source.DangerousGetReferenceAt(index));

        public static float DangerousToSingle(this ReadOnlySpan<byte> source, int index)
            => Unsafe.ReadUnaligned<float>(ref source.DangerousGetReferenceAt(index));

        public static float ToSingle(this Span<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            return source.DangerousToSingle(index, bigEndian);
        }

        public static float ToSingle(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(float))
                throw new IndexOutOfRangeException();

            return source.DangerousToSingle(index, bigEndian);
        }

        public static float DangerousToSingle(this Span<byte> source, int index, bool bigEndian)
        {
            float value = source.DangerousToSingle(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static float DangerousToSingle(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            float value = source.DangerousToSingle(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToSingle(this Span<byte> source, int index, out float value)
        {
            value = default;

            if (source.Length - index < sizeof(float))
                return false;

            value = source.DangerousToSingle(index);

            return true;
        }

        public static bool TryToSingle(this ReadOnlySpan<byte> source, int index, out float value)
        {
            value = default;

            if (source.Length - index < sizeof(float))
                return false;

            value = source.DangerousToSingle(index);

            return true;
        }

        public static bool TryToSingle(this Span<byte> source, int index, bool bigEndian, out float value)
        {
            value = default;

            if (source.Length - index < sizeof(float))
                return false;

            value = source.DangerousToSingle(index, bigEndian);

            return true;
        }

        public static bool TryToSingle(this ReadOnlySpan<byte> source, int index, bool bigEndian, out float value)
        {
            value = default;

            if (source.Length - index < sizeof(float))
                return false;

            value = source.DangerousToSingle(index, bigEndian);

            return true;
        }
    }
}
