using System;

namespace Sharp.Helpers
{
    public unsafe static partial class Pointer
    {
        public static void Insert(byte* destination, int length, int index, bool value)
        {
            if (length - index < sizeof(bool))
                throw new IndexOutOfRangeException();

            DangerousInsert(destination, index, value);
        }

        public static void DangerousInsert(byte* destination, int index, bool value)
            => *(bool*)(destination + index) = value;

        public static bool TryInsert(byte* destination, int length, int index, bool value)
        {
            if (length - index < sizeof(bool))
                return false;

            DangerousInsert(destination, index, value);

            return true;
        }

        public static bool ToBool(byte* source, int length, int index)
        {
            if (length - index < sizeof(bool))
                throw new IndexOutOfRangeException();

            return DangerousToBool(source, index);
        }

        public static bool DangerousToBool(byte* source, int index)
            => *(bool*)(source + index);

        public static bool TryToBool(byte* source, int length, int index, out bool value)
        {
            value = default;

            if (length - index < sizeof(bool))
                return false;

            value = DangerousToBool(source, index);

            return true;
        }
    }
}
