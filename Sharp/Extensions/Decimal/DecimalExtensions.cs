using System;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static partial class DecimalExtensions
    {
        public static decimal Reverse(this decimal value)
        {
            UnsafeDecimal unsafeDecimal = Unsafe.As<decimal, UnsafeDecimal>(ref value);
            int reversedFlags = unsafeDecimal.Flags.Reverse();
            uint reversedHi32 = unsafeDecimal.Hi32.Reverse();
            ulong reversedLo64 = unsafeDecimal.Lo64.Reverse();
            ulong newHi32 = reversedLo64 >> 32;

            unsafeDecimal.Flags = (int)reversedLo64;
            unsafeDecimal.Hi32 = (uint)newHi32;
            unsafeDecimal.Lo64 = reversedHi32 | ((ulong)reversedFlags << 32);

            return Unsafe.As<UnsafeDecimal, decimal>(ref unsafeDecimal);
        }

        public static byte[] ToBytes(this decimal value)
        {
            byte[] bytes = new byte[sizeof(decimal)];

            Unsafe.As<byte, decimal>(ref bytes[0]) = value;

            return bytes;
        }

        public static byte[] ToBytes(this decimal value, bool bigEndian)
        {
            byte[] bytes = new byte[sizeof(decimal)];
            bool shouldReverse = (bigEndian && BitConverter.IsLittleEndian) || (!bigEndian && !BitConverter.IsLittleEndian);

            if (shouldReverse)
                value = value.Reverse();

            Unsafe.As<byte, decimal>(ref bytes[0]) = value;

            return bytes;
        }

        public static int GetFlags(this decimal source)
            => Unsafe.As<decimal, UnsafeDecimal>(ref source).Flags;

        public static decimal SetFlags(ref this decimal source, int value)
            => Unsafe.As<decimal, UnsafeDecimal>(ref source).Flags = value;

        public static uint GetHi32(this decimal source)
            => Unsafe.As<decimal, UnsafeDecimal>(ref source).Hi32;

        public static decimal SetHi32(ref this decimal source, uint value)
            => Unsafe.As<decimal, UnsafeDecimal>(ref source).Hi32 = value;

        public static ulong GetLo64(this decimal source)
            => Unsafe.As<decimal, UnsafeDecimal>(ref source).Lo64;

        public static decimal SetLo64(ref this decimal source, ulong value)
            => Unsafe.As<decimal, UnsafeDecimal>(ref source).Lo64 = value;
    }
}
