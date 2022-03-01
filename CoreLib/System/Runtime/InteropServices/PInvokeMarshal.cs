namespace System.Runtime.InteropServices; 

public class PInvokeMarshal {
    public static unsafe byte* StringToAnsiString(char* pManaged, int lenUnicode, byte* pNative, bool terminateWithNull,
        bool bestFit, bool throwOnUnmappableChar) {
        // bool allAscii = true;

        // int length;

        // if (allAscii) // If all ASCII, map one UNICODE character to one ANSI char
        // {
        //     length = lenUnicode;
        // } else // otherwise, let OS count number of ANSI chars
        // {
        //     length = GetByteCount(pManaged, lenUnicode);
        // }
        //
        // if (pNative == null) {
        //     pNative = (byte*) Marshal.AllocCoTaskMem(checked(length + 1));
        // }
        //
        // if (allAscii) // ASCII conversion
        // {
        //     byte* pDst = pNative;
        //     char* pSrc = pManaged;
        //
        //     while (lenUnicode > 0) {
        //         unchecked {
        //             if (*pSrc < 128) {
        //                 *pDst++ = (byte) (*pSrc++);
        //                 lenUnicode--;
        //             }
        //         }
        //     }
        // }

        // Zero terminate
        // if (terminateWithNull)
        //     *(pNative + length) = 0;

        return (byte*) pManaged;
    }
}