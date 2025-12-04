using System;

namespace Sharp
{
    public abstract partial class Maybe<TTarget>
    {
        protected class Zero : Maybe<TTarget>
        {
            public override bool HasSome => false;
            public override int Count => 0;

            public Zero() { }

            public override bool IfNone(Action none)
            {
                none();

                return true;
            }

            public override bool IfNone<TInput>(Action<TInput> none, TInput input)
            {
                none(input);

                return true;
            }

            public override bool IfNone<TOutput>(Func<TOutput> none, out TOutput output)
            {
                output = none();

                return true;
            }

            public override bool IfNone<TInput, TOutput>(Func<TInput, TOutput> none, TInput input, out TOutput output)
            {
                output = none(input);

                return true;
            }

            public override bool IfSome(Action some)
                => false;

            public override bool IfSome<TInput>(Action<TInput> some, TInput input)
                => false;

            public override bool IfSome(Action<TTarget> some)
                => false;

            public override bool IfSome<TInput>(Action<TTarget, TInput> some, TInput input)
                => false;

            public override bool IfSome<TOutput>(Func<TOutput> some, out TOutput output)
            {
                output = default!;

                return false;
            }

            public override bool IfSome<TInput, TOutput>(Func<TInput, TOutput> some, TInput input, out TOutput output)
            {
                output = default!;

                return false;
            }

            public override void Match(Action some, Action none)
                => none();

            public override void Match<TInput>(Action<TInput> some, Action<TInput> none, TInput input)
                => none(input);

            public override void Match(Action<TTarget> some, Action none)
                => none();

            public override void Match<TInput>(Action<TTarget, TInput> some, Action<TInput> none, TInput input)
                => none(input);

            public override TOutput Match<TOutput>(Func<TOutput> some, Func<TOutput> none)
                => none();

            public override TOutput Match<TInput, TOutput>(Func<TInput, TOutput> some, Func<TInput, TOutput> none, TInput input)
                => none(input);
        }
    }
}
