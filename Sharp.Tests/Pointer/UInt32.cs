using Sharp.Helpers;
using System;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithUInt32_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithUInt32_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }
        
        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt32_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt32_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt32_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt32_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            uint value = 0x12345678;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void Insert_WhenUsedWithUInt32ExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            uint value = 0x12345678;
            int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(uint);
            byte* actual = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(destination: actual, length, index, value));
        }

        [Fact]
        public void ToUInt32_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = Pointer.ToUInt32(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt32_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = Pointer.DangerousToUInt32(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt32InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = Pointer.ToUInt32(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt32InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = Pointer.DangerousToUInt32(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt32InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = Pointer.ToUInt32(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt32InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            uint actual = Pointer.ToUInt32(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt32_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToUInt32(sourceBytes, length, index));
        }

        [Fact]
        public void TryToUInt32_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToUInt32(sourceBytes, length, index, out uint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt32InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToUInt32(sourceBytes, length, index, bigEndian: false, out uint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt32InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            uint expected = 0x12345678;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToUInt32(sourceBytes, length, index, bigEndian: true, out uint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt32_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            uint expected = default;
            int index = _random.Next(sizeof(byte), sizeof(uint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(uint);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToUInt32(sourceBytes, length, index, out uint actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}