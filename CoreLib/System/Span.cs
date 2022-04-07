namespace System;

public ref struct Span<T> {
    public readonly ByReference<T> byref;
    public readonly int Length;
    public ref T GetPinnableReference() {
        return ref byref.Value;
    }
}