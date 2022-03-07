using Internal.Runtime;

namespace System;

public struct RuntimeTypeHandle {
    public unsafe MethodTable* MethodTable;

    public RuntimeTypeHandle(IntPtr ptr) {
        unsafe {
            MethodTable = (MethodTable*) ptr;
        }
    }
}