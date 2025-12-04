using System;

namespace Sharp
{
    public partial class Gate
    {
        public abstract partial class State
        {
            public static State Open { get; }
            public static State Closed { get; }

            public abstract bool IsOpen { get; }

            static State()
            {
                Open = new OpenState();
                Closed = new ClosedState();
            }

            public abstract bool IfClosed(Action onClosed);

            public abstract bool IfClosed<TInput>(Action<TInput> onClosed, TInput input);

            public abstract bool IfClosed<TOutput>(Func<TOutput> onClosed, out TOutput output);

            public abstract bool IfClosed<TInput, TOutput>(Func<TInput, TOutput> onClosed, TInput input, out TOutput output);

            public abstract bool IfOpen(Action onOpen);

            public abstract bool IfOpen<TInput>(Action<TInput> onOpen, TInput input);

            public abstract bool IfOpen<TOutput>(Func<TOutput> onOpen, out TOutput output);

            public abstract bool IfOpen<TInput, TOutput>(Func<TInput, TOutput> onOpen, TInput input, out TOutput output);

            public abstract void Match(Action onOpen, Action onClosed);

            public abstract void Match<TInput>(Action<TInput> onOpen, Action<TInput> onClosed, TInput input);

            public abstract TOutput Match<TOutput>(Func<TOutput> onOpen, Func<TOutput> onClosed);

            public abstract TOutput Match<TInput, TOutput>(Func<TInput, TOutput> onOpen, Func<TInput, TOutput> onClosed, TInput input);

            public abstract bool TryMatch<TOutput>(TryHandler<TOutput> onOpen, TryHandler<TOutput> onClosed, out TOutput output);

            public abstract bool TryMatch<TInput, TOutput>(TryHandler<TInput, TOutput> onOpen, TryHandler<TInput, TOutput> onClosed, TInput input, out TOutput output);
        }
    }
}
