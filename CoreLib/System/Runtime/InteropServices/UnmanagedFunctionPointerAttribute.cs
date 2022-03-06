namespace System.Runtime.InteropServices;

public class UnmanagedFunctionPointerAttribute : Attribute {
    public UnmanagedFunctionPointerAttribute(CallingConvention convention) {
        CallingConvention = convention;
    }

    public CharSet CharSet;
    public CallingConvention CallingConvention { get; }
}