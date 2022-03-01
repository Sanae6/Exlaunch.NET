// ReSharper disable once CheckNamespace

using System;
using System.Runtime;

namespace System {
    public class Object {
#pragma warning disable 169
        // The layout of object is a contract with the compiler.
        private IntPtr m_pMethodTable;
#pragma warning restore 169
    }

    public struct Void { }

    public struct Boolean { }

    public struct Char { }

    public struct SByte { }

    public struct Byte { }

    public struct Int16 { }

    public struct UInt16 { }

    public struct Int32 { }

    public struct UInt32 { }

    public struct Int64 { }

    public struct UInt64 { }

    public struct IntPtr { }

    public struct UIntPtr { }

    public struct Single { }

    public struct Double { }

    public abstract class ValueType { }

    public abstract class Enum : ValueType { }

    public struct Nullable<T> where T : struct { }

    public sealed class String {
        public readonly int Length;
    }

    public abstract class Array { }

    public abstract class Delegate { }

    public abstract class MulticastDelegate : Delegate { }

    public struct RuntimeTypeHandle { }

    public struct RuntimeMethodHandle { }

    public struct RuntimeFieldHandle { }

    public class Attribute { }

    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    public class FlagsAttribute : Attribute { }

    [Flags]
    public enum AttributeTargets {
        Assembly = 0x1,
        Module = 0x2,
        Class = 0x4,
        Struct = 0x8,
        Enum = 0x10,
        Constructor = 0x20,
        Method = 0x40,
        Property = 0x80,
        Field = 0x100,
        Event = 0x200,
        Interface = 0x400,
        Parameter = 0x800,
        ReturnValue = 0x2000,
        Delegate = 0x1000,
        GenericParameter = 0x4000,
        All = Assembly | Module | Class | Struct | Enum | Constructor | Method | Property | Field | Event | Interface | Parameter | ReturnValue | Delegate | GenericParameter,
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class AttributeUsageAttribute : Attribute {
        public bool AllowMultiple { get; set; } = false;
        public bool Inherited { get; set; } = true;
        public AttributeUsageAttribute(AttributeTargets targets) { }
    }

    namespace Runtime.CompilerServices {
        public class RuntimeHelpers {
            public static unsafe int OffsetToStringData => sizeof(IntPtr) + sizeof(int);
        }

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
            public MethodImplOptions Value { get; }
            public MethodImplAttribute() { }

            public MethodImplAttribute(short options) {
                Value = (MethodImplOptions) options;
            }

            public MethodImplAttribute(MethodImplOptions options) {
                Value = options;
            }
        }
    }

    namespace Runtime.InteropServices {
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class DllImportAttribute : Attribute {
            public string? EntryPoint;
            public DllImportAttribute(string dllName) { }
        }

        public class InteropHelpers {
            
        }
    }

    namespace Runtime {
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class RuntimeExportAttribute : Attribute {
            public RuntimeExportAttribute(string entry) { }
        }
    }

    public class Array<T> : Array { }
}

namespace Internal.Runtime.CompilerHelpers {
    // A class that the compiler looks for that has helpers to initialize the
    // process. The compiler can gracefully handle the helpers not being present,
    // but the class itself being absent is unhandled. Let's add an empty class.
    public class StartupCodeHelpers {
        // A couple symbols the generated code will need we park them in this class
        // for no particular reason. These aid in transitioning to/from managed code.
        // Since we don't have a GC, the transition is a no-op.
        [RuntimeExport("RhpReversePInvoke")]
        static void RhpReversePInvoke(IntPtr frame) { }

        [RuntimeExport("RhpReversePInvokeReturn")]
        static void RhpReversePInvokeReturn(IntPtr frame) { }

        [RuntimeExport("RhpPInvoke")]
        static void RhpPInvoke(IntPtr frame) { }

        [RuntimeExport("RhpPInvokeReturn")]
        static void RhpPInvokeReturn(IntPtr frame) { }

        [RuntimeExport("RhpFallbackFailFast")]
        static void RhpFallbackFailFast() {
            while (true) ;
        }
    }

    public class ThrowHelpers {
        // public static extern void _ZN3exl4diag9AbortImplERKNS0_8AbortCtxE(int errorId);

        public static void ThrowInvalidProgramException() { }
        public static void ThrowInvalidProgramExceptionWithArgument() { }
    }
}