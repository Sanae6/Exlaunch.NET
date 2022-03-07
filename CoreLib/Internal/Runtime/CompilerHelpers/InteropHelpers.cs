using System;

namespace Internal.Runtime.CompilerHelpers; 

public class InteropHelpers {
    public static IntPtr GetCurrentCalleeOpenStaticDelegateFunctionPointer() {
        return IntPtr.Zero;
    }

    public static T GetCurrentCalleeDelegate<T>() where T : class {
        return null!;
    }
}