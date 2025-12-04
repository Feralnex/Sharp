using Sharp.Extensions;
using System;
using Xunit;

namespace Sharp.Tests
{
    public partial class ByteArrayExtensionsTests
    {
        private readonly Random _random;

        public ByteArrayExtensionsTests()
            => _random = new Random();

        [Fact]
        public void Insert_WhenUsedWithBool_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            byte[] valueInBytes = [0x01];
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(bool)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(bool)];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithBool_ShouldInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            byte[] valueInBytes = [0x01];
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(bool)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(bool)];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithBoolExceedingByteArraySpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            bool value = true;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(bool)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => actual.Insert(index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithBool_ShouldReturnTrueAndInsertValueIntoByteArrayAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            byte[] valueInBytes = [0x01];
            int index = _random.Next(sizeof(decimal));
            byte[] actual = new byte[sizeof(decimal) + sizeof(bool)];
            byte[] expected = new byte[sizeof(decimal) + sizeof(bool)];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithBoolExceedingByteArraySpace_ShouldReturnFalse()
        {
            // Arrange
            bool value = true;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            byte[] actual = new byte[sizeof(decimal) + sizeof(bool)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToBool_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];
            byte[] valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool actual = sourceBytes.ToBool(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToBool_WhenUsedWithByteArray_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];
            byte[] valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool actual = sourceBytes.DangerousToBool(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBool_WhenUsedWithByteArrayExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => sourceBytes.ToBool(index));
        }

        [Fact]
        public void TryToBool_WhenUsedWithByteArray_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];
            byte[] valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToBool(index, out bool actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToBool_WhenUsedWithByteArrayExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            bool expected = default;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            byte[] sourceBytes = new byte[sizeof(decimal) + sizeof(bool)];

            // Act
            bool success = sourceBytes.TryToBool(index, out bool actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}