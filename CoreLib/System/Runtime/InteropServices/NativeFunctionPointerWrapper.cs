namespace System.Runtime.InteropServices;

public abstract class NativeFunctionPointerWrapper {
    public NativeFunctionPointerWrapper(IntPtr nativeFunctionPointer) {
        m_nativeFunctionPointer = nativeFunctionPointer;
    }

    IntPtr m_nativeFunctionPointer;

    public IntPtr NativeFunctionPointer => m_nativeFunctionPointer;
}