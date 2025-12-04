using System;

namespace Sharp
{
    public static partial class Settings
    {
        private interface ISettings
        {
            public Type Type { get; }
            public object Content { get; }
        }
    }
}
