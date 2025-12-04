using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sharp
{
    public static partial class Settings
    {
        private static Dictionary<Type, object> _cache;

        static Settings()
        {
            _cache = new Dictionary<Type, object>();
            _gate = new Gate();

            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        public static bool TryAdd<TSettings>(TSettings settings)
            where TSettings : notnull
        {
            return _cache.TryAdd(typeof(TSettings), settings);
        }

        public static bool TryRemove<TSettings>()
            => _cache.Remove(typeof(TSettings));

        public static bool Contains<TSettings>()
            => _cache.ContainsKey(typeof(TSettings));

        public static bool TryGet<TSettings>(out TSettings? settings)
            where TSettings : class
        {
            if (_cache.TryGetValue(typeof(TSettings), out object? value) && value is TSettings castedValue)
            {
                settings = castedValue;

                return true;
            }

            settings = default;

            return false;
        }

        public static bool DangerousTryGet<TSettings>(out TSettings? settings)
            where TSettings : class
        {
            if (_cache.TryGetValue(typeof(TSettings), out object? value))
            {
                settings = Unsafe.As<TSettings>(value);

                return true;
            }

            settings = default;

            return false;
        }

        public static void Clear()
            => _cache.Clear();

        private static bool TryAdd(ISettings settings)
            => _cache.TryAdd(settings.Type, settings.Content);

        private static void OnProcessExit(object? sender, EventArgs eventArgs)
        {
            AppDomain.CurrentDomain.ProcessExit -= OnProcessExit;

            _cache.Clear();
        }
    }
}
