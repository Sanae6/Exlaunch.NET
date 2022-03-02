namespace System;

public sealed class String {
    public readonly int Length;

    public unsafe String(char* ptr) { }

    public char this[int index] => 'C';
}