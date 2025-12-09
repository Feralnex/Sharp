using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithUInt32_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithUInt32_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt32_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt32_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt32_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt32_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithUInt32ExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                uint value = 0x12345678;
                int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt32_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt32_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt32_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt32ExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(uint)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToUInt32_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = sourceBytes.ToUInt32(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt32_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = sourceBytes.DangerousToUInt32(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt32InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = sourceBytes.ToUInt32(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt32InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = sourceBytes.DangerousToUInt32(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt32InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = sourceBytes.ToUInt32(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt32InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = sourceBytes.ToUInt32(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt32_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];

                // Act and Assert
                sourceBytes.ToUInt32(index);
            });
        }

        [Fact]
        public void TryToUInt32_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt32(index, out uint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt32InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt32(index, bigEndian: false, out uint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt32InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt32(index, bigEndian: true, out uint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt32_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            uint expected = default;
            int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(uint)];

            // Act
            bool success = sourceBytes.TryToUInt32(index, out uint actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}