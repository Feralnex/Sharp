using System;

namespace Sharp
{
    public class Lazy<TValue>
    {
        private TValue? _value;

        protected Gate Gate { get; private set; }
        protected Func<TValue>? Factory { get; private set; }

        public TValue Value
        {
            get => Gate.Match(OnOpen, OnClosed);
            protected set => _value = value;
        }

        public Lazy(TValue value)
        {
            Gate = new Gate(Gate.State.Open);
            _value = value;
            Factory = OnOpen;
        }

        public Lazy(Func<TValue> factory)
        {
            Gate = new Gate();
            _value = default;
            Factory = factory;
        }

        protected TValue OnOpen()
            => _value!;

        protected virtual TValue OnClosed()
        {
            Gate.Open();
            _value = Factory!();

            return _value!;
        }
    }
}
