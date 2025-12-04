using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public class DoubleExtensionsTests
    {
        [Fact]
        public void Reverse_WhenUsedWithDouble_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            ulong expected = 0xFEDEBC9A78563412;

            // Act
            value = value.Reverse();
            ulong actual = Unsafe.As<double, ulong>(ref value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytes_WhenUsedWithDouble_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
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
        public void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            byte[] expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            byte[] expected = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}