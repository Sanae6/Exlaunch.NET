using System;
using System.Runtime.InteropServices;

namespace Native; 

public static class Allocator {
    [DllImport("*", EntryPoint = "malloc")]
    private static extern unsafe void* NativeMalloc(nint size);
    public static unsafe T* Allocate<T>() where T : unmanaged
        => Allocate<T>(Marshal.SizeOf<T>());

    public static unsafe T* Allocate<T>(nint count) where T : unmanaged
        => (T*) NativeMalloc(count);
}