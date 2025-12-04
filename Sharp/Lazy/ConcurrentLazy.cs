using System;

namespace Sharp
{
    public class ConcurrentLazy<TValue> : Lazy<TValue>
    {
        public ConcurrentLazy(TValue value) : base(value) { }

        public ConcurrentLazy(Func<TValue> factory) : base(factory) { }

        protected override TValue OnClosed()
        {
            lock (Gate)
            {
                return base.OnClosed();
            }
        }
    }
}
