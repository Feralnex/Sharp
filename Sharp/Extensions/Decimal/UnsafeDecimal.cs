using System.Runtime.InteropServices;

namespace Sharp.Extensions
{
    public static partial class DecimalExtensions
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct UnsafeDecimal
        {
            private int _flags;
            private uint _hi32;
            private ulong _lo64;

            public int Flags
            {
                get => _flags;
                set => _flags = value;
            }
            public uint Hi32
            {
                get => _hi32;
                set => _hi32 = value;
            }
            public ulong Lo64
            {
                get => _lo64;
                set => _lo64 = value;
            }
        }
    }
}
