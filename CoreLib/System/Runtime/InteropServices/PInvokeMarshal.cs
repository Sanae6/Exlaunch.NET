using Native;

namespace System.Runtime.InteropServices;

public class PInvokeMarshal {
    public static unsafe byte* StringToAnsiString(char* pManaged, int length, byte* pNative, bool terminateWithNull,
        bool bestFit, bool throwOnUnmappableChar) {
        if (pNative == null) {
            pNative = Allocator.Allocate<byte>(checked(length + 1));
            if (pNative == null) {
                InternalCalls.SvcBreak(0x1234, 0xBEEF);
            }
        }

        byte* pDst = pNative;
        char* pSrc = pManaged;

        while (length > 0) {
            unchecked {
                if (*pSrc > byte.MaxValue) {
                    if (throwOnUnmappableChar)
                        throw new InvalidOperationException("String contains non-ANSI characters");
                    *pDst++ = (byte) '?';
                }
                else *pDst++ = (byte) *pSrc++;
                length--;
            }
        }

        // Zero terminate
        if (terminateWithNull)
            *(pNative + length) = 0;

        return pNative;
    }
}