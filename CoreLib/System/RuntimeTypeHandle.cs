using Internal.Runtime;

namespace System;

public struct RuntimeTypeHandle {
    public unsafe MethodTable* _pEEType;
}