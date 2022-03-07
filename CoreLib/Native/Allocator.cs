using System;
using System.Runtime.InteropServices;

namespace Native; 

public static class Allocator {
    [DllImport("*", EntryPoint = "malloc")]
    private static extern unsafe void* NativeMalloc(nint size);
    [DllImport("*", EntryPoint = "malloc")]
    private static extern object NativeMallocObject(nint size);
    public static unsafe T* Allocate<T>() where T : unmanaged
        => Allocate<T>(sizeof(T));

    public static unsafe T AllocateObject<T>() {
        object objRaw = NativeMallocObject(Marshal.SizeOf<T>());
        return objRaw.CastToAnything<T>();
    }

    public static unsafe T* Allocate<T>(nint count) where T : unmanaged
        => (T*) NativeMalloc(count);
}