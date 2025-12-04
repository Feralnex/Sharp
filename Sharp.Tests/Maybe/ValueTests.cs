using System;
using Xunit;

namespace Sharp.Tests
{
    public class ValueTests
    {
        private Random _random;

        public ValueTests()
            => _random = new Random();

        [Fact]
        public void Initialization_WhenUsedDefaultConstructor_ShouldSetHasSomeToFalse()
        {
            // Arrange and Act
            Value<int> value = new Value<int>();

            // Assert
            Assert.False(value.HasSome);
        }

        [Fact]
        public void Initialization_WhenProvidedValue_ShouldSetHasSomeToTrue()
        {
            // Arrange
            int target = sizeof(ushort);

            // Act
            Value<int> value = new Value<int>(target);

            // Assert
            Assert.True(value.HasSome);
        }

        [Fact]
        public void TryGet_WhenValueDoesNotHaveSome_ShouldReturnFalseAndAssignDefaultOutput()
        {
            // Arrange
            Value<int> value = new Value<int>();

            // Act
            bool success = value.TryGet(out int output);

            // Assert
            Assert.False(success);
            Assert.Equal(default, output);
        }

        [Fact]
        public void TryGet_WhenValueHasSome_ShouldReturnTrueAndAssignOutput()
        {
            // Arrange
            int target = sizeof(uint);
            Value<int> value = new Value<int>(target);

            // Act
            bool success = value.TryGet(out int output);

            // Assert
            Assert.True(success);
            Assert.Equal(target, output);
        }

        [Fact]
        public void Clear_WhenValueDoesNotHaveSome_ShouldDoNothing()
        {
            // Arrange
            Value<int> value = new Value<int>();
            bool hasSomeBeforeClear = value.HasSome;
            int countBeforeClear = value.Count;

            // Act
            value.Clear();

            // Assert
            Assert.Equal(hasSomeBeforeClear, value.HasSome);
            Assert.Equal(countBeforeClear, value.Count);
        }

        [Fact]
        public void Clear_WhenValueHasSome_ShouldResetReference()
        {
            // Arrange
            int target = sizeof(uint);
            Value<int> value = new Value<int>(target);
            bool hasSomeBeforeClear = value.HasSome;
            int countBeforeClear = value.Count;

            // Act
            value.Clear();

            // Assert
            Assert.NotEqual(hasSomeBeforeClear, value.HasSome);
            Assert.NotEqual(countBeforeClear, value.Count);
        }

        [Fact]
        public void IfNoneInvokedWithAction_WhenValueDoesNotHaveSome_ShouldInvokeProvidedActionAndReturnTrue()
        {
            // Arrange
            bool onNoneInvoked = default;
            Value<int> value = new Value<int>();
            void onNone()=> onNoneInvoked = true;

            // Act
            bool matched = value.IfNone(onNone);

            // Assert
            Assert.True(matched);
            Assert.True(onNoneInvoked);
        }

