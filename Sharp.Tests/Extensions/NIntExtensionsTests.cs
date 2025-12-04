using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public class NIntExtensionsTests
    {
        private Random _random;

        public NIntExtensionsTests()
            => _random = new Random();

        [Fact]
        public unsafe void Reverse_WhenUsedWithNInt_ShouldReturnValueWithReversedBytes()
        {
            if (sizeof(nuint) == sizeof(uint))
            {
                // Arrange
                nint actual = 0x12345678;
                nint expected = 0x78563412;

                // Act
                actual = actual.Reverse();

                // Assert
                Assert.Equal(expected, actual);
            }
            else
            {
                // Arrange
                ulong input = 0x123456789ABCDEFE;
                nint value = Unsafe.As<ulong, nint>(ref input);
                ulong expected = 0xFEDEBC9A78563412;

                // Act
                value = value.Reverse();
                ulong actual = Unsafe.As<nint, ulong>(ref value);

                // Assert
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public unsafe void ToBytes_WhenUsedWithNInt_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            nint value;
            byte[] expected;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;

                if (BitConverter.IsLittleEndian)
                    expected = [0x78, 0x56, 0x34, 0x12];
                else
                    expected = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);

                if (BitConverter.IsLittleEndian)
                    expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
                else
                    expected = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            // Act
            byte[] actual = value.ToBytes();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithNInt_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            nint value;
            byte[] expected;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                expected = [0x78, 0x56, 0x34, 0x12];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
                expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            }

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithNInt_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            nint value;
            byte[] expected;

            if (sizeof(nint) == sizeof(uint))
            {
                value = 0x12345678;
                expected = [0x12, 0x34, 0x56, 0x78];
            }
            else
            {
                ulong input = 0x123456789ABCDEFE;
                value = Unsafe.As<ulong, nint>(ref input);
                expected = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];
            }

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}