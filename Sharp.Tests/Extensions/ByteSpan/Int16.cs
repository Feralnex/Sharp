using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithInt16ExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                short value = 0x1234;
                int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public void TryInsert_WhenUsedWithInt16_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithInt16ExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(short)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToInt16_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = sourceBytes.ToInt16(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt16_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = sourceBytes.DangerousToInt16(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt16InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = sourceBytes.ToInt16(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt16InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = sourceBytes.DangerousToInt16(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt16InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = sourceBytes.ToInt16(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt16InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = sourceBytes.DangerousToInt16(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt16_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];

                // Act and Assert
                sourceBytes.ToInt16(index);
            });
        }

        [Fact]
        public void TryToInt16_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToInt16(index, out short actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt16InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToInt16(index, bigEndian: false, out short actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt16InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToInt16(index, bigEndian: true, out short actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt16_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            short expected = default;
            int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(short)];

            // Act
            bool success = sourceBytes.TryToInt16(index, out short actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}