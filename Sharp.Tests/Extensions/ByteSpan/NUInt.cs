using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public unsafe void Insert_WhenUsedWithNUInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousInsert_WhenUsedWithNUInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithNUInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithNUInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithNUInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithNUInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void Insert_WhenUsedWithNUIntExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
                nuint value;

                if (sizeof(nuint) == sizeof(uint))
                    value = 0x12345678;
                else
                {
                    ulong input = 0x123456789ABCDEFE;
                    value = Unsafe.As<ulong, nuint>(ref input);
                }

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public unsafe void TryInsert_WhenUsedWithNUInt_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithNUInt_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithNUInt_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryInsert_WhenUsedWithNUIntExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint value;

            if (sizeof(nuint) == sizeof(uint))
                value = 0x12345678;
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
            }

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public unsafe void ToNUInt_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = sourceBytes.ToNUInt(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToNUInt_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = sourceBytes.DangerousToNUInt(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToNUIntInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = sourceBytes.ToNUInt(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToNUIntInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = sourceBytes.DangerousToNUInt(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToNUIntInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = sourceBytes.ToNUInt(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToNUIntInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = sourceBytes.DangerousToNUInt(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToNUInt_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];

                // Act and Assert
                sourceBytes.ToNUInt(index);
            });
        }

        [Fact]
        public unsafe void TryToNUInt_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToNUInt(index, out nuint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToNUIntInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToNUInt(index, bigEndian: false, out nuint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToNUIntInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];
            nuint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToNUInt(index, bigEndian: true, out nuint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToNUInt_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            nuint expected = default;
            int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nuint)];

            // Act
            bool success = sourceBytes.TryToNUInt(index, out nuint actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}