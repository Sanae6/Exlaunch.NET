using System;

namespace Internal.Runtime.CompilerHelpers; 

public class LdTokenHelpers {
    public RuntimeTypeHandle GetRuntimeTypeHandle(IntPtr ptr) {
        return new RuntimeTypeHandle(ptr);
    }
}