using System;
using Xunit;

namespace Sharp.Tests
{
    public class LazyTests
    {
        private Random _random;

        public LazyTests()
            => _random = new Random();

        [Fact]
        public void NewLazyAcceptingValue_WhenProvidedValue_ShouldCreateLazyWithThatValue()
        {
            // Arrange
            int expected = _random.Next();
            Lazy<int> lazy = new Lazy<int>(expected);

            // Act
            int actual = lazy.Value;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NewLazyAcceptingFactory_WhenProvidedFactory_ShouldCreateLazyWithThatFactory()
        {
            // Arrange
            int expected = _random.Next();
            Func<int> factory = () => expected;
            Lazy<int> lazy = new Lazy<int>(factory);

            // Act
            int value1 = lazy.Value;

            // Assert
            Assert.Equal(expected, value1);
        }

        [Fact]
        public void Value_WhenCalledOnLazyWithFactory_ShouldInvokeFactoryOnceWhenAccessingValue()
        {
            // Arrange
            int expected = _random.Next();
            int callCount = default;
            Func<int> factory = () =>
            {
                callCount++;
                return expected;
            };
            Lazy<int> lazy = new Lazy<int>(factory);

            // Act
            int value1 = lazy.Value;
            int value2 = lazy.Value;

            // Assert
            Assert.Equal(expected, value1);
            Assert.Equal(expected, value2);
            Assert.Equal(1, callCount);
        }

        [Fact]
        public void Value_WhenCalledMultipleTimes_ShouldReturnTheSameValue()
        {
            // Arrange
            string expected = nameof(expected);
            Lazy<string> lazy = new Lazy<string>(() => expected);

            // Act
            string value1 = lazy.Value;
            string value2 = lazy.Value;

            // Assert
            Assert.Equal(expected, value1);
            Assert.Equal(value1, value2);
        }

        [Fact]
        public void Value_WhenInitializedWithReferenceType_ShouldReturnTheSameInstance()
        {
            // Arrange
            object expected = new object();
            Lazy<object> lazy = new Lazy<object>(() => expected);

            // Act
            object value1 = lazy.Value;
            object value2 = lazy.Value;

            // Assert
            Assert.Same(expected, value1);
            Assert.Same(value1, value2);
        }
    }
}
