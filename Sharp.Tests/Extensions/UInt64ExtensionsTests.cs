using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public class UInt64ExtensionsTests
    {
        private Random _random;

        public UInt64ExtensionsTests()
            => _random = new Random();

        [Fact]
        public void Reverse_WhenUsedWithUInt64_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            ulong actual = 0x123456789ABCDEFE;
            ulong expected = 0xFEDEBC9A78563412;

            // Act
            actual = actual.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithUInt64_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
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
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithUInt64_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            byte[] expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithUInt64_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ulong value = 0x123456789ABCDEFE;
            byte[] expected = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}