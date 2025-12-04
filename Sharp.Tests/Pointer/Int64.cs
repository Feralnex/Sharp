using Sharp.Helpers;
using System;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithInt64_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithInt64_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt64_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt64_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt64_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt64_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void Insert_WhenUsedWithInt64ExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(long);
            byte* actual = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(destination: actual, length, index, value));
        }

        [Fact]
        public void ToInt64_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = Pointer.ToInt64(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt64_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = Pointer.DangerousToInt64(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt64InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = Pointer.ToInt64(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt64InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = Pointer.DangerousToInt64(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt64InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = Pointer.ToInt64(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt64InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            long actual = Pointer.DangerousToInt64(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt64_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToInt64(sourceBytes, length, index));
        }

        [Fact]
        public void TryToInt64_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToInt64(sourceBytes, length, index, out long actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt64InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToInt64(sourceBytes, length, index, bigEndian: false, out long actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt64InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            long expected = 0x123456789ABCDEFE;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToInt64(sourceBytes, length, index, bigEndian: true, out long actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt64_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            long expected = default;
            int index = _random.Next(sizeof(byte), sizeof(long)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(long);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToInt64(sourceBytes, length, index, out long actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}