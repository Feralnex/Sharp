using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public class SingleExtensionsTests
    {
        private Random _random;

        public SingleExtensionsTests()
            => _random = new Random();

        [Fact]
        public void Reverse_WhenUsedWithSingle_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            uint input = 0x12345678;
            float value = Unsafe.As<uint, float>(ref input);
            uint expected = 0x78563412;

            // Act
            value = value.Reverse();
            uint actual = Unsafe.As<float, uint>(ref value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithSingle_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            uint input = 0x12345678;
            float value = Unsafe.As<uint, float>(ref input);
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
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithSingle_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            uint input = 0x12345678;
            float value = Unsafe.As<uint, float>(ref input);
            byte[] expected = [0x78, 0x56, 0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithSingle_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            uint input = 0x12345678;
            float value = Unsafe.As<uint, float>(ref input);
            byte[] expected = [0x12, 0x34, 0x56, 0x78];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}