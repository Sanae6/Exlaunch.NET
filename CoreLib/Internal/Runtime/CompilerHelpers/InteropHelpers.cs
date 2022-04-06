using System;
using Native;

namespace Internal.Runtime.CompilerHelpers;

public class InteropHelpers {
    public static IntPtr GetCurrentCalleeOpenStaticDelegateFunctionPointer() {
        return IntPtr.Zero;
    }

    public static T GetCurrentCalleeDelegate<T>() where T : class {
        return null!;
    }
    public static unsafe void CoTaskMemFree(void* p) => Allocator.Free(p);
    public static unsafe byte* StringToAnsiString(char* pManaged, int lenUnicode, byte* pNative,
        bool terminateWithNull,
        bool bestFit, bool throwOnUnmappableChar) {

        if (pNative == null) pNative = Allocator.Allocate<byte>(lenUnicode + 1);
        for (int i = 0; i < lenUnicode; i++)
            *pNative++ = pManaged[i] < 0x80
                ? (byte) pManaged[i]
                : (byte) '?';
        pNative[lenUnicode] = (byte) '\0';

        return pNative;
    }
}