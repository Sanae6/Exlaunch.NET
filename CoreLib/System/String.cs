namespace System;

public sealed class String {
    public readonly int Length;
    public char FirstChar;

    public unsafe String(char* ptr) { }

    public char this[int index] {
        get {
            unsafe {
                if ((uint)index >= (uint)Length)
                    throw new IndexOutOfRangeException(nameof(index));
                fixed (char* c = &FirstChar) return *(c + index);
            }
        }
    }

    public ref readonly char GetPinnableReference() {
        return ref FirstChar;
    }
}