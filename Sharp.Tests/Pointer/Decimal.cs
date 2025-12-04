using Sharp.Helpers;
using System;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithDecimal_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithDecimal_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(actual, length, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(actual, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(actual, length, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(actual, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void Insert_WhenUsedWithDecimalExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            decimal value = 0;
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[sizeof(decimal) + sizeof(decimal)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(actual, length, index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithDecimal_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(actual, length, index: offset, value);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(actual, length, index: offset, value, bigEndian: false);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(actual, length, index: offset, value, bigEndian: true);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsert_WhenUsedWithDecimalExceedingBytePointerSpace_ShouldReturnFalse()
        {
            // Arrange
            decimal value = 0;
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(decimal);
            byte* actual = stackalloc byte[length];

            // Act
            bool success = Pointer.TryInsert(actual, length, index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToDecimal_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = Pointer.ToDecimal(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDecimal_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = Pointer.DangerousToDecimal(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimalInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = Pointer.ToDecimal(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDecimalInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = Pointer.DangerousToDecimal(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimalInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = Pointer.ToDecimal(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDecimalInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = Pointer.DangerousToDecimal(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToDecimal(sourceBytes, length, index));
        }

        [Fact]
        public void TryToDecimal_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToDecimal(sourceBytes, length, index, out decimal actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDecimalInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToDecimal(sourceBytes, length, index, bigEndian: false, out decimal actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDecimalInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToDecimal(sourceBytes, length, index, bigEndian: true, out decimal actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDecimal_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            decimal expected = default;
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(decimal);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToDecimal(sourceBytes, length, index, out decimal actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}