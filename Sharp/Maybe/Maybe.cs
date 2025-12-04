using System;

namespace Sharp
{
    public abstract partial class Maybe<TTarget>
    {
        public static Maybe<TTarget> None { get; }
        public static Maybe<TTarget> Some(TTarget target)
            => target is null
                ? None
                : new Single(target);

        public abstract bool HasSome { get; }
        public abstract int Count { get; }

        protected Maybe() { }

        static Maybe()
            => None = new Zero();

        public abstract bool IfNone(Action none);

        public abstract bool IfNone<TInput>(Action<TInput> none, TInput input);

        public abstract bool IfNone<TOutput>(Func<TOutput> none, out TOutput output);

        public abstract bool IfNone<TInput, TOutput>(Func<TInput, TOutput> none, TInput input, out TOutput output);

        public abstract bool IfSome(Action some);

        public abstract bool IfSome<TInput>(Action<TInput> some, TInput input);

        public abstract bool IfSome(Action<TTarget> some);

        public abstract bool IfSome<TInput>(Action<TTarget, TInput> some, TInput input);

        public abstract bool IfSome<TOutput>(Func<TOutput> some, out TOutput output);

        public abstract bool IfSome<TInput, TOutput>(Func<TInput, TOutput> some, TInput input, out TOutput output);

        public abstract void Match(Action some, Action none);

        public abstract void Match<TInput>(Action<TInput> some, Action<TInput> none, TInput input);

        public abstract void Match(Action<TTarget> some, Action none);

        public abstract void Match<TInput>(Action<TTarget, TInput> some, Action<TInput> none, TInput input);

        public abstract TOutput Match<TOutput>(Func<TOutput> some, Func<TOutput> none);

        public abstract TOutput Match<TInput, TOutput>(Func<TInput, TOutput> some, Func<TInput, TOutput> none, TInput input);
    }
}
