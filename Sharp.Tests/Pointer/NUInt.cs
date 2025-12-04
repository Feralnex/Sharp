using Sharp.Helpers;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithNUInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nuint value;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithNUInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nuint value;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithNUInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nuint value;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithNUInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nuint value;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: false);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithNUInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nuint value;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(destination: actual, length, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithNUInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nuint value;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(destination: actual, index: offset, value, bigEndian: true);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void Insert_WhenUsedWithNUIntExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(nuint);
            byte* actual = stackalloc byte[length];
            nuint value;

            if (sizeof(nuint) == sizeof(uint))
                value = 0x12345678;
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nuint>(ref input);
            }

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(destination: actual, length, index, value));
        }

        [Fact]
        public void ToNUInt_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = Pointer.ToNUInt(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToNUInt_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = Pointer.DangerousToNUInt(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToNUIntInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = Pointer.ToNUInt(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToNUIntInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = Pointer.DangerousToNUInt(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToNUIntInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = Pointer.ToNUInt(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToNUIntInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nuint actual = Pointer.DangerousToNUInt(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToNUInt_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToNUInt(sourceBytes, length, index));
        }

        [Fact]
        public void TryToNUInt_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToNUInt(sourceBytes, length, index, out nuint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToNUIntInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToNUInt(sourceBytes, length, index, bigEndian: false, out nuint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToNUIntInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];
            nuint expected;
            byte[] valueInBytes;

            if (sizeof(nuint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nuint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToNUInt(sourceBytes, length, index, bigEndian: true, out nuint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToNUInt_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            nuint expected = default;
            int index = _random.Next(sizeof(byte), sizeof(nuint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(nuint);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToNUInt(sourceBytes, length, index, out nuint actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}