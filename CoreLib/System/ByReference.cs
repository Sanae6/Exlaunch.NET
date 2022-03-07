using System.Runtime.CompilerServices;

namespace System; 

public readonly ref struct ByReference<T> {
    private readonly IntPtr _value;

    public ByReference(ref T value) {
        throw new NotImplementedException("You really should not be here.");
    }
    
    public ref T Value {
        [Intrinsic]
        get => throw new NotImplementedException("How.....");
    }
}