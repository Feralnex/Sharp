using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class SpanOfBytesExtensions
    {
        public static void Insert(this Span<byte> destination, int index, bool value)
        {
            if (destination.Length - index < sizeof(bool))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, bool value)
            => Unsafe.As<byte, bool>(ref destination.DangerousGetReferenceAt(index)) = value;

        public static bool TryInsert(this Span<byte> destination, int index, bool value)
        {
            if (destination.Length - index < sizeof(bool))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool ToBool(this Span<byte> source, int index)
        {
            if (source.Length - index < sizeof(bool))
                throw new IndexOutOfRangeException();

            return source.DangerousToBool(index);
        }

        public static bool ToBool(this ReadOnlySpan<byte> source, int index)
        {
            if (source.Length - index < sizeof(bool))
                throw new IndexOutOfRangeException();

            return source.DangerousToBool(index);
        }

        public static bool DangerousToBool(this Span<byte> source, int index)
            => Unsafe.ReadUnaligned<bool>(ref source.DangerousGetReferenceAt(index));

        public static bool DangerousToBool(this ReadOnlySpan<byte> source, int index)
            => Unsafe.ReadUnaligned<bool>(ref source.DangerousGetReferenceAt(index));

        public static bool TryToBool(this Span<byte> source, int index, out bool value)
        {
            value = default;

            if (source.Length - index < sizeof(bool))
                return false;

            value = source.DangerousToBool(index);

            return true;
        }

        public static bool TryToBool(this ReadOnlySpan<byte> source, int index, out bool value)
        {
            value = default;

            if (source.Length - index < sizeof(bool))
                return false;

            value = source.DangerousToBool(index);

            return true;
        }
    }
}
