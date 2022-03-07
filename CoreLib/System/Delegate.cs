namespace System;

public abstract class Delegate {
    public object m_firstParameter;
    public object m_helperObject;
    public IntPtr m_functionPointer;
    public IntPtr m_extraFunctionPointerOrData;

    public Delegate() {
        
    }

    public Delegate(IntPtr functionPointer) {
        m_functionPointer = functionPointer;
    }

    protected void InitializeOpenStaticThunk(object firstParameter, IntPtr functionPointer,
        IntPtr functionPointerThunk) {
        m_firstParameter = firstParameter;
        m_functionPointer = functionPointer;
        m_extraFunctionPointerOrData = functionPointerThunk;
    }
    
    public void InitializeClosedInstance(object firstParameter, IntPtr functionPointer) {}
}