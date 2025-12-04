using System;
using Xunit;

namespace Sharp.Tests
{
    public class ReferenceTests
    {
        private Random _random;

        public ReferenceTests()
            => _random = new Random();

        [Fact]
        public void NewReference_WhenUsedDefaultConstructor_ShouldSetHasSomeToFalse()
        {
            // Arrange & Act
            Reference<string> reference = new Reference<string>();

            // Assert
            Assert.False(reference.HasSome);
        }

        [Fact]
        public void NewReference_WhenProvidedObjectReference_ShouldSetHasSomeToTrue()
        {
            // Arrange
            string target = nameof(target);

            // Act
            Reference<string> reference = new Reference<string>(target);

            // Assert
            Assert.True(reference.HasSome);
        }

        [Fact]
        public void NewReference_WhenProvidedNullReference_ShouldSetHasSomeToFalse()
        {
            // Arrange
            string? target = null;

            // Act
            Reference<string> reference = new Reference<string>(target!);

            // Assert
            Assert.False(reference.HasSome);
        }

        [Fact]
        public void TryGet_WhenReferenceDoesNotHaveSome_ShouldReturnFalseAndAssignDefaultOutput()
        {
            // Arrange
            Reference<string> reference = new Reference<string>();

            // Act
            bool success = reference.TryGet(out string? output);

            // Assert
            Assert.False(success);
            Assert.Equal(default, output);
        }

        [Fact]
        public void TryGet_WhenReferenceHasSome_ShouldReturnTrueAndAssignOutput()
        {
            // Arrange
            string target = nameof(target);
            Reference<string> reference = new Reference<string>(target);

            // Act
            bool success = reference.TryGet(out string? output);

            // Assert
            Assert.True(success);
            Assert.Equal(target, output);
        }

        [Fact]
        public void Clear_WhenReferenceDoesNotHaveSome_ShouldDoNothing()
        {
            // Arrange
            Reference<string> reference = new Reference<string>();
            bool hasSomeBeforeClear = reference.HasSome;
            int countBeforeClear = reference.Count;

            // Act
            reference.Clear();

            // Assert
            Assert.Equal(hasSomeBeforeClear, reference.HasSome);
            Assert.Equal(countBeforeClear, reference.Count);
        }

        [Fact]
        public void Clear_WhenReferenceHasSome_ShouldResetReference()
        {
            // Arrange
            string target = nameof(target);
            Reference<string> reference = new Reference<string>(target);
            bool hasSomeBeforeClear = reference.HasSome;
            int countBeforeClear = reference.Count;

            // Act
            reference.Clear();

            // Assert
            Assert.NotEqual(hasSomeBeforeClear, reference.HasSome);
            Assert.NotEqual(countBeforeClear, reference.Count);
        }

        [Fact]
        public void IfNoneInvokedWithAction_WhenReferenceDoesNotHaveSome_ShouldInvokeProvidedActionAndReturnTrue()
        {
            // Arrange
            bool onNoneInvoked = default;
            Reference<string> reference = new Reference<string>();
            void onNone() => onNoneInvoked = true;

            // Act
            bool matched = reference.IfNone(onNone);

            // Assert
            Assert.True(matched);
            Assert.True(onNoneInvoked);
        }

