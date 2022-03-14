namespace System;

public abstract class Delegate {
    public object m_firstParameter;

    public object m_helperObject;

    // This is not the thunk. It likes to pretend it's useful.
    public IntPtr m_functionPointer = IntPtr.Zero;

    // This is the thunk. It likes to be a thunk. It is useful.
    public IntPtr m_extraFunctionPointerOrData = IntPtr.Zero;

    public Delegate() { }

    protected Delegate(IntPtr functionPointer) {
        m_functionPointer = functionPointer;
    }

    public void InitializeOpenStaticThunk(object firstParameter, IntPtr functionPointer,
        IntPtr functionPointerThunk) {
        m_firstParameter = firstParameter;
        m_functionPointer = functionPointer;
        m_extraFunctionPointerOrData = functionPointer;
    }

    public void InitializeClosedInstance(object firstParameter, IntPtr functionPointer) {
        m_firstParameter = firstParameter;
        m_functionPointer = functionPointer;
    }
}