using Sharp.Extensions;
using Xunit;

namespace Sharp.Tests
{
    public class BoolExtensionsTests
    {
        [Fact]
        public void ToBytes_WhenUseOnBool_ShouldReturnValueConvertedToByteArray()
        {
            // Arrange
            bool value = true;
            byte[] expected = [0x01];

            // Act
            byte[] actual = value.ToBytes();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}