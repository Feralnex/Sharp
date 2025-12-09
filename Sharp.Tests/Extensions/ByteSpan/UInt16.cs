using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithUInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
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
        public void DangerousInsert_WhenUsedWithUInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
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
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithUInt16ExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                ushort value = 0x1234;
                int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
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
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
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
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(ushort)];
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
        public void TryInsert_WhenUsedWithUInt16ExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(ushort)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToUInt16_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.ToUInt16(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.DangerousToUInt16(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.ToUInt16(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.DangerousToUInt16(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.ToUInt16(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.DangerousToUInt16(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];

                // Act and Assert
                sourceBytes.ToUInt16(index);
            });
        }

        [Fact]
        public void TryToUInt16_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt16(index, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16InvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt16(index, bigEndian: false, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16InvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt16(index, bigEndian: true, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            ushort expected = default;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];

            // Act
            bool success = sourceBytes.TryToUInt16(index, out ushort actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}