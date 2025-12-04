using Sharp.Helpers;
using System;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithUInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithUInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public unsafe void Insert_WhenUsedWithUInt16ExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(destination: actual, length, index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(destination: actual, length, offset, value);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(destination: actual, length, offset, value, bigEndian: false);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ushort value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(destination: actual, length, offset, value, bigEndian: true);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsert_WhenUsedWithUInt16ExceedingBytePointerSpace_ShouldReturnFalse()
        {
            // Arrange
            ushort value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(ushort);
            byte* actual = stackalloc byte[length];

            // Act
            bool success = Pointer.TryInsert(destination: actual, length, index, value);

            // Assert
            Assert.False(success);
        }
    }
}