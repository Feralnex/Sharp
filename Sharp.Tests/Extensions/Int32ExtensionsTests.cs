using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public class Int32ExtensionsTests
    {
        [Fact]
        public void Reverse_WhenUsedWithInt32_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            int actual = 0x12345678;
            int expected = 0x78563412;

            // Act
            actual = actual.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithInt32_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            int value = 0x12345678;
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
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithInt32_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            int value = 0x12345678;
            byte[] expected = [0x78, 0x56, 0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithInt32_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            int value = 0x12345678;
            byte[] expected = [0x12, 0x34, 0x56, 0x78];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 4)]
        [InlineData(4, 4)]
        [InlineData(5, 8)]
        [InlineData(8, 8)]
        [InlineData(9, 16)]
        [InlineData(16, 16)]
        [InlineData(17, 32)]
        public void GetBucketValue_WhenGivenInput_ShouldReturnSameOrNextPowerOfTwo(int input, int expected)
        {
            // Arrange
            // (input and expected are provided via InlineData)

            // Act
            int result = input.GetBucketValue();

            // Assert
            Assert.Equal(expected, result);
        }
    }
}