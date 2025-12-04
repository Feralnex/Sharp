using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public unsafe static void Insert(this byte[] destination, int index, nint value)
        {
            if (destination.Length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, nint value)
            => Unsafe.As<byte, nint>(ref destination[index]) = value;

        public unsafe static void Insert(this byte[] destination, int index, nint value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, nint value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            Unsafe.As<byte, nint>(ref destination[index]) = value;
        }

        public unsafe static bool TryInsert(this byte[] destination, int index, nint value)
        {
            if (destination.Length - index < sizeof(nint))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public unsafe static bool TryInsert(this byte[] destination, int index, nint value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(nint))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public unsafe static nint ToNInt(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            return source.DangerousToNInt(index);
        }

        public static nint DangerousToNInt(this byte[] source, int index)
            => Unsafe.ReadUnaligned<nint>(ref source[index]);

        public unsafe static nint ToNInt(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(nint))
                throw new IndexOutOfRangeException();

            return source.DangerousToNInt(index, bigEndian);
        }

        public static nint DangerousToNInt(this byte[] source, int index, bool bigEndian)
        {
            nint value = source.DangerousToNInt(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public unsafe static bool TryToNInt(this byte[] source, int index, out nint value)
        {
            value = default;

            if (source.Length - index < sizeof(nint))
                return false;

            value = source.DangerousToNInt(index);

            return true;
        }

        public unsafe static bool TryToNInt(this byte[] source, int index, bool bigEndian, out nint value)
        {
            value = default;

            if (source.Length - index < sizeof(nint))
                return false;

            value = source.DangerousToNInt(index, bigEndian);

            return true;
        }
    }
}
