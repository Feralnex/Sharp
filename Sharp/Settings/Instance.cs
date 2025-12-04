using Microsoft.Extensions.Options;
using System;

namespace Sharp
{
    public static partial class Settings
    {
        private class Instance<TSettings> : ISettings
            where TSettings : class
        {
            public Type Type { get; }
            public object Content { get; }

            public Instance(IOptions<TSettings> options)
            {
                Type = typeof(TSettings);
                Content = options.Value;
            }
        }
    }
}
