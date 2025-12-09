using CommunityToolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class SpanOfBytesExtensions
    {
        public unsafe static void Insert(this Span<byte> destination, int index, nuint value)
        {
            if (destination.Length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, nuint value)
            => Unsafe.As<byte, nuint>(ref destination.DangerousGetReferenceAt(index)) = value;

        public unsafe static void Insert(this Span<byte> destination, int index, nuint value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this Span<byte> destination, int index, nuint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            destination.DangerousInsert(index, value);
        }

        public unsafe static bool TryInsert(this Span<byte> destination, int index, nuint value)
        {
            if (destination.Length - index < sizeof(nuint))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public unsafe static bool TryInsert(this Span<byte> destination, int index, nuint value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(nuint))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public unsafe static nuint ToNUInt(this Span<byte> source, int index)
        {
            if (source.Length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            return source.DangerousToNUInt(index);
        }

        public unsafe static nuint ToNUInt(this ReadOnlySpan<byte> source, int index)
        {
            if (source.Length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            return source.DangerousToNUInt(index);
        }

        public static nuint DangerousToNUInt(this Span<byte> source, int index)
            => Unsafe.ReadUnaligned<nuint>(ref source.DangerousGetReferenceAt(index));

        public static nuint DangerousToNUInt(this ReadOnlySpan<byte> source, int index)
            => Unsafe.ReadUnaligned<nuint>(ref source.DangerousGetReferenceAt(index));

        public unsafe static nuint ToNUInt(this Span<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            return source.DangerousToNUInt(index, bigEndian);
        }

        public unsafe static nuint ToNUInt(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(nuint))
                throw new IndexOutOfRangeException();

            return source.DangerousToNUInt(index, bigEndian);
        }

        public static nuint DangerousToNUInt(this Span<byte> source, int index, bool bigEndian)
        {
            nuint value = source.DangerousToNUInt(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static nuint DangerousToNUInt(this ReadOnlySpan<byte> source, int index, bool bigEndian)
        {
            nuint value = source.DangerousToNUInt(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public unsafe static bool TryToNUInt(this Span<byte> source, int index, out nuint value)
        {
            value = default;

            if (source.Length - index < sizeof(nuint))
                return false;

            value = source.DangerousToNUInt(index);

            return true;
        }

        public unsafe static bool TryToNUInt(this ReadOnlySpan<byte> source, int index, out nuint value)
        {
            value = default;

            if (source.Length - index < sizeof(nuint))
                return false;

            value = source.DangerousToNUInt(index);

            return true;
        }

        public unsafe static bool TryToNUInt(this Span<byte> source, int index, bool bigEndian, out nuint value)
        {
            value = default;

            if (source.Length - index < sizeof(nuint))
                return false;

            value = source.DangerousToNUInt(index, bigEndian);

            return true;
        }

        public unsafe static bool TryToNUInt(this ReadOnlySpan<byte> source, int index, bool bigEndian, out nuint value)
        {
            value = default;

            if (source.Length - index < sizeof(nuint))
                return false;

            value = source.DangerousToNUInt(index, bigEndian);

            return true;
        }
    }
}
