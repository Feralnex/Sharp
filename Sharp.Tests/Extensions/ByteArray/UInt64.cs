using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class ByteArrayExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithUInt64_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes;

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
        public void DangerousInsert_WhenUsedWithUInt64_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes;

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
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt64_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt64_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt64_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt64_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithUInt64ExceedingByteArraySpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(byte), sizeof(ulong)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt64_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes;

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
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt64_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt64_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt64ExceedingByteArraySpace_ShouldReturnFalse()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(byte), sizeof(ulong)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(ulong)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToUInt64_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ulong actual = sourceBytes.ToUInt64(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt64_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ulong actual = sourceBytes.DangerousToUInt64(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt64InvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ulong actual = sourceBytes.ToUInt64(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt64InvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ulong actual = sourceBytes.DangerousToUInt64(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt64InvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ulong actual = sourceBytes.ToUInt64(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt64InvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ulong actual = sourceBytes.DangerousToUInt64(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt64_WhenUsedWithByteArrayExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(ulong)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => sourceBytes.ToUInt64(index));
        }

        [Fact]
        public void TryToUInt64_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt64(index, out ulong actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt64InvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt64(index, bigEndian: false, out ulong actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt64InvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToUInt64(index, bigEndian: true, out ulong actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt64_WhenUsedWithByteArrayExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            ulong expected = default;
            int index = _random.Next(sizeof(byte), sizeof(ulong)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(ulong)];

            // Act
            bool success = sourceBytes.TryToUInt64(index, out ulong actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}