using Sharp.Helpers;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        [Fact]
        public void Insert_WhenUsedWithNInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nint value;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                value = Unsafe.As<ulong, nint>(ref input);

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
        public void DangerousInsert_WhenUsedWithNInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nint value;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                value = Unsafe.As<ulong, nint>(ref input);

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
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithNInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nint value;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithNInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nint value;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithNInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nint value;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithNInt_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];
            nint value;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
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
        public void Insert_WhenUsedWithNIntExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(nint);
            byte* actual = stackalloc byte[length];
            nint value;

            if (sizeof(nint) == sizeof(uint))
                value = 0x12345678;
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
            }

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(destination: actual, length, index, value));
        }

        [Fact]
        public void ToNInt_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                expected = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = Pointer.ToNInt(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToNInt_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                expected = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = Pointer.DangerousToNInt(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToNIntInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = Pointer.ToNInt(sourceBytes, length, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToNIntInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = Pointer.DangerousToNInt(sourceBytes, index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToNIntInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = Pointer.ToNInt(sourceBytes, length, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToNIntInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            nint actual = Pointer.DangerousToNInt(sourceBytes, index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToNInt_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToNInt(sourceBytes, length, index));
        }

        [Fact]
        public void TryToNInt_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
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
                expected = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToNInt(sourceBytes, length, index, out nint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToNIntInvokedWithBigEndianSetToFalse_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToNInt(sourceBytes, length, index, bigEndian: false, out nint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToNIntInvokedWithBigEndianSetToTrue_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];
            nint expected;
            byte[] valueInBytes;

            if (sizeof(nint) == sizeof(uint))
            {
                expected = 0x12345678;
                valueInBytes = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                expected = Unsafe.As<ulong, nint>(ref input);
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToNInt(sourceBytes, length, index, bigEndian: true, out nint actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToNInt_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            nint expected = default;
            int index = _random.Next(sizeof(byte), sizeof(nint)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(nint);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToNInt(sourceBytes, length, index, out nint actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}