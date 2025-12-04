namespace Sharp
{
    public class Reference<TTarget> : Option<TTarget>
        where TTarget : class
    {
        public Reference() : base() { }

        public Reference(TTarget target) : base(target) { }

        public static implicit operator Reference<TTarget>(TTarget target)
            => new Reference<TTarget>(target);

        protected override bool Validate(TTarget target)
            => target is not null;
    }
}
