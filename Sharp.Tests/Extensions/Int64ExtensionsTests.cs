using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public class Int64ExtensionsTests
    {
        [Fact]
        public void Reverse_WhenUsedWithInt64_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            ulong output = 0xFEDEBC9A78563412;
            long actual = 0x123456789ABCDEFE;
            long expected = Unsafe.As<ulong, long>(ref output);

            // Act
            actual = actual.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithInt64_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            byte[] expected;

            if (BitConverter.IsLittleEndian)
                expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                expected = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            // Act
            byte[] actual = value.ToBytes();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithInt64_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            byte[] expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithInt64_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            long value = 0x123456789ABCDEFE;
            byte[] expected = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}