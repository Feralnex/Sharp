using Sharp.Extensions;
using Xunit;

namespace Sharp.Tests
{
    public class NumberExtensions
    {
        [Fact]
        public void DangerousIndexOfAnyNumberExcept_WhenValueExists_ShouldReturnCorrectIndex()
        {
            // Arrange
            int[] array = { 5, 5, 5, 2, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 5;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExcept_WhenAllValuesAreSame_ShouldReturnNegativeOne()
        {
            // Arrange
            int[] array = { 5, 5, 5, 5, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 5;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExcept_WhenPassedLengthEqualZero_ShouldReturnNegativeOne()
        {
            // Arrange
            int[] array = { 5, 5, 5, 2, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 0;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExcept_WhenValidSubset_ShouldReturnCorrectIndex()
        {
            // Arrange
            int[] array = { 5, 5, 5, 2, 5 };
            int valueToAvoid = 5;
            int startIndex = 1;
            int searchLength = 3;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExceptAcceptingOffset_WhenValueExists_ShouldReturnCorrectIndex()
        {
            // Arrange
            int[] array = { 5, 5, 5, 2, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 5;
            int offset = 1;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength, offset);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExceptAcceptingOffset_WhenAllValuesAreSame_ShouldReturnNegativeOne()
        {
            // Arrange
            int[] array = { 5, 5, 5, 5, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 5;
            int offset = 1;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength, offset);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExceptAcceptingOffset_WhenPassedLengthEqualZero_ShouldReturnNegativeOne()
        {
            // Arrange
            int[] array = { 5, 5, 5, 2, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 0;
            int offset = 1;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength, offset);

            // Assert
            Assert.Equal(-1, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExceptAcceptingOffset_WhenOffsetIsApplied_ShouldReturnCorrectIndex()
        {
            // Arrange
            int[] array = { 5, 5, 5, 2, 5 };
            int valueToAvoid = 5;
            int startIndex = 1;
            int searchLength = 3;
            int offset = 2;
            ref int searchSpace = ref array[0];

            // Act
            int result = searchSpace.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength, offset);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void DangerousIndexOfAnyNumberExcept_WhenOffsetIsZero_ShouldReturnNegativeOne()
        {
            // Arrange
            int[] array = { 2, 5, 5, 5, 5 };
            int valueToAvoid = 5;
            int startIndex = 0;
            int searchLength = 5;
            int offset = 0;
            ref int arrayRef = ref array[0];

            // Act
            int result = arrayRef.DangerousIndexOfAnyNumberExcept(valueToAvoid, startIndex, searchLength, offset);

            // Assert
            Assert.Equal(-1, result);
        }
    }
}
