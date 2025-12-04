using System;
using Xunit;

namespace Sharp.Tests
{
    public class ConcurrentLazyTests
    {
        private Random _random;

        public ConcurrentLazyTests()
            => _random = new Random();

        [Fact]
        public void NewConcurrentLazyAcceptingValue_WhenProvidedValue_ShouldCreateConcurrentLazyWithThatValue()
        {
            // Arrange
            int expected = _random.Next();
            ConcurrentLazy<int> concurrentLazy = new ConcurrentLazy<int>(expected);

            // Act
            int actual = concurrentLazy.Value;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NewConcurrentLazyAcceptingFactory_WhenProvidedFactory_ShouldCreateConcurrentLazyWithThatFactory()
        {
            // Arrange
            int expected = _random.Next();
            Func<int> factory = () => expected;
            ConcurrentLazy<int> concurrentLazy = new ConcurrentLazy<int>(factory);

            // Act
            int value1 = concurrentLazy.Value;

            // Assert
            Assert.Equal(expected, value1);
        }

        [Fact]
        public void Value_WhenCalledOnConcurrentLazyWithFactory_ShouldInvokeFactoryOnceWhenAccessingValue()
        {
            // Arrange
            int expected = _random.Next();
            int callCount = default;
            Func<int> factory = () =>
            {
                callCount++;
                return expected;
            };
            ConcurrentLazy<int> concurrentLazy = new ConcurrentLazy<int>(factory);

            // Act
            int value1 = concurrentLazy.Value;
            int value2 = concurrentLazy.Value;

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
            ConcurrentLazy<string> concurrentLazy = new ConcurrentLazy<string>(() => expected);

            // Act
            string value1 = concurrentLazy.Value;
            string value2 = concurrentLazy.Value;

            // Assert
            Assert.Equal(expected, value1);
            Assert.Equal(value1, value2);
        }

        [Fact]
        public void Value_WhenInitializedWithReferenceType_ShouldReturnTheSameInstance()
        {
            // Arrange
            object expected = new object();
            ConcurrentLazy<object> concurrentLazy = new ConcurrentLazy<object>(() => expected);

            // Act
            object value1 = concurrentLazy.Value;
            object value2 = concurrentLazy.Value;

            // Assert
            Assert.Same(expected, value1);
            Assert.Same(value1, value2);
        }
    }
}