        [Fact]
        public void IfNoneInvokedWithAction_WhenReferenceHasSome_ShouldReturnFalse()
        {
            // Arrange
            bool onNoneInvoked = default;
            string target = nameof(target);
            Reference<string> reference = new Reference<string>(target);
            void onNone() => onNoneInvoked = true;

            // Act
            bool matched = reference.IfNone(onNone);

            // Assert
            Assert.False(matched);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void IfNoneInvokedWithInputAndActionAcceptingInput_WhenReferenceDoesNotHaveSome_ShouldInvokeProvidedActionPassingInputAndReturnTrue()
        {
            // Arrange
            bool onNoneInvoked = default;
            string input = nameof(input);
            Reference<string> reference = new Reference<string>();
            void onNone(string noneInput)
            {
                // Assert
                Assert.Equal(input, noneInput);

                onNoneInvoked = true;
            };

            // Act
            bool matched = reference.IfNone(onNone, input);

            // Assert
            Assert.True(matched);
            Assert.True(onNoneInvoked);
        }

        [Fact]
        public void IfNoneInvokedWithInputAndActionAcceptingInput_WhenReferenceHasSome_ShouldReturnFalse()
        {
            // Arrange
            bool onNoneInvoked = default;
            string target = nameof(target);
            string input = nameof(input);
            Reference<string> reference = new Reference<string>(target);
            void onNone(string noneInput)
            {
                // Assert
                Assert.Equal(input, noneInput);

                onNoneInvoked = true;
            };

            // Act
            bool matched = reference.IfNone(onNone, input);

            // Assert
            Assert.False(matched);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithAction_WhenReferenceHasSome_ShouldInvokeProvidedActionAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            string target = nameof(target);
            Reference<string> reference = new Reference<string>(target);
            void onSome() => onSomeInvoked = true;

            // Act
            bool matched = reference.IfSome(onSome);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithAction_WhenReferenceDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            Reference<string> reference = new Reference<string>();
            void onSome() => onSomeInvoked = true;

            // Act
            bool matched = reference.IfSome(onSome);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingInput_WhenReferenceHasSome_ShouldInvokeProvidedActionPassingInputAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            string target = nameof(target);
            string input = nameof(input);
            Reference<string> reference = new Reference<string>(target);
            void onSome(string someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = reference.IfSome(onSome, input);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingInput_WhenReferenceDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            string input = nameof(input);
            Reference<string> reference = new Reference<string>();
            void onSome(string someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = reference.IfSome(onSome, input);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithActionAcceptingTarget_WhenReferenceHasSome_ShouldInvokeProvidedActionPassingTargetAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            string target = nameof(target);
            Reference<string> reference = new Reference<string>(target);
            void onSome(string someTarget)
            {
                // Assert
                Assert.Equal(target, someTarget);

                onSomeInvoked = true;
            };

            // Act
            bool matched = reference.IfSome(onSome);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithActionAcceptingTarget_WhenReferenceDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            Reference<string> reference = new Reference<string>();
            void onSome(string someTarget) => onSomeInvoked = true;

            // Act
            bool matched = reference.IfSome(onSome);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingTargetAndInput_WhenReferenceHasSome_ShouldInvokeProvidedActionPassingTargetAndInputAndReturnTrue()
        {
            // Arrange
            bool onSomeInvoked = default;
            string target = nameof(target);
            string input = nameof(input);
            Reference<string> reference = new Reference<string>(target);
            void onSome(string someTarget, string someInput)
            {
                // Assert
                Assert.Equal(target, someTarget);
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = reference.IfSome(onSome, input);

            // Assert
            Assert.True(matched);
            Assert.True(onSomeInvoked);
        }

        [Fact]
        public void IfSomeInvokedWithInputAndActionAcceptingTargetAndInput_WhenReferenceDoesNotHaveSome_ShouldReturnFalse()
        {
            // Arrange
            bool onSomeInvoked = default;
            string input = nameof(input);
            Reference<string> reference = new Reference<string>();
            void onSome(string someTarget, string someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };

            // Act
            bool matched = reference.IfSome(onSome, input);

            // Assert
            Assert.False(matched);
            Assert.False(onSomeInvoked);
        }

        [Fact]
        public void MatchInvokedWithActionAcceptingTargetAndAction_WhenReferenceHasSome_ShouldInvokeProvidedActionPassingTarget()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            string target = nameof(target);
            Reference<string> reference = new Reference<string>(target);
            void onSome(string someTarget)
            {
                // Assert
                Assert.Equal(target, someTarget);

                onSomeInvoked = true;
            };
            void onNone() => onNoneInvoked = true;

            // Act
            reference.Match(onSome, onNone);

            // Assert
            Assert.True(onSomeInvoked);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void MatchInvokedWithActionAcceptingTargetAndAction_WhenReferenceDoesNotHaveSome_ShouldInvokeProvidedAction()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            Reference<string> reference = new Reference<string>();
            void onSome(string someTarget) => onSomeInvoked = true;
            void onNone() => onNoneInvoked = true;

            // Act
            reference.Match(onSome, onNone);

            // Assert
            Assert.False(onSomeInvoked);
            Assert.True(onNoneInvoked);
        }

        [Fact]
        public void MatchInvokedWithInputAndWithActionAcceptingTargetAndInputAndActionAcceptingInput_WhenReferenceHasSome_ShouldInvokeProvidedActionPassingTargetAndInput()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            string target = nameof(target);
            string input = nameof(input);
            Reference<string> reference = new Reference<string>(target);
            void onSome(string someTarget, string someInput)
            {
                // Assert
                Assert.Equal(target, someTarget);
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };
            void onNone(string someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onNoneInvoked = true;
            };

            // Act
            reference.Match(onSome, onNone, input);

            // Assert
            Assert.True(onSomeInvoked);
            Assert.False(onNoneInvoked);
        }

        [Fact]
        public void MatchInvokedWithInputAndActionAcceptingTargetAndInputAndActionAcceptingInput_WhenReferenceDoesNotHaveSome_ShouldInvokeProvidedActionPassingInput()
        {
            // Arrange
            bool onSomeInvoked = default;
            bool onNoneInvoked = default;
            string input = nameof(input);
            Reference<string> reference = new Reference<string>();
            void onSome(string someTarget, string someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onSomeInvoked = true;
            };
            void onNone(string someInput)
            {
                // Assert
                Assert.Equal(input, someInput);

                onNoneInvoked = true;
            };

            // Act
            reference.Match(onSome, onNone, input);

            // Assert
            Assert.False(onSomeInvoked);
            Assert.True(onNoneInvoked);
        }
    }
}
