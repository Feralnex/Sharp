using System;
using Xunit;

namespace Sharp.Tests
{
    public class OpenStateTests
    {
        private Gate.State _state;
        private Random _random;

        public OpenStateTests()
        {
            _state = Gate.State.Open;
            _random = new Random();
        }

        [Fact]
        public void IfClosedAcceptingCallback_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndReturnFalse()
        {
            // Arrange
            bool invoked = false;
            Action onClosed = () => invoked = true;

            // Act
            bool result = _state.IfClosed(onClosed);

            // Assert
            Assert.False(result);
            Assert.False(invoked);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndInput_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndReturnFalse()
        {
            // Arrange
            bool invoked = false;
            int inputValue = _random.Next();
            Action<int> onClosed = input =>
            {
                invoked = true;
                Assert.Equal(inputValue, input);
            };

            // Act
            bool result = _state.IfClosed(onClosed, inputValue);

            // Assert
            Assert.False(result);
            Assert.False(invoked);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndOutput_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndAssignDefaultOutputAndReturnFalse()
        {
            // Arrange
            string? expectedOutput = default;
            Func<string> onClosed = () => nameof(expectedOutput);

            // Act
            bool result = _state.IfClosed(onClosed, out string? output);

            // Assert
            Assert.False(result);
            Assert.Null(output);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndInputAndOutput_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndAssignDefaultOutputAndReturnFalse()
        {
            // Arrange
            int inputValue = _random.Next();
            string? expectedOutput = default;
            Func<int, string> onClosed = input => nameof(expectedOutput);

            // Act
            bool result = _state.IfClosed(onClosed, inputValue, out string output);

            // Assert
            Assert.False(result);
            Assert.Null(output);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfOpenAcceptingCallback_WhenCalledOnOpenState_ShouldInvokeCallbackAndReturnTrue()
        {
            // Arrange
            bool invoked = false;
            Action onOpen = () => invoked = true;

            // Act
            bool result = _state.IfOpen(onOpen);

            // Assert
            Assert.True(result);
            Assert.True(invoked);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndInput_WhenCalledOnOpenState_ShouldInvokeCallbackAndReturnTrue()
        {
            // Arrange
            bool invoked = false;
            int inputValue = _random.Next();
            Action<int> onOpen = input => invoked = true;

            // Act
            bool result = _state.IfOpen(onOpen, inputValue);

            // Assert
            Assert.True(result);
            Assert.True(invoked);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndOutput_WhenCalledOnOpenState_ShouldInvokeCallbackAndAssignOutputAndReturnTrue()
        {
            // Arrange
            string expectedOutput = nameof(expectedOutput);
            Func<string> onOpen = () => expectedOutput;

            // Act
            bool result = _state.IfOpen(onOpen, out string output);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndInputAndOutput_WhenCalledOnOpenState_ShouldInvokeCallbackAndAssignOutputAndReturnTrue()
        {
            // Arrange
            int inputValue = _random.Next();
            string? expectedOutput = $"{nameof(expectedOutput)}: " + "{0}";
            Func<int, string> onOpen = input => string.Format(expectedOutput, input);

            // Act
            bool result = _state.IfOpen(onOpen, inputValue, out string output);

            // Assert
            Assert.True(result);
            Assert.Equal(string.Format(expectedOutput, inputValue), output);
        }

        [Fact]
        public void MatchAcceptingCallbacks_WhenCalledOnOpenState_ShouldInvokeOnOpenCallback()
        {
            // Arrange
            bool openInvoked = false;
            bool closedInvoked = false;

            Action onOpen = () => openInvoked = true;
            Action onClosed = () => closedInvoked = true;

            // Act
            _state.Match(onOpen, onClosed);

            // Assert
            Assert.True(openInvoked);
            Assert.False(closedInvoked);
        }

        [Fact]
        public void MatchAcceptingCallbacksAndInput_WhenCalledOnOpenState_ShouldInvokeOnOpenCallback()
        {
            // Arrange
            bool openInvoked = false;
            bool closedInvoked = false;
            int inputValue = _random.Next();

            Action<int> onOpen = input =>
            {
                openInvoked = true;
                Assert.Equal(inputValue, input);
            };
            Action<int> onClosed = input =>
            {
                closedInvoked = true;
                Assert.Equal(inputValue, input);
            };

            // Act
            _state.Match(onOpen, onClosed, inputValue);

            // Assert
            Assert.True(openInvoked);
            Assert.False(closedInvoked);
        }

        [Fact]
        public void MatchAcceptingCallbacks_WhenCalledOnOpenState_ShouldInvokeOnOpenCallbackAndReturnValue()
        {
            // Arrange
            string onOpenResult = nameof(onOpenResult);
            string onClosedResult = nameof(onClosedResult);

            Func<string> onOpen = () => onOpenResult;
            Func<string> onClosed = () => onClosedResult;

            // Act
            string result = _state.Match(onOpen, onClosed);

            // Assert
            Assert.Equal(onOpenResult, result);
        }

        [Fact]
        public void MatchAcceptingCallbacksAndInput_WhenCalledOnOpenState_ShouldInvokeOnOpenCallbackAndReturnValue()
        {
            // Arrange
            int inputValue = _random.Next();
            string expectedOnOpenOutput = $"{nameof(expectedOnOpenOutput)}: " + "{0}";
            string expectedOnClosedOutput = $"{nameof(expectedOnClosedOutput)}: " + "{0}";
            Func<int, string> onOpen = input => string.Format(expectedOnOpenOutput, input);
            Func<int, string> onClosed = input => string.Format(expectedOnClosedOutput, input);

            // Act
            string result = _state.Match(onOpen, onClosed, inputValue);

            // Assert
            Assert.Equal(string.Format(expectedOnOpenOutput, inputValue), result);
        }

        [Fact]
        public void TryMatchAcceptingCallbacksAndOutput_WhenCalledOnOpenState_ShouldCallOnOpenHandlerAndAssignOutputAndReturnFalse()
        {
            // Arrange
            bool openCalled = false;
            bool closedCalled = false;
            string expectedOnOpenOutput = nameof(expectedOnOpenOutput);
            string expectedOnClosedOutput = nameof(expectedOnClosedOutput);
            TryHandler<string> onOpen = (out string? output) =>
            {
                openCalled = true;
                output = expectedOnOpenOutput;
                return false;
            };
            TryHandler<string> onClosed = (out string? output) =>
            {
                closedCalled = true;
                output = expectedOnClosedOutput;
                return true;
            };

            // Act
            bool result = _state.TryMatch(onOpen, onClosed, out string output);

            // Assert
            Assert.False(result);
            Assert.True(openCalled);
            Assert.False(closedCalled);
            Assert.Equal(expectedOnOpenOutput, output);
        }

        [Fact]
        public void TryMatchAcceptingCallbacksAndInputAndOutput_WhenCalledOnOpenState_ShouldCallOnOpenHandlerAndAssignOutputAndReturnFalse()
        {
            // Arrange
            int inputValue = _random.Next();
            bool openCalled = false;
            bool closedCalled = false;
            string expectedOnOpenOutput = $"{nameof(expectedOnOpenOutput)}: " + "{0}";
            string expectedOnClosedOutput = $"{nameof(expectedOnClosedOutput)}: " + "{0}";
            TryHandler<int, string> onOpen = (int input, out string? output) =>
            {
                openCalled = true;
                output = string.Format(expectedOnOpenOutput, input);
                return false;
            };
            TryHandler<int, string> onClosed = (int input, out string? output) =>
            {
                closedCalled = true;
                output = string.Format(expectedOnClosedOutput, input);
                return true;
            };

            // Act
            bool result = _state.TryMatch(onOpen, onClosed, inputValue, out string output);

            // Assert
            Assert.False(result);
            Assert.True(openCalled);
            Assert.False(closedCalled);
            Assert.Equal(string.Format(expectedOnOpenOutput, inputValue), output);
        }
    }
}
