using Sharp.Helpers;
using System;
using Xunit;

namespace Sharp.Tests
{
    public unsafe partial class PointerTests
    {
        private Random _random;

        public PointerTests()
            => _random = new Random();

        [Fact]
        public void Insert_WhenUsedWithBool_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            byte[] valueInBytes = [0x01];
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(bool);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.Insert(actual, length, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithBool_ShouldInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            byte[] valueInBytes = [0x01];
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(bool);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            Pointer.DangerousInsert(actual, index: offset, value);

            // Assert
            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void Insert_WhenUsedWithBoolExceedingBytePointerSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            bool value = true;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(bool);
            byte* actual = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.Insert(actual, length, index, value));
        }

        [Fact]
        public void TryInsert_WhenUsedWithBool_ShouldReturnTrueAndInsertValueWhereBytePointerPointsToAtProvidedIndex()
        {
            // Arrange
            bool value = true;
            byte[] valueInBytes = [0x01];
            int offset = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(bool);
            byte* actual = stackalloc byte[length];
            byte[] expected = new byte[length];

            for (int sourceIndex = 0, destinationIndex = offset; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryInsert(actual, length, index: offset, value);

            // Assert
            Assert.True(success);

            for (int index = 0; index < length; index++)
                Assert.Equal(expected[index], actual[index]);
        }

        [Fact]
        public void TryInsert_WhenUsedWithBoolExceedingBytePointerSpace_ShouldReturnFalse()
        {
            // Arrange
            bool value = true;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(bool);
            byte* actual = stackalloc byte[length];

            // Act
            bool success = Pointer.TryInsert(actual, length, index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToBool_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(bool);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool actual = Pointer.ToBool(sourceBytes, length, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToBool_WhenUsedOnBytePointer_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(bool);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool actual = Pointer.DangerousToBool(sourceBytes, index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToBool_WhenUsedOnBytePointerExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            // Arrange
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(bool);
            byte* sourceBytes = stackalloc byte[length];

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => Pointer.ToBool(sourceBytes, length, index));
        }

        [Fact]
        public void TryToBool_WhenUsedOnBytePointer_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            bool expected = true;
            int index = _random.Next(sizeof(decimal));
            int length = sizeof(decimal) + sizeof(bool);
            byte* sourceBytes = stackalloc byte[length];
            byte[] valueInBytes = [0x01];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = Pointer.TryToBool(sourceBytes, length, index, out bool actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToBool_WhenUsedOnBytePointerExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            bool expected = default;
            int index = _random.Next(sizeof(byte), sizeof(bool)) + sizeof(decimal);
            int length = sizeof(decimal) + sizeof(bool);
            byte* sourceBytes = stackalloc byte[length];

            // Act
            bool success = Pointer.TryToBool(sourceBytes, length, index, out bool actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}