namespace System;

public abstract class Delegate {
    protected internal IntPtr ExtraFunctionPointerOrData;
    protected internal object FirstParameter = null!;
    protected internal IntPtr FunctionPointer;
    protected internal object HelperObject = null!;
    protected void InitializeOpenStaticThunk(object firstParameter, IntPtr functionPointer, IntPtr functionPointerThunk) { }
}