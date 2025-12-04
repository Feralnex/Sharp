using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public class UInt16Extensions
    {
        private Random _random;

        public UInt16Extensions()
            => _random = new Random();

        [Fact]
        public void Reverse_WhenUsedWithUInt16_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            ushort actual = 0x1234;
            ushort expected = 0x3412;

            // Act
            actual = actual.Reverse();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithUInt16_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ushort value = 0x1234;
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
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithUInt16_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ushort value = 0x1234;
            byte[] expected = [0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithUInt16_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ushort value = 0x1234;
            byte[] expected = [0x12, 0x34];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}