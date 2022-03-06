using Internal.Runtime;

namespace System.Runtime.InteropServices; 

public static class Marshal {
    public static int SizeOf(Type type) {
        unsafe {
            return (int) type.TypeHandle._pEEType->BaseSize;
        }
    }
    public static int SizeOf<T>() where T : unmanaged {
        return SizeOf(typeof(T));
    }
}
