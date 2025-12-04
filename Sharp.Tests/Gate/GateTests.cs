using System;
using Xunit;

namespace Sharp.Tests
{
    public class GateTests
    {
        private Random _random;

        public GateTests()
            => _random = new Random();

        [Fact]
        public void NewGate_WhenCalled_ShouldCreateClosedGate()
        {
            // Arrange & Act
            Gate gate = new Gate();

            // Assert
            Assert.False(gate.IsOpen);
        }

        [Fact]
        public void NewGateAcceptingState_WhenProvidedOpenState_ShouldCreateOpenGate()
        {
            // Arrange & Act
            Gate gate = new Gate(Gate.State.Open);

            // Assert
            Assert.True(gate.IsOpen);
        }

        [Fact]
        public void Close_WhenCalledOnOpenGate_ShouldCloseTheGate()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);

            // Act
            gate.Close();

            // Assert
            Assert.False(gate.IsOpen);
        }

        [Fact]
        public void Close_WhenCalledOnClosedGate_ShouldDoNothing()
        {
            // Arrange
            Gate gate = new Gate();

            // Act
            gate.Close();

            // Assert
            Assert.False(gate.IsOpen);
        }

        [Fact]
        public void Open_WhenCalledOnClosedGate_ShouldOpenTheGate()
        {
            // Arrange
            Gate gate = new Gate();

            // Act
            gate.Open();

            // Assert
            Assert.True(gate.IsOpen);
        }

        [Fact]
        public void Open_WhenCalledOnOpenGate_ShouldDoNothing()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);

            // Act
            gate.Open();

            // Assert
            Assert.True(gate.IsOpen);
        }

        [Fact]
        public void IfClosedAcceptingCallback_WhenCalledOnClosedGate_ShouldInvokeCallbackAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate();
            bool invoked = false;
            Action onClosed = () => invoked = true;

            // Act
            bool result = gate.IfClosed(onClosed);

            // Assert
            Assert.True(result);
            Assert.True(invoked);
        }

        [Fact]
        public void IfClosedAcceptingCallback_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            bool invoked = false;
            Action onClosed = () => invoked = true;

            // Act
            bool result = gate.IfClosed(onClosed);

            // Assert
            Assert.False(result);
            Assert.False(invoked);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndInput_WhenCalledOnClosedGate_ShouldInvokeCallbackAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate();
            bool invoked = false;
            int inputValue = _random.Next();
            Action<int> onClosed = input =>
            {
                invoked = true;
                Assert.Equal(inputValue, input);
            };

            // Act
            bool result = gate.IfClosed(onClosed, inputValue);

            // Assert
            Assert.True(result);
            Assert.True(invoked);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndInput_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            bool invoked = false;
            int inputValue = _random.Next();
            Action<int> onClosed = input =>
            {
                invoked = true;
                Assert.Equal(inputValue, input);
            };

            // Act
            bool result = gate.IfClosed(onClosed, inputValue);

            // Assert
            Assert.False(result);
            Assert.False(invoked);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndOutput_WhenCalledOnClosedGate_ShouldInvokeCallbackAndAssignOutputAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate();
            string expectedOutput = nameof(expectedOutput);
            Func<string> onClosed = () => expectedOutput;

            // Act
            bool result = gate.IfClosed(onClosed, out string output);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndOutput_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndAssignDefaultOutputAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            string? expectedOutput = default;
            Func<string> onClosed = () => nameof(expectedOutput);

            // Act
            bool result = gate.IfClosed(onClosed, out string? output);

            // Assert
            Assert.False(result);
            Assert.Null(output);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndInputAndOutput_WhenCalledOnClosedGate_ShouldInvokeCallbackAndAssignOutputAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate();
            int inputValue = _random.Next();
            string expectedOutput = $"{nameof(expectedOutput)}: " + "{0}";
            Func<int, string> onClosed = input => string.Format(expectedOutput, input);

            // Act
            bool result = gate.IfClosed(onClosed, inputValue, out string output);

            // Assert
            Assert.True(result);
            Assert.Equal(string.Format(expectedOutput, inputValue), output);
        }

        [Fact]
        public void IfClosedAcceptingCallbackAndInputAndOutput_WhenCalledOnOpenState_ShouldNotInvokeCallbackAndAssignDefaultOutputAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            int inputValue = _random.Next();
            string? expectedOutput = default;
            Func<int, string> onClosed = input => nameof(expectedOutput);

            // Act
            bool result = gate.IfClosed(onClosed, inputValue, out string output);

            // Assert
            Assert.False(result);
            Assert.Null(output);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfOpenAcceptingCallback_WhenCalledOnClosedGate_ShouldNotInvokeCallbackAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate();
            bool invoked = false;
            Action onOpen = () => invoked = true;

            // Act
            bool result = gate.IfOpen(onOpen);

            // Assert
            Assert.False(result);
            Assert.False(invoked);
        }

        [Fact]
        public void IfOpenAcceptingCallback_WhenCalledOnOpenState_ShouldInvokeCallbackAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            bool invoked = false;
            Action onOpen = () => invoked = true;

            // Act
            bool result = gate.IfOpen(onOpen);

            // Assert
            Assert.True(result);
            Assert.True(invoked);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndInput_WhenCalledOnClosedGate_ShouldNotInvokeCallbackAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate();
            bool invoked = false;
            int inputValue = _random.Next();
            Action<int> onOpen = input => invoked = true;

            // Act
            bool result = gate.IfOpen(onOpen, inputValue);

            // Assert
            Assert.False(result);
            Assert.False(invoked);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndInput_WhenCalledOnOpenState_ShouldInvokeCallbackAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            bool invoked = false;
            int inputValue = _random.Next();
            Action<int> onOpen = input => invoked = true;

            // Act
            bool result = gate.IfOpen(onOpen, inputValue);

            // Assert
            Assert.True(result);
            Assert.True(invoked);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndOutput_WhenCalledOnClosedGate_ShouldNotInvokeCallbackAndAssignDefaultOutputAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate();
            string? expectedOutput = default;
            Func<string> onOpen = () => nameof(expectedOutput);

            // Act
            bool result = gate.IfOpen(onOpen, out string output);

            // Assert
            Assert.False(result);
            Assert.Null(output);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndOutput_WhenCalledOnOpenState_ShouldInvokeCallbackAndAssignOutputAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            string expectedOutput = nameof(expectedOutput);
            Func<string> onOpen = () => expectedOutput;

            // Act
            bool result = gate.IfOpen(onOpen, out string output);

            // Assert
            Assert.True(result);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndInputAndOutput_WhenCalledOnClosedGate_ShouldNotInvokeCallbackAndAssignDefaultOutputAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate();
            int inputValue = _random.Next();
            string? expectedOutput = default;
            Func<int, string> onOpen = input => nameof(expectedOutput);

            // Act
            bool result = gate.IfOpen(onOpen, inputValue, out string output);

            // Assert
            Assert.False(result);
            Assert.Null(output);
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void IfOpenAcceptingCallbackAndInputAndOutput_WhenCalledOnOpenState_ShouldInvokeCallbackAndAssignOutputAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            int inputValue = _random.Next();
            string? expectedOutput = $"{nameof(expectedOutput)}: " + "{0}";
            Func<int, string> onOpen = input => string.Format(expectedOutput, input);

            // Act
            bool result = gate.IfOpen(onOpen, inputValue, out string output);

            // Assert
            Assert.True(result);
            Assert.Equal(string.Format(expectedOutput, inputValue), output);
        }

        [Fact]
        public void MatchAcceptingCallbacks_WhenCalledOnClosedGate_ShouldInvokeOnClosedCallback()
        {
            // Arrange
            Gate gate = new Gate();
            bool openInvoked = false;
            bool closedInvoked = false;

            Action onOpen = () => openInvoked = true;
            Action onClosed = () => closedInvoked = true;

            // Act
            gate.Match(onOpen, onClosed);

            // Assert
            Assert.False(openInvoked);
            Assert.True(closedInvoked);
        }

        [Fact]
        public void MatchAcceptingCallbacks_WhenCalledOnOpenState_ShouldInvokeOnOpenCallback()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            bool openInvoked = false;
            bool closedInvoked = false;

            Action onOpen = () => openInvoked = true;
            Action onClosed = () => closedInvoked = true;

            // Act
            gate.Match(onOpen, onClosed);

            // Assert
            Assert.True(openInvoked);
            Assert.False(closedInvoked);
        }

        [Fact]
        public void MatchAcceptingCallbacksAndInput_WhenCalledOnClosedGate_ShouldInvokeOnClosedCallback()
        {
            // Arrange
            Gate gate = new Gate();
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
            gate.Match(onOpen, onClosed, inputValue);

            // Assert
            Assert.False(openInvoked);
            Assert.True(closedInvoked);
        }

        [Fact]
        public void MatchAcceptingCallbacksAndInput_WhenCalledOnOpenState_ShouldInvokeOnOpenCallback()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
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
            gate.Match(onOpen, onClosed, inputValue);

            // Assert
            Assert.True(openInvoked);
            Assert.False(closedInvoked);
        }

        [Fact]
        public void MatchAcceptingCallbacks_WhenCalledOnClosedGate_ShouldInvokeOnClosedCallbackAndReturnValue()
        {
            // Arrange
            Gate gate = new Gate();
            string onOpenResult = nameof(onOpenResult);
            string onClosedResult = nameof(onClosedResult);

            Func<string> onOpen = () => onOpenResult;
            Func<string> onClosed = () => onClosedResult;

            // Act
            string result = gate.Match(onOpen, onClosed);

            // Assert
            Assert.Equal(onClosedResult, result);
        }

        [Fact]
        public void MatchAcceptingCallbacks_WhenCalledOnOpenState_ShouldInvokeOnOpenCallbackAndReturnValue()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            string onOpenResult = nameof(onOpenResult);
            string onClosedResult = nameof(onClosedResult);

            Func<string> onOpen = () => onOpenResult;
            Func<string> onClosed = () => onClosedResult;

            // Act
            string result = gate.Match(onOpen, onClosed);

            // Assert
            Assert.Equal(onOpenResult, result);
        }

        [Fact]
        public void MatchAcceptingCallbacksAndInput_WhenCalledOnClosedGate_ShouldInvokeOnClosedCallbackAndRetunValue()
        {
            // Arrange
            Gate gate = new Gate();
            int inputValue = _random.Next();
            string expectedOnOpenOutput = $"{nameof(expectedOnOpenOutput)}: " + "{0}";
            string expectedOnClosedOutput = $"{nameof(expectedOnClosedOutput)}: " + "{0}";
            Func<int, string> onOpen = input => string.Format(expectedOnOpenOutput, input);
            Func<int, string> onClosed = input => string.Format(expectedOnClosedOutput, input);

            // Act
            string result = gate.Match(onOpen, onClosed, inputValue);
            
            // Assert
            Assert.Equal(string.Format(expectedOnClosedOutput, inputValue), result);
        }

        [Fact]
        public void MatchAcceptingCallbacksAndInput_WhenCalledOnOpenState_ShouldInvokeOnOpenCallbackAndReturnValue()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
            int inputValue = _random.Next();
            string expectedOnOpenOutput = $"{nameof(expectedOnOpenOutput)}: " + "{0}";
            string expectedOnClosedOutput = $"{nameof(expectedOnClosedOutput)}: " + "{0}";
            Func<int, string> onOpen = input => string.Format(expectedOnOpenOutput, input);
            Func<int, string> onClosed = input => string.Format(expectedOnClosedOutput, input);

            // Act
            string result = gate.Match(onOpen, onClosed, inputValue);

            // Assert
            Assert.Equal(string.Format(expectedOnOpenOutput, inputValue), result);
        }

        [Fact]
        public void TryMatchAcceptingCallbacksAndOutput_WhenCalledOnClosedGate_ShouldCallOnClosedHandlerAndAssignOutputAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate();
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
            bool result = gate.TryMatch(onOpen, onClosed, out string output);

            // Assert
            Assert.True(result);
            Assert.False(openCalled);
            Assert.True(closedCalled);
            Assert.Equal(expectedOnClosedOutput, output);
        }

        [Fact]
        public void TryMatchAcceptingCallbacksAndOutput_WhenCalledOnOpenState_ShouldCallOnOpenHandlerAndAssignOutputAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
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
            bool result = gate.TryMatch(onOpen, onClosed, out string output);

            // Assert
            Assert.False(result);
            Assert.True(openCalled);
            Assert.False(closedCalled);
            Assert.Equal(expectedOnOpenOutput, output);
        }

        [Fact]
        public void TryMatchAcceptingCallbacksAndInput_WhenCalledOnClosedGate_ShouldCallOnClosedHandlerAndAssignOutputAndReturnTrue()
        {
            // Arrange
            Gate gate = new Gate();
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
            bool result = gate.TryMatch(onOpen, onClosed, inputValue, out string output);

            // Assert
            Assert.True(result);
            Assert.False(openCalled);
            Assert.True(closedCalled);
            Assert.Equal(string.Format(expectedOnClosedOutput, inputValue), output);
        }

        [Fact]
        public void TryMatchAcceptingCallbacksAndInput_WhenCalledOnOpenState_ShouldCallOnOpenHandlerAndAssignOutputAndReturnFalse()
        {
            // Arrange
            Gate gate = new Gate(Gate.State.Open);
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
            bool result = gate.TryMatch(onOpen, onClosed, inputValue, out string output);

            // Assert
            Assert.False(result);
            Assert.True(openCalled);
            Assert.False(closedCalled);
            Assert.Equal(string.Format(expectedOnOpenOutput, inputValue), output);
        }
    }
}
