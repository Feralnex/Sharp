using Sharp.Helpers;
using System;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void DangerousInsert_WhenUsedWithInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public unsafe void Insert_WhenUsedWithInt16ExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(short);
            byte* actual = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(destination: actual, length, index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithInt16_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            short value = 0x1234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
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
        public void TryInsert_WhenUsedWithInt16ExceedingBytePointerSpace_ShouldReturnFalse()
        {
            // Arrange
            short value = 0x1234;
            int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(short);
            byte* actual = stackalloc byte[length];

            // Act
            bool success = Pointer.TryInsert(destination: actual, length, index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToInt16_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = Pointer.ToInt16(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt16_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = Pointer.DangerousToInt16(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt16InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = Pointer.ToInt16(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt16InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = Pointer.DangerousToInt16(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt16InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = Pointer.ToInt16(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToInt16InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            short actual = Pointer.DangerousToInt16(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToInt16_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToInt16(sourceBytes, length, index));
        }

        [Fact]
        public void TryToInt16_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToInt16(sourceBytes, length, index, out short actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt16InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToInt16(sourceBytes, length, index, bigEndian: false, out short actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt16InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            short expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToInt16(sourceBytes, length, index, bigEndian: true, out short actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToInt16_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            short expected = default;
            int index = _random.Next(sizeof(byte), sizeof(short)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(short);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToInt16(sourceBytes, length, index, out short actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = Pointer.ToUInt16(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = Pointer.DangerousToUInt16(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = Pointer.ToUInt16(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = Pointer.DangerousToUInt16(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = Pointer.ToUInt16(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToUInt16InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            ushort actual = Pointer.DangerousToUInt16(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToUInt16_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToUInt16(sourceBytes, length, index));
        }

        [Fact]
        public void TryToUInt16_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToUInt16(sourceBytes, length, index, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16InvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToUInt16(sourceBytes, length, index, bigEndian: false, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16InvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ushort expected = 0x1234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToUInt16(sourceBytes, length, index, bigEndian: true, out ushort actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToUInt16_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            ushort expected = default;
            int index = _random.Next(sizeof(byte), sizeof(ushort)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(ushort);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToUInt16(sourceBytes, length, index, out ushort actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}