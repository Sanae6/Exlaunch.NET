// ReSharper disable once CheckNamespace

using System;
using System.Runtime;
using System.Runtime.InteropServices;

[module: DefaultCharSet(CharSet.Unicode)]

namespace System {
    public class Object {
#pragma warning disable 169
        // The layout of object is a contract with the compiler.
        private IntPtr m_pMethodTable;
#pragma warning restore 169
    }

    public struct Nullable<T> where T : struct { }

    public ref struct Span<T> { }

    public struct Memory<T> { }

    public abstract class Array { }

    public abstract class MulticastDelegate : Delegate { }

    public struct RuntimeTypeHandle { }

    public struct RuntimeMethodHandle { }

    public struct RuntimeFieldHandle { }

    namespace Runtime.CompilerServices {
        public class RuntimeHelpers {
            public static unsafe int OffsetToStringData => sizeof(IntPtr) + sizeof(int);
        }

        public class CallConvCdecl { }

        public enum MethodCodeType {
            IL,
            Native,
            OPTIL,
            Runtime
        }

        [Flags]
        public enum MethodImplOptions {
            Unmanaged = 0x4,
            NoInlining = 0x8,
            ForwardRef = 0x10,
            Synchronized = 0x20,
            NoOptimization = 0x40,
            PreserveSig = 0x80,
            AggressiveInlining = 0x100,
            AggressiveOptimization = 0x200,
            InternalCall = 0x1000
        }

        [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
        public class MethodImplAttribute : Attribute {
            public MethodCodeType MethodCodeType;
            public MethodImplAttribute() { }

            public MethodImplAttribute(short options) {
                Value = (MethodImplOptions) options;
            }

            public MethodImplAttribute(MethodImplOptions options) {
                Value = options;
            }

            public MethodImplOptions Value { get; }
        }
    }

    namespace Runtime.InteropServices {
        public enum CallingConvention {
            Winapi = 1,
            Cdecl = 2,
            StdCall = 3,
            ThisCall = 4,
            FastCall = 5
        }

        [AttributeUsage(AttributeTargets.Method, Inherited = false)]
        public sealed class UnmanagedCallersOnlyAttribute : Attribute {
            public Type[]? CallConvs;
        }

        public class InteropHelpers { }
    }

    public class Array<T> : Array { }
}

namespace Internal.Runtime.CompilerHelpers {
    // A class that the compiler looks for that has helpers to initialize the
    // process. The compiler can gracefully handle the helpers not being present,
    // but the class itself being absent is unhandled. Let's add an empty class.
    public class StartupCodeHelpers { }

    public class InteropHelpers { }

    public class ThrowHelpers {
        // public static extern void _ZN3exl4diag9AbortImplERKNS0_8AbortCtxE(int errorId);

        public static void ThrowInvalidProgramException() { }
        public static void ThrowInvalidProgramExceptionWithArgument() { }
    }
}