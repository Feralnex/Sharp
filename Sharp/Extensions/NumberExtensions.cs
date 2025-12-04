using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;

namespace Sharp.Extensions
{
    public static class NumberExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int DangerousIndexOfAnyNumberExcept<TValue>(this ref TValue searchSpace, TValue value, int index, int length)
            where TValue : struct, INumber<TValue>
        {
            if (!Vector128.IsHardwareAccelerated || length < Vector128<TValue>.Count)
            {
                nuint castedIndex = (nuint)index;

                while (length >= 8)
                {
                    length -= 8;

                    if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 1) == value)) goto Found1;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 2) == value)) goto Found2;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 3) == value)) goto Found3;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 4) == value)) goto Found4;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 5) == value)) goto Found5;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 6) == value)) goto Found6;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 7) == value)) goto Found7;

                    castedIndex += 8;
                }

                if (length >= 4)
                {
                    length -= 4;

                    if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 1) == value)) goto Found1;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 2) == value)) goto Found2;
                    if (!(Unsafe.Add(ref searchSpace, castedIndex + 3) == value)) goto Found3;

                    castedIndex += 4;
                }

                while (length > 0)
                {
                    length -= 1;

                    if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;

                    castedIndex += 1;
                }
                return -1;
                Found7:
                return (int)(castedIndex + 7);
                Found6:
                return (int)(castedIndex + 6);
                Found5:
                return (int)(castedIndex + 5);
                Found4:
                return (int)(castedIndex + 4);
                Found3:
                return (int)(castedIndex + 3);
                Found2:
                return (int)(castedIndex + 2);
                Found1:
                return (int)(castedIndex + 1);
                Found:
                return (int)(castedIndex);
            }
            else if (Vector512.IsHardwareAccelerated && length >= Vector512<TValue>.Count)
            {
                Vector512<TValue> current, values = Vector512.Create(value);
                ref TValue currentSearchSpace = ref searchSpace;
                ref TValue oneVectorAwayFromEnd = ref Unsafe.Add(ref searchSpace, length - Vector512<TValue>.Count);

                // Loop until either we've finished all elements or there's less than a vector's-worth remaining.
                do
                {
                    current = Vector512.LoadUnsafe(ref currentSearchSpace);

                    if (!Vector512.EqualsAll(values, current))
                    {
                        return ComputeFirstIndex(ref searchSpace, ref currentSearchSpace, ~Vector512.Equals(values, current));
                    }

                    currentSearchSpace = ref Unsafe.Add(ref currentSearchSpace, Vector512<TValue>.Count);
                }
                while (!Unsafe.IsAddressGreaterThan(ref currentSearchSpace, ref oneVectorAwayFromEnd));

                // If any elements remain, process the last vector in the search space.
                if ((uint)length % Vector512<TValue>.Count != 0)
                {
                    current = Vector512.LoadUnsafe(ref oneVectorAwayFromEnd);

                    if (!Vector512.EqualsAll(values, current))
                    {
                        return ComputeFirstIndex(ref searchSpace, ref oneVectorAwayFromEnd, ~Vector512.Equals(values, current));
                    }
                }
            }
            else if (Vector256.IsHardwareAccelerated && length >= Vector256<TValue>.Count)
            {
                Vector256<TValue> current, values = Vector256.Create(value);
                ref TValue currentSearchSpace = ref searchSpace;
                ref TValue oneVectorAwayFromEnd = ref Unsafe.Add(ref searchSpace, length - Vector256<TValue>.Count);

                // Loop until either we've finished all elements or there's less than a vector's-worth remaining.
                do
                {
                    current = Vector256.LoadUnsafe(ref currentSearchSpace);

                    if (!Vector256.EqualsAll(values, current))
                    {
                        return ComputeFirstIndex(ref searchSpace, ref currentSearchSpace, ~Vector256.Equals(values, current));
                    }

                    currentSearchSpace = ref Unsafe.Add(ref currentSearchSpace, Vector256<TValue>.Count);
                }
                while (!Unsafe.IsAddressGreaterThan(ref currentSearchSpace, ref oneVectorAwayFromEnd));

                // If any elements remain, process the last vector in the search space.
                if ((uint)length % Vector256<TValue>.Count != 0)
                {
                    current = Vector256.LoadUnsafe(ref oneVectorAwayFromEnd);

                    if (!Vector256.EqualsAll(values, current))
                    {
                        return ComputeFirstIndex(ref searchSpace, ref oneVectorAwayFromEnd, ~Vector256.Equals(values, current));
                    }
                }
            }
            else
            {
                Vector128<TValue> current, values = Vector128.Create(value);
                ref TValue currentSearchSpace = ref searchSpace;
                ref TValue oneVectorAwayFromEnd = ref Unsafe.Add(ref searchSpace, length - Vector128<TValue>.Count);

                // Loop until either we've finished all elements or there's less than a vector's-worth remaining.
                while (!Unsafe.IsAddressGreaterThan(ref currentSearchSpace, ref oneVectorAwayFromEnd))
                {
                    current = Vector128.LoadUnsafe(ref currentSearchSpace);

                    if (!Vector128.EqualsAll(values, current))
                    {
                        return ComputeFirstIndex(ref searchSpace, ref currentSearchSpace, ~Vector128.Equals(values, current));
                    }

                    currentSearchSpace = ref Unsafe.Add(ref currentSearchSpace, Vector128<TValue>.Count);
                }

                // If any elements remain, process the last vector in the search space.
                if ((uint)length % Vector128<TValue>.Count != 0)
                {
                    current = Vector128.LoadUnsafe(ref oneVectorAwayFromEnd);

                    if (!Vector128.EqualsAll(values, current))
                    {
                        return ComputeFirstIndex(ref searchSpace, ref oneVectorAwayFromEnd, ~Vector128.Equals(values, current));
                    }
                }
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int DangerousIndexOfAnyNumberExcept<TValue>(this ref TValue searchSpace, TValue value, int index, int length, int offset)
            where TValue : struct, INumber<TValue>
        {
            if (length < 0 || offset < 1)
                return -1;
            if (offset == 1)
                return searchSpace.DangerousIndexOfAnyNumberExcept(value, index, length);

            nuint castedOffset = (nuint)offset;
            nuint castedIndex = (nuint)index;

            while (length >= 8 * offset)
            {
                length -= 8 * offset;

                if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + castedOffset) == value)) goto Found1;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 2 * castedOffset) == value)) goto Found2;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 3 * castedOffset) == value)) goto Found3;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 4 * castedOffset) == value)) goto Found4;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 5 * castedOffset) == value)) goto Found5;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 6 * castedOffset) == value)) goto Found6;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 7 * castedOffset) == value)) goto Found7;

                castedIndex += 8 * castedOffset;
            }

            if (length >= 4 * offset)
            {
                length -= 4 * offset;

                if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;
                if (!(Unsafe.Add(ref searchSpace, castedIndex +  castedOffset) == value)) goto Found1;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 2 * castedOffset) == value)) goto Found2;
                if (!(Unsafe.Add(ref searchSpace, castedIndex + 3 * castedOffset) == value)) goto Found3;

                castedIndex += 4 * castedOffset;
            }

            while (length > offset)
            {
                length -= offset;

                if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;

                castedIndex += castedOffset;
            }

            if (!(Unsafe.Add(ref searchSpace, castedIndex) == value)) goto Found;

            return -1;
            Found7:
            return (int)(castedIndex + 7 * castedOffset);
            Found6:
            return (int)(castedIndex + 6 * castedOffset);
            Found5:
            return (int)(castedIndex + 5 * castedOffset);
            Found4:
            return (int)(castedIndex + 4 * castedOffset);
            Found3:
            return (int)(castedIndex + 3 * castedOffset);
            Found2:
            return (int)(castedIndex + 2 * castedOffset);
            Found1:
            return (int)(castedIndex + 1 * castedOffset);
            Found:
            return (int)castedIndex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static int ComputeFirstIndex<TValue>(ref TValue searchSpace, ref TValue current, Vector128<TValue> equals) where TValue : struct
        {
            uint notEqualsElements = equals.ExtractMostSignificantBits();
            int index = BitOperations.TrailingZeroCount(notEqualsElements);
            return index + (int)((nuint)Unsafe.ByteOffset(ref searchSpace, ref current) / (nuint)sizeof(TValue));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static int ComputeFirstIndex<TValue>(ref TValue searchSpace, ref TValue current, Vector256<TValue> equals) where TValue : struct
        {
            uint notEqualsElements = equals.ExtractMostSignificantBits();
            int index = BitOperations.TrailingZeroCount(notEqualsElements);
            return index + (int)((nuint)Unsafe.ByteOffset(ref searchSpace, ref current) / (nuint)sizeof(TValue));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe static int ComputeFirstIndex<TValue>(ref TValue searchSpace, ref TValue current, Vector512<TValue> equals) where TValue : struct
        {
            ulong notEqualsElements = equals.ExtractMostSignificantBits();
            int index = BitOperations.TrailingZeroCount(notEqualsElements);
            return index + (int)((nuint)Unsafe.ByteOffset(ref searchSpace, ref current) / (nuint)sizeof(TValue));
        }
    }
}
