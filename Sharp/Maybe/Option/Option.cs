using System;

namespace Sharp
{
    public abstract class Option<TTarget> : Maybe<TTarget>
    {
        private Single _some;
        private Maybe<TTarget> _current;

        public override bool HasSome => _current.HasSome;
        public override int Count => _current.Count;
        public TTarget? Target => _some.Target;

        public Option()
        {
            _some = new Single();
            _current = None;
        }

        public Option(TTarget target) : this()
        {
            bool isValid = Validate(target);

            if (isValid)
            {
                _some.Target = target;
                _current = _some;
            }
        }

        public bool TryGet(out TTarget? target)
        {
            target = _some.Target;

            return _current.HasSome;
        }

        public void Clear()
        {
            _some.Target = default;
            _current.IfSome(OnSomeClear);
        }

        public void Set(TTarget target)
        {
            bool isValid = Validate(target);

            if (isValid)
            {
                _some.Target = target;
                _current = _some;
            }
            else
                Clear();
        }

        public bool TrySet(TTarget target)
        {
            bool isValid = Validate(target);

            if (isValid)
            {
                _some.Target = target;
                _current = _some;
            }
            else
                Clear();

            return isValid;
        }

        public override bool IfNone(Action none)
            => _current.IfNone(none); 

        public override bool IfNone<TInput>(Action<TInput> none, TInput input)
            => _current.IfNone(none, input);

        public override bool IfNone<TOutput>(Func<TOutput> none, out TOutput output)
            => _current.IfNone(none, out output);

        public override bool IfNone<TInput, TOutput>(Func<TInput, TOutput> none, TInput input, out TOutput output)
            => _current.IfNone(none, input, out output);

        public override bool IfSome(Action some)
            => _current.IfSome(some);

        public override bool IfSome<TInput>(Action<TInput> some, TInput input)
            => _current.IfSome(some, input);

        public override bool IfSome(Action<TTarget> some)
            => _current.IfSome(some);

        public override bool IfSome<TInput>(Action<TTarget, TInput> some, TInput input)
            => _current.IfSome(some, input);

        public override bool IfSome<TOutput>(Func<TOutput> some, out TOutput output)
            => _current.IfSome(some, out output);

        public override bool IfSome<TInput, TOutput>(Func<TInput, TOutput> some, TInput input, out TOutput output)
            => _current.IfSome(some, input, out output);

        public override void Match(Action some, Action none)
            => _current.Match(some, none);

        public override void Match<TInput>(Action<TInput> some, Action<TInput> none, TInput input)
            => _current.Match(some, none, input);

        public override void Match(Action<TTarget> some, Action none)
            => _current.Match(some, none);

        public override void Match<TInput>(Action<TTarget, TInput> some, Action<TInput> none, TInput input)
            => _current.Match(some, none, input);

        public override TOutput Match<TOutput>(Func<TOutput> some, Func<TOutput> none)
            => _current.Match(some, none);

        public override TOutput Match<TInput, TOutput>(Func<TInput, TOutput> some, Func<TInput, TOutput> none, TInput input)
            => _current.Match(some, none, input);

        protected abstract bool Validate(TTarget target);

        private void OnSomeClear()
            => _current = None;
    }
}
