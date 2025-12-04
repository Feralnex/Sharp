using System;

namespace Sharp.Extensions
{
    public static class BoolExtensions
    {
        public static byte[] ToBytes(this bool value)
            => BitConverter.GetBytes(value);
    }
}
