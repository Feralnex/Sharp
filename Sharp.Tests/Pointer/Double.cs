using Sharp.Helpers;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithDouble_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(double));
            int length = sizeof(decimal) + sizeof(double);
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
            Pointer.Insert(actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithDouble_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(double));
            int length = sizeof(decimal) + sizeof(double);
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
            Pointer.DangerousInsert(actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(double));
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(actual, length, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(double));
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(actual, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(double));
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(actual, length, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(double));
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(actual, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void Insert_WhenUsedWithDoubleExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(actual, length, index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithDouble_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(double);
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
            bool success = Pointer.TryInsert(actual, length, index: offset, value);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

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
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

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
        public void TryInsert_WhenUsedWithDoubleExceedingByteArraySpace_ShouldReturnFalse()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(double);
            byte* actual = stackalloc byte[length];

            // Act
            bool success = Pointer.TryInsert(actual, length, index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToDouble_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = Pointer.ToDouble(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDouble_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = Pointer.DangerousToDouble(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDoubleInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = Pointer.ToDouble(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDoubleInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = Pointer.DangerousToDouble(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDoubleInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = Pointer.ToDouble(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDoubleInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = Pointer.DangerousToDouble(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDouble_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(double);
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToDouble(sourceBytes, length, index));
        }

        [Fact]
        public void TryToDouble_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToDouble(sourceBytes, length, index, out double actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDoubleInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToDouble(sourceBytes, length, index, bigEndian: false, out double actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDoubleInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(double));
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToDouble(sourceBytes, length, index, bigEndian: true, out double actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDouble_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            double expected = default;
            int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(double);
            int length = sizeof(double) + sizeof(double);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToDouble(sourceBytes, length, index, out double actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}