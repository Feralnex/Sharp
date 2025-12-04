using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Sharp.Extensions
{
    public static class IntPtrExtensions
    {
        private delegate object CastHandler(IntPtr ptr);

        private static readonly CastHandler _cast;

        static IntPtrExtensions()
        {
            DynamicMethod method = new DynamicMethod(nameof(_cast), typeof(object), [typeof(IntPtr)], true);
            ILGenerator generator = method.GetILGenerator();
            generator.Emit(OpCodes.Ldarg_0);
            generator.Emit(OpCodes.Ret);
            Delegate castHandler = method.CreateDelegate(typeof(CastHandler));

            _cast = Unsafe.As<CastHandler>(castHandler);
        }

        public static TType Cast<TType>(this IntPtr pointer)
            where TType : class
            => Unsafe.As<TType>(_cast(pointer));
    }
}
