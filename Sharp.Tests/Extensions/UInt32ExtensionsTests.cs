using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public class UInt32ExtensionsTests
    {
        private Random _random;

        public UInt32ExtensionsTests()
            => _random = new Random();

        [Fact]
        public void Reverse_WhenUsedWithUInt32_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            uint actual = 0x12345678;
            uint expected = 0x78563412;

            // Act
            actual = actual.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithUInt32_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            uint value = 0x12345678;
            byte[] expected;

            if (BitConverter.IsLittleEndian)
                expected = [0x78, 0x56, 0x34, 0x12];
            else
                expected = [0x12, 0x34, 0x56, 0x78];

            // Act
            byte[] actual = value.ToBytes();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithUInt32_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            uint value = 0x12345678;
            byte[] expected = [0x78, 0x56, 0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithUInt32_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            uint value = 0x12345678;
            byte[] expected = [0x12, 0x34, 0x56, 0x78];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}