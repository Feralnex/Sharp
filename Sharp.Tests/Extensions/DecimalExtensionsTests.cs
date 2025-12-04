using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public class DecimalExtensionsTests
    {
        [Fact]
        public unsafe void Reverse_WhenUsedWithDecimal_ShouldReturnValueWithReversedBytes()
        {
            // Arrange
            decimal actual = 0;
            ulong[] expected = [0x341232547698BADC, 0xFEDEBC9A78563412];
            ulong* pointer = (ulong*)&actual;

            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;

            // Act
            actual = actual.Reverse();
            pointer = (ulong*)&actual;

            // Assert
            Assert.Equal(expected[0], pointer[0]);
            Assert.Equal(expected[1], pointer[1]);
        }

        [Fact]
        public unsafe void ToBytes_WhenUsedWithDecimal_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            byte[] expected;

            if (BitConverter.IsLittleEndian)
                expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];
            else
                expected = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            // Act
            byte[] actual = value.ToBytes();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToBytesInvokedWithBigEndianSetToFalse_WhenUsedWithDecimal_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            byte[] expected = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12, 0x34, 0x12, 0x32, 0x54, 0x76, 0x98, 0xBA, 0xDC];

            // Act
            byte[] actual = value.ToBytes(bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public unsafe void ToBytesInvokedWithBigEndianSetToTrue_WhenUsedWithDecimal_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            decimal value = 0;
            ulong* pointer = (ulong*)&value;
            pointer[0] = 0x123456789ABCDEFE;
            pointer[1] = 0xDCBA987654321234;
            byte[] expected = [0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x12, 0x34, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            // Act
            byte[] actual = value.ToBytes(bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SetFlags_WhenProvidedFlags_ShouldUpdateFlagsAndReturnTheSameFlagsThroughGetFlags()
        {
            // Arrange
            decimal value = default;
            int expectedFlags = unchecked((int)0xCAFEBABE);

            // Act
            value.SetFlags(expectedFlags);
            int actualFlags = value.GetFlags();

            // Assert
            Assert.Equal(expectedFlags, actualFlags);
        }

        [Fact]
        public void SetHi32_WhenProvidedHi32_ShouldUpdateHi32AndReturnTheSameHi32ThroughGetHi32()
        {
            // Arrange
            decimal value = default;
            uint expectedHi32 = 0xDEADBEEF;

            // Act
            value.SetHi32(expectedHi32);
            uint actualHi32 = value.GetHi32();

            // Assert
            Assert.Equal(expectedHi32, actualHi32);
        }

        [Fact]
        public void SetLo64_WhenProvidedLo64_ShouldUpdateLo64AndReturnTheSameLo64ThroughGetLo64()
        {
            // Arrange
            decimal value = default;
            ulong expectedLo64 = 0x0123456789ABCDEF;

            // Act
            value.SetLo64(expectedLo64);
            ulong actualLo64 = value.GetLo64();

            // Assert
            Assert.Equal(expectedLo64, actualLo64);
        }
    }
}