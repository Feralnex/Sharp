using System.Runtime.InteropServices;

namespace Sharp.Extensions
{
    public static class ArchitectureExtensions
    {
        public static Gate IsProcess64Bit { get; }

        static ArchitectureExtensions()
        {
            IsProcess64Bit = new Gate();

            if (RuntimeInformation.ProcessArchitecture.Is64Bit())
                IsProcess64Bit.Open();
        }

        public static bool Is64Bit(this Architecture architecture)
        {
            switch (architecture)
            {
                case Architecture.X64:
                case Architecture.Arm64:
                case Architecture.S390x:
                case Architecture.LoongArch64:
                case Architecture.Ppc64le:
                    return true;
                default:
                    return false;
            }
        }
    }
}
