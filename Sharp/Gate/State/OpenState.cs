using System;

namespace Sharp
{
    public partial class Gate
    {
        public abstract partial class State
        {
            private class OpenState : State
            {
                public override bool IsOpen => true;

                public override bool IfClosed(Action onClosed)
                    => false;

                public override bool IfClosed<TInput>(Action<TInput> onClosed, TInput input)
                    => false;

                public override bool IfClosed<TOutput>(Func<TOutput> onClosed, out TOutput output)
                {
                    output = default!;

                    return false;
                }

                public override bool IfClosed<TInput, TOutput>(Func<TInput, TOutput> onClosed, TInput input, out TOutput output)
                {
                    output = default!;

                    return false;
                }

                public override bool IfOpen(Action onOpen)
                {
                    onOpen();

                    return true;
                }

                public override bool IfOpen<TInput>(Action<TInput> onOpen, TInput input)
                {
                    onOpen(input);

                    return true;
                }

                public override bool IfOpen<TOutput>(Func<TOutput> onOpen, out TOutput output)
                {
                    output = onOpen();

                    return true;
                }

                public override bool IfOpen<TInput, TOutput>(Func<TInput, TOutput> onOpen, TInput input, out TOutput output)
                {
                    output = onOpen(input);

                    return true;
                }

                public override void Match(Action onOpen, Action onClosed)
                    => onOpen();

                public override void Match<TInput>(Action<TInput> onOpen, Action<TInput> onClosed, TInput input)
                    => onOpen(input);

                public override TOutput Match<TOutput>(Func<TOutput> onOpen, Func<TOutput> onClosed)
                    => onOpen();

                public override TOutput Match<TInput, TOutput>(Func<TInput, TOutput> onOpen, Func<TInput, TOutput> onClosed, TInput input)
                    => onOpen(input);

                public override bool TryMatch<TOutput>(TryHandler<TOutput> onOpen, TryHandler<TOutput> onClosed, out TOutput output)
                    => onOpen(out output!);

                public override bool TryMatch<TInput, TOutput>(TryHandler<TInput, TOutput> onOpen, TryHandler<TInput, TOutput> onClosed, TInput input, out TOutput output)
                    => onOpen(input, out output!);
            }
        }
    }
}
