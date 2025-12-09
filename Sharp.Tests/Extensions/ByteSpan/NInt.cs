using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public unsafe void Insert_WhenUsedWithNInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                value = Unsafe.As<ulong, nint>(ref input);

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
        public unsafe void DangerousInsert_WhenUsedWithNInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                value = Unsafe.As<ulong, nint>(ref input);

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
        public unsafe void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithNInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public unsafe void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithNInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public unsafe void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithNInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public unsafe void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithNInt_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public unsafe void Insert_WhenUsedWithNIntExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
                nint value;

                if (sizeof(nint) == sizeof(uint))
                    value = 0x12345678;
                else
                {
                    ulong input = 0x123456789ABCDEFE;
                    value = Unsafe.As<ulong, nint>(ref input);
                }

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public unsafe void TryInsert_WhenUsedWithNInt_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                value = Unsafe.As<ulong, nint>(ref input);

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
        public unsafe void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithNInt_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public unsafe void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithNInt_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public unsafe void TryInsert_WhenUsedWithNIntExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(nint)];
            nint value;

            if (sizeof(nint) == sizeof(uint))
                value = 0x12345678;
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
            }

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public unsafe void ToNInt_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                expected = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = sourceBytes.ToNInt(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToNInt_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                expected = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = sourceBytes.DangerousToNInt(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToNIntInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = sourceBytes.ToNInt(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToNIntInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = sourceBytes.DangerousToNInt(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToNIntInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = sourceBytes.ToNInt(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToNIntInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = sourceBytes.DangerousToNInt(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToNInt_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];

                // Act and Assert
                sourceBytes.ToNInt(index);
            });
        }

        [Fact]
        public unsafe void TryToNInt_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                expected = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToNInt(index, out nint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToNIntInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToNInt(index, bigEndian: false, out nint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToNIntInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];
            nint expected;
            ReadOnlySpan<byte> valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToNInt(index, bigEndian: true, out nint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToNInt_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            nint expected = default;
            int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(nint)];

            // Act
            bool success = sourceBytes.TryToNInt(index, out nint actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}