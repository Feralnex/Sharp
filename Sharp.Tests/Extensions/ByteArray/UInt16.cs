using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class ByteArrayExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithUInt16_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes;

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
        public void DangerousInsert_WhenUsedWithUInt16_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes;

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
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithUInt16ExceedingByteArraySpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes;

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
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt16ExceedingByteArraySpace_ShouldReturnFalse()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(ushort)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToUInt16_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes;

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
        public void DangerousToUInt16_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes;

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
        public void ToUInt16InvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.ToUInt16(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16InvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.DangerousToUInt16(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16InvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.ToUInt16(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16InvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = sourceBytes.DangerousToUInt16(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16_WhenUsedWithByteArrayExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => sourceBytes.ToUInt16(index));
        }

        [Fact]
        public void TryToUInt16_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes;

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
        public void TryToUInt16InvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt16(index, bigEndian: false, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16InvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt16(index, bigEndian: true, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16_WhenUsedWithByteArrayExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            ushort expected = default;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ushort)];

            // Act
            bool success = sourceBytes.TryToUInt16(index, out ushort actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}