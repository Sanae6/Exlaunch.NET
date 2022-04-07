namespace System;

public sealed class String {
    public readonly int Length;
    public char FirstChar;

    public unsafe String(char* ptr) {
        
    }

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

    public int IndexOf(char c, int startIndex) {
        for (int i = startIndex; i < Length; i++) {
            if (this[i] == c) return i;
        }
        return -1;
    }

    public static string Format(string format, object? arg0) {
        for (int i = 0; i < format.Length; i++) {
            if (format[i] == '{') {
                int start = i;
                while (format[i++] != '}') {
                    if (i == format.Length) throw new IndexOutOfRangeException("Range not closed,,,");
                }
                // int.TryParse()
            }
        }
        return format;
    }
    public static string Format(string format, params object?[] args) {
        return format;
    }
}