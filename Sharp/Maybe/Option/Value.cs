namespace Sharp
{
    public class Value<TTarget> : Option<TTarget>
        where TTarget : struct
    {
        public Value() : base() { }

        public Value(TTarget target) : base(target) { }

        public static implicit operator Value<TTarget>(TTarget target)
            => new Value<TTarget>(target);

        protected override bool Validate(TTarget target)
            => true;
    }
}
