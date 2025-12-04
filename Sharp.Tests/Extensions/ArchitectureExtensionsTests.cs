using Sharp.Extensions;
using System.Runtime.InteropServices;
using Xunit;

namespace Sharp.Tests
{
    public class ArchitectureExtensionsTests
    {
        [Theory]
        [InlineData(Architecture.X64)]
        [InlineData(Architecture.Arm64)]
        [InlineData(Architecture.S390x)]
        [InlineData(Architecture.LoongArch64)]
        [InlineData(Architecture.Ppc64le)]
        public void Is64Bit_WhenArchitectureIs64Bit_ShouldReturnTrue(Architecture arch)
        {
            // Arrange & Act
            bool result = arch.Is64Bit();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(Architecture.X86)]
        [InlineData(Architecture.Arm)]
        [InlineData(Architecture.Wasm)]
        [InlineData(Architecture.Armv6)] // Only if defined and distinct from X64
        public void Is64Bit_WhenArchitectureIsNot64Bit_ShouldReturnFalse(Architecture arch)
        {
            // Arrange & Act
            bool result = arch.Is64Bit();

            // Assert
            Assert.False(result);
        }
    }
}