        [Fact]
        public void IfNoneInvokedWithAction_WhenValueHasSome_ShouldReturnFalse()
        {
            // Arrange
            bool onNoneInvoked = default;
            int target = sizeof(ushort);
            Value<int> value = new Value<int>(target);
            void onNone() => onNoneInvoked = true;

            // Act
            bool matched = value.IfNone(onNone);

            // Assert
            Assert.False(matched);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void IfNoneInvokedWithInputAndActionAcceptingInput_WhenValueDoesNotHaveSome_ShouldInvokeProvidedActionPassingInputAndReturnTrue()
        {
            // Arrange
            bool onNoneInvoked = default;
            int input = sizeof(uint);
            Value<int> value = new Value<int>();
            void onNone(int noneInput)
            {
                // Assert
                Assert.Equal(input, noneInput);

                onNoneInvoked = true;
            };

            // Act
            bool matched = value.IfNone(onNone, input);

            // Assert
            Assert.True(matched);
            Assert.True(onNoneInvoked);
        }

        [Fact]
        public void IfNoneInvokedWithInputAndActionAcceptingInput_WhenValueHasSome_ShouldReturnFalse()
        {
            // Arrange
            bool onNoneInvoked = default;
            int target = sizeof(ushort);
            int input = sizeof(uint);
            Value<int> value = new Value<int>(target);
            void onNone(int noneInput)
            {
                // Assert
                Assert.Equal(input, noneInput);

                onNoneInvoked = true;
            };

            // Act
            bool matched = value.IfNone(onNone, input);

            // Assert
            Assert.False(matched);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithAction_WhenValueHasSome_ShouldInvokeProvidedActionAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            int target = sizeof(ushort);
            Value<int> value = new Value<int>(target);
            void onSome() => onSomeInvoked = true;

            // Act
            bool matched = value.IfSome(onSome);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithAction_WhenValueDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            Value<int> value = new Value<int>();
            void onSome() => onSomeInvoked = true;

            // Act
            bool matched = value.IfSome(onSome);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingInput_WhenValueHasSome_ShouldInvokeProvidedActionPassingInputAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            int target = sizeof(ushort);
            int input = sizeof(uint);
            Value<int> value = new Value<int>(target);
            void onSome(int someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = value.IfSome(onSome, input);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingInput_WhenValueDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            int input = sizeof(uint);
            Value<int> value = new Value<int>();
            void onSome(int someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = value.IfSome(onSome, input);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithActionAcceptingTarget_WhenValueHasSome_ShouldInvokeProvidedActionPassingTargetAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            int target = sizeof(ushort);
            Value<int> value = new Value<int>(target);
            void onSome(int someTarget)
            {
                // Assert
                Assert.Equal(target, someTarget);

                onSomeInvoked = true;
            };

            // Act
            bool matched = value.IfSome(onSome);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithActionAcceptingTarget_WhenValueDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            Value<int> value = new Value<int>();
            void onSome(int someTarget) => onSomeInvoked = true;

            // Act
            bool matched = value.IfSome(onSome);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingTargetAndInput_WhenValueHasSome_ShouldInvokeProvidedActionPassingTargetAndInputAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            int target = sizeof(ushort);
            int input = sizeof(uint);
            Value<int> value = new Value<int>(target);
            void onSome(int someTarget, int someInput)
            {
                // Assert
                Assert.Equal(target, someTarget);
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = value.IfSome(onSome, input);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingTargetAndInput_WhenValueDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            int input = sizeof(uint);
            Value<int> value = new Value<int>();
            void onSome(int someTarget, int someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = value.IfSome(onSome, input);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void MatchInvokedWithActionAcceptingTargetAndAction_WhenValueHasSome_ShouldInvokeProvidedActionPassingTarget()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            int target = sizeof(ushort);
            Value<int> value = new Value<int>(target);
            void onSome(int someTarget)
            {
                // Assert
                Assert.Equal(target, someTarget);

                onSomeInvoked = true;
            };
            void onNone() => onNoneInvoked = true;

            // Act
            value.Match(onSome, onNone);

            // Assert
            Assert.True(onSomeInvoked);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void MatchInvokedWithActionAcceptingTargetAndAction_WhenValueDoesNotHaveSome_ShouldInvokeProvidedAction()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            Value<int> value = new Value<int>();
            void onSome(int someTarget) => onSomeInvoked = true;
            void onNone() => onNoneInvoked = true;

            // Act
            value.Match(onSome, onNone);

            // Assert
            Assert.False(onSomeInvoked);
            Assert.True(onNoneInvoked);
        }

        [Fact]
        public void MatchInvokedWithInputAndWithActionAcceptingTargetAndInputAndActionAcceptingInput_WhenValueHasSome_ShouldInvokeProvidedActionPassingTargetAndInput()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            int target = sizeof(ushort);
            int input = sizeof(uint);
            Value<int> value = new Value<int>(target);
            void onSome(int someTarget, int someInput)
            {
                // Assert
                Assert.Equal(target, someTarget);
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };
            void onNone(int someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onNoneInvoked = true;
            };

            // Act
            value.Match(onSome, onNone, input);

            // Assert
            Assert.True(onSomeInvoked);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void MatchInvokedWithInputAndActionAcceptingTargetAndInputAndActionAcceptingInput_WhenValueDoesNotHaveSome_ShouldInvokeProvidedActionPassingInput()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            int input = sizeof(uint);
            Value<int> value = new Value<int>();
            void onSome(int someTarget, int someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };
            void onNone(int someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onNoneInvoked = true;
            };

            // Act
            value.Match(onSome, onNone, input);

            // Assert
            Assert.False(onSomeInvoked);
            Assert.True(onNoneInvoked);
        }
    }
}
