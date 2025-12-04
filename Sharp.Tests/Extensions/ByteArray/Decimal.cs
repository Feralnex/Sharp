using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class ByteArrayExtensionsTests
    {
        [Fact]
        public unsafe void Insert_WhenUsedWithDecimal_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousInsert_WhenUsedWithDecimal_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithDecimalExceedingByteArraySpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            decimal value = 0;
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }

        [Fact]
        public unsafe void TryInsert_WhenUsedWithDecimal_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithDecimalExceedingByteArraySpace_ShouldReturnFalse()
        {
            // Arrange
            decimal value = 0;
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(decimal)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public unsafe void ToDecimal_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = sourceBytes.ToDecimal(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToDecimal_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = sourceBytes.DangerousToDecimal(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToDecimalInvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = sourceBytes.ToDecimal(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToDecimalInvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = sourceBytes.DangerousToDecimal(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToDecimalInvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = sourceBytes.ToDecimal(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void DangerousToDecimalInvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            decimal actual = sourceBytes.DangerousToDecimal(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDecimal_WhenUsedWithByteArrayExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => sourceBytes.ToDecimal(index));
        }

        [Fact]
        public unsafe void TryToDecimal_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToDecimal(index, out decimal actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToDecimalInvokedWithBigEndianSetToFalse_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToDecimal(index, bigEndian: false, out decimal actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void TryToDecimalInvokedWithBigEndianSetToTrue_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            decimal expected = 0;
            ulong* pointer = (ulong*)&expected;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];
            byte[] valueInBytes = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToDecimal(index, bigEndian: true, out decimal actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDecimal_WhenUsedWithByteArrayExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            decimal expected = default;
            int index = _random.Next(sizeof(byte), sizeof(decimal)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(decimal)];

            // Act
            bool success = sourceBytes.TryToDecimal(index, out decimal actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}