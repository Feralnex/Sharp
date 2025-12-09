using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        private readonly Random _random;

        public SpanOfBytesExtensionsTests()
            => _random = new Random();

        [Fact]
        public void Insert_WhenUsedWithBool_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            ReadOnlySpan<byte> valueInBytes = [0x01];
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(bool)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(bool)];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithBool_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            ReadOnlySpan<byte> valueInBytes = [0x01];
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(bool)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(bool)];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithBoolExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                bool value = true;
                int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(bool)];

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public void TryInsert_WhenUsedWithBool_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            ReadOnlySpan<byte> valueInBytes = [0x01];
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(bool)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(bool)];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithBoolExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            bool value = true;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(bool)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToBool_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];
            ReadOnlySpan<byte> valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool actual = sourceBytes.ToBool(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToBool_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];
            ReadOnlySpan<byte> valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool actual = sourceBytes.DangerousToBool(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBool_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];

                // Act and Assert
                sourceBytes.ToBool(index);
            });
        }

        [Fact]
        public void TryToBool_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];
            ReadOnlySpan<byte> valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToBool(index, out bool actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToBool_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            bool expected = default;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];

            // Act
            bool success = sourceBytes.TryToBool(index, out bool actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}