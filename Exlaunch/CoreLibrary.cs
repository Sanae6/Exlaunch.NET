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
        Assembly = 1,
        Module = 2,
        Class = 4,
        Struct = 8,
        Enum = 16,
        Constructor = 32,
        Method = 64,
        Property = 128,
        Field = 256,
        Event = 512,
        Interface = 1024,
        Parameter = 2048,
        ReturnValue = 8192,
        Delegate = 4096,
        GenericParameter = 16384,
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
    }

    namespace Runtime.InteropServices {
        public sealed class DllImportAttribute : Attribute {
            public DllImportAttribute(string dllName) { }
        }
    }

    namespace Runtime {
        internal sealed class RuntimeExportAttribute : Attribute {
            public RuntimeExportAttribute(string entry) { }
        }
    }

    class Array<T> : Array { }
}

namespace Internal.Runtime.CompilerHelpers {
    // A class that the compiler looks for that has helpers to initialize the
    // process. The compiler can gracefully handle the helpers not being present,
    // but the class itself being absent is unhandled. Let's add an empty class.
    class StartupCodeHelpers {
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
        public static extern void _ZN3exl4diag9AbortImplERKNS0_8AbortCtxE(int errorId);

        public static void ThrowInvalidProgramException() { }
        public static void ThrowInvalidProgramExceptionWithArgument() { }
    }
}