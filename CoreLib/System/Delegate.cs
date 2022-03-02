namespace System;

public abstract class Delegate {
    protected internal IntPtr m_extraFunctionPointerOrData;
    protected internal object m_firstParameter;
    protected internal IntPtr m_functionPointer;
    protected internal object m_helperObject;
    protected void InitializeOpenStaticThunk(object firstParameter, IntPtr functionPointer, IntPtr functionPointerThunk) { }
}