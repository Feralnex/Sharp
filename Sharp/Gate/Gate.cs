using System;

namespace Sharp
{
    public partial class Gate
    {
        private volatile State _state;

        public bool IsOpen => _state.IsOpen;

        public Gate()
        {
            _state = State.Closed;
        }

        public Gate(State state)
        {
            _state = state;
        }

        public void Close()
            => _state = State.Closed;

        public void Open()
            => _state = State.Open;

        public bool IfClosed(Action onClosed)
            => _state.IfClosed(onClosed);

        public bool IfClosed<TInput>(Action<TInput> onClosed, TInput input)
            => _state.IfClosed(onClosed, input);

        public bool IfClosed<TOutput>(Func<TOutput> onClosed, out TOutput output)
            => _state.IfClosed(onClosed, out output);

        public bool IfClosed<TInput, TOutput>(Func<TInput, TOutput> onClosed, TInput input, out TOutput output)
            => _state.IfClosed(onClosed, input, out output);

        public bool IfOpen(Action onOpen)
            => _state.IfOpen(onOpen);

        public bool IfOpen<TInput>(Action<TInput> onOpen, TInput input)
            => _state.IfOpen(onOpen, input);

        public bool IfOpen<TOutput>(Func<TOutput> onOpen, out TOutput output)
            => _state.IfOpen(onOpen, out output);

        public bool IfOpen<TInput, TOutput>(Func<TInput, TOutput> onOpen, TInput input, out TOutput output)
            => _state.IfOpen(onOpen, input, out output);

        public void Match(Action onOpen, Action onClosed)
            => _state.Match(onOpen, onClosed);

        public void Match<TInput>(Action<TInput> onOpen, Action<TInput> onClosed, TInput input)
            => _state.Match(onOpen, onClosed, input);

        public TOutput Match<TOutput>(Func<TOutput> onOpen, Func<TOutput> onClosed)
            => _state.Match(onOpen, onClosed);

        public TOutput Match<TInput, TOutput>(Func<TInput, TOutput> onOpen, Func<TInput, TOutput> onClosed, TInput input)
            => _state.Match(onOpen, onClosed, input);

        public bool TryMatch<TOutput>(TryHandler<TOutput> onOpen, TryHandler<TOutput> onClosed, out TOutput output)
            => _state.TryMatch(onOpen, onClosed, out output);

        public bool TryMatch<TInput, TOutput>(TryHandler<TInput, TOutput> onOpen, TryHandler<TInput, TOutput> onClosed, TInput input, out TOutput output)
            => _state.TryMatch(onOpen, onClosed, input, out output);
    }
}
