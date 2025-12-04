using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public class Int16ExtensionsTests
    {
        [Fact]
        public void Reverse_WhenUsedWithInt16_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            short actual = 0x1234;
            short expected = 0x3412;

            // Act
            actual = actual.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithInt16_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            short value = 0x1234;
            byte[] expected;

            if (BitConverter.IsLittleEndian)
                expected = [0x34, 0x12];
            else
                expected = [0x12, 0x34];

            // Act
            byte[] actual = value.ToBytes();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithInt16_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            short value = 0x1234;
            byte[] expected = [0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithInt16_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            short value = 0x1234;
            byte[] expected = [0x12, 0x34];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}