using System;

namespace Sharp
{
    public abstract partial class Maybe<TTarget>
    {
        protected class Single : Maybe<TTarget>
        {
            private TTarget? _target;

            public TTarget? Target
            {
                get => _target;
                set => _target = value;
            }
            public override bool HasSome => true;
            public override int Count => 1;

            public Single()
                => _target = default;

            public Single(TTarget target)
                => _target = target;

            public override bool IfNone(Action none)
                => false;

            public override bool IfNone<TInput>(Action<TInput> none, TInput input)
                => false;

            public override bool IfNone<TOutput>(Func<TOutput> none, out TOutput output)
            {
                output = default!;

                return false; 
            }

            public override bool IfNone<TInput, TOutput>(Func<TInput, TOutput> none, TInput input, out TOutput output)
            {
                output = default!;

                return false;
            }

            public override bool IfSome(Action some)
            {
                some();

                return true;
            }

            public override bool IfSome<TInput>(Action<TInput> some, TInput input)
            {
                some(input);

                return true;
            }

            public override bool IfSome(Action<TTarget> some)
            {
                some(Target!);

                return true;
            }

            public override bool IfSome<TInput>(Action<TTarget, TInput> some, TInput input)
            {
                some(Target!, input);

                return true;
            }

            public override bool IfSome<TOutput>(Func<TOutput> some, out TOutput output)
            {
                output = some();

                return true;
            }

            public override bool IfSome<TInput, TOutput>(Func<TInput, TOutput> some, TInput input, out TOutput output)
            {
                output = some(input);

                return true;
            }

            public override void Match(Action some, Action none)
                 => some();

            public override void Match<TInput>(Action<TInput> some, Action<TInput> none, TInput input)
                => some(input);

            public override void Match(Action<TTarget> some, Action none)
                => some(Target!);

            public override void Match<TInput>(Action<TTarget, TInput> some, Action<TInput> none, TInput input)
                => some(Target!, input);

            public override TOutput Match<TOutput>(Func<TOutput> some, Func<TOutput> none)
                => some();

            public override TOutput Match<TInput, TOutput>(Func<TInput, TOutput> some, Func<TInput, TOutput> none, TInput input)
                => some(input);
        }
    }
}
