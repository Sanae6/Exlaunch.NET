using Internal.Runtime;

namespace System.Runtime.InteropServices; 

public static class Marshal {
    public static int SizeOf(Type type) {
        unsafe {
            return (int) type.TypeHandle.MethodTable->BaseSize;
        }
    }
    public static int SizeOf<T>() {
        return SizeOf(typeof(T));
    }

    public static IntPtr StringToHGlobalAnsi(string s) {
        unsafe {
            fixed (char* text = s)
                return (IntPtr) PInvokeMarshal.StringToAnsiString(text, s.Length, null, true, false, false);
        }
    }

    // public static Delegate GetDelegateFromFunctionPointer(IntPtr p) => 
    public static IntPtr GetFunctionPointerFromDelegate<T>(T t) where T : Delegate => t.m_functionPointer;
    public static IntPtr GetFunctionPointerFromDelegate(Delegate d) => d.m_functionPointer;
}
