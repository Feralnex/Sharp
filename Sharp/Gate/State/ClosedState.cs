using System;

namespace Sharp
{
    public partial class Gate
    {
        public abstract partial class State
        {
            private class ClosedState : State
            {
                public override bool IsOpen => false;

                public override bool IfClosed(Action onClosed)
                {
                    onClosed();

                    return true;
                }

                public override bool IfClosed<TInput>(Action<TInput> onClosed, TInput input)
                {
                    onClosed(input);

                    return true;
                }

                public override bool IfClosed<TOutput>(Func<TOutput> onClosed, out TOutput output)
                {
                    output = onClosed();

                    return true;
                }

                public override bool IfClosed<TInput, TOutput>(Func<TInput, TOutput> onClosed, TInput input, out TOutput output)
                {
                    output = onClosed(input);

                    return true;
                }

                public override bool IfOpen(Action onOpen)
                    => false;

                public override bool IfOpen<TInput>(Action<TInput> onOpen, TInput input)
                    => false;

                public override bool IfOpen<TOutput>(Func<TOutput> onOpen, out TOutput output)
                {
                    output = default!;

                    return false;
                }

                public override bool IfOpen<TInput, TOutput>(Func<TInput, TOutput> onOpen, TInput input, out TOutput output)
                {
                    output = default!;

                    return false;
                }

                public override void Match(Action onOpen, Action onClosed)
                    => onClosed();

                public override void Match<TInput>(Action<TInput> onOpen, Action<TInput> onClosed, TInput input)
                    => onClosed(input);

                public override TOutput Match<TOutput>(Func<TOutput> onOpen, Func<TOutput> onClosed)
                    => onClosed();

                public override TOutput Match<TInput, TOutput>(Func<TInput, TOutput> onOpen, Func<TInput, TOutput> onClosed, TInput input)
                    => onClosed(input);

                public override bool TryMatch<TOutput>(TryHandler<TOutput> onOpen, TryHandler<TOutput> onClosed, out TOutput output)
                    => onClosed(out output!);

                public override bool TryMatch<TInput, TOutput>(TryHandler<TInput, TOutput> onOpen, TryHandler<TInput, TOutput> onClosed, TInput input, out TOutput output)
                    => onClosed(input, out output!);
            }
        }
    }
}
