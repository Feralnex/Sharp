using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithInt64_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithInt64_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt64_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt64_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt64_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt64_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithInt64ExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                long value = 0x123456789ABCDEFE;
                int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public void TryInsert_WhenUsedWithInt64_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt64_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt64_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithInt64ExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(long)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToInt64_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = sourceBytes.ToInt64(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt64_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = sourceBytes.DangerousToInt64(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt64InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = sourceBytes.ToInt64(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt64InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = sourceBytes.DangerousToInt64(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt64InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = sourceBytes.ToInt64(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt64InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = sourceBytes.DangerousToInt64(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt64_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];

                // Act and Assert
                sourceBytes.ToInt64(index);
            });
        }

        [Fact]
        public void TryToInt64_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToInt64(index, out long actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt64InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToInt64(index, bigEndian: false, out long actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt64InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToInt64(index, bigEndian: true, out long actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt64_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            long expected = default;
            int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(long)];

            // Act
            bool success = sourceBytes.TryToInt64(index, out long actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}