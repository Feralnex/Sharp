using Sharp.Extensions;
using System;
using System.Runtime.CompilerServices;
using Xunit;

namespace Sharp.Tests
{
    public partial class SpanOfBytesExtensionsTests
    {
        [Fact]
        public void Insert_WhenUsedWithDouble_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsert_WhenUsedWithDouble_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void InsertInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.Insert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            actual.DangerousInsert(index, value, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Insert_WhenUsedWithDoubleExceedingSpanOfBytesSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                ulong input = 0x123456789ABCDEFE;
                double value = Unsafe.As<ulong, double>(ref input);
                int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(decimal);
                Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];

                // Act and Assert
                actual.Insert(index, value);
            });
        }

        [Fact]
        public void TryInsert_WhenUsedWithDouble_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToFalse_WhenUsedWithDouble_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: false);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsertInvokedWithBigEndianSetToTrue_WhenUsedWithDouble_ShouldReturnTrueAndInsertValueIntoSpanOfBytesAtProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];
            Span<byte> expected = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                expected[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = actual.TryInsert(index, value, bigEndian: true);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryInsert_WhenUsedWithDoubleExceedingSpanOfBytesSpace_ShouldReturnFalse()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double value = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(decimal);
            Span<byte> actual = new byte[sizeof(decimal) + sizeof(double)];

            // Act
            bool success = actual.TryInsert(index, value);

            // Assert
            Assert.False(success);
        }

        [Fact]
        public void ToDouble_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = sourceBytes.ToDouble(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDouble_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = sourceBytes.DangerousToDouble(index);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDoubleInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = sourceBytes.ToDouble(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDoubleInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = sourceBytes.DangerousToDouble(index, bigEndian: false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDoubleInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = sourceBytes.ToDouble(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DangerousToDoubleInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            double actual = sourceBytes.DangerousToDouble(index, bigEndian: true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToDouble_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldThrowIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                // Arrange
                int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(decimal);
                ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];

                // Act and Assert
                sourceBytes.ToDouble(index);
            });
        }

        [Fact]
        public void TryToDouble_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes;

            if (BitConverter.IsLittleEndian)
                valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];
            else
                valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToDouble(index, out double actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDoubleInvokedWithBigEndianSetToFalse_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0xFE, 0xDE, 0xBC, 0x9A, 0x78, 0x56, 0x34, 0x12];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToDouble(index, bigEndian: false, out double actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDoubleInvokedWithBigEndianSetToTrue_WhenUsedWithSpanOfBytes_ShouldReturnTrueAndAssignValueStartingFromTheProvidedIndex()
        {
            // Arrange
            ulong input = 0x123456789ABCDEFE;
            double expected = Unsafe.As<ulong, double>(ref input);
            int index = _random.Next(sizeof(decimal));
            Span<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];
            ReadOnlySpan<byte> valueInBytes = [0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFE];

            for (int sourceIndex = 0, destinationIndex = index; sourceIndex < valueInBytes.Length; sourceIndex++, destinationIndex++)
                sourceBytes[destinationIndex] = valueInBytes[sourceIndex];

            // Act
            bool success = sourceBytes.TryToDouble(index, bigEndian: true, out double actual);

            // Assert
            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryToDouble_WhenUsedWithSpanOfBytesExceedingItsSpace_ShouldReturnFalseAndAssignDefaultValue()
        {
            // Arrange
            double expected = default;
            int index = _random.Next(sizeof(byte), sizeof(double)) + sizeof(decimal);
            ReadOnlySpan<byte> sourceBytes = new byte[sizeof(decimal) + sizeof(double)];

            // Act
            bool success = sourceBytes.TryToDouble(index, out double actual);

            // Assert
            Assert.False(success);
            Assert.Equal(expected, actual);
        }
    }
}