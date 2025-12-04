using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class ByteArrayExtensions
    {
        public static void Insert(this byte[] destination, int index, short value)
        {
            if (destination.Length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value);
        }

        public static void DangerousInsert(this byte[] destination, int index, short value)
            => Unsafe.As<byte, short>(ref destination[index]) = value;

        public static void Insert(this byte[] destination, int index, short value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            destination.DangerousInsert(index, value, bigEndian);
        }

        public static void DangerousInsert(this byte[] destination, int index, short value, bool bigEndian)
        {
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            Unsafe.As<byte, short>(ref destination[index]) = value;
        }

        public static bool TryInsert(this byte[] destination, int index, short value)
        {
            if (destination.Length - index < sizeof(short))
                return false;

            destination.DangerousInsert(index, value);

            return true;
        }

        public static bool TryInsert(this byte[] destination, int index, short value, bool bigEndian)
        {
            if (destination.Length - index < sizeof(short))
                return false;

            destination.DangerousInsert(index, value, bigEndian);

            return true;
        }

        public static short ToInt16(this byte[] source, int index)
        {
            if (source.Length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt16(index);
        }

        public static short DangerousToInt16(this byte[] source, int index)
            => Unsafe.ReadUnaligned<short>(ref source[index]);

        public static short ToInt16(this byte[] source, int index, bool bigEndian)
        {
            if (source.Length - index < sizeof(short))
                throw new IndexOutOfRangeException();

            return source.DangerousToInt16(index, bigEndian);
        }

        public static short DangerousToInt16(this byte[] source, int index, bool bigEndian)
        {
            short value = source.DangerousToInt16(index);
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            return value;
        }

        public static bool TryToInt16(this byte[] source, int index, out short value)
        {
            value = default;

            if (source.Length - index < sizeof(short))
                return false;

            value = source.DangerousToInt16(index);

            return true;
        }

        public static bool TryToInt16(this byte[] source, int index, bool bigEndian, out short value)
        {
            value = default;

            if (source.Length - index < sizeof(short))
                return false;

            value = source.DangerousToInt16(index, bigEndian);

            return true;
        }
    }
}
