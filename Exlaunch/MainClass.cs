using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Native;

namespace Exlaunch;

public static unsafe class MainClass {
    // [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SetPaneStringLengthDel(IntPtr iUseLayout, byte* paneName, char* text, ushort unknown,
        ushort textLength);

    private static delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void> setPaneStringTrampoline =
        null!;

    private static bool initializedSocket;
    private static delegate* unmanaged[Cdecl]<IntPtr, ulong, ulong, int, int> socketInitTrampoline;

    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Main() {
        InternalCalls.Log("Balls");
    }

    public static void SetPaneStringLength(IntPtr iUseLayout, byte* paneName, char* text, ushort unknown,
        ushort textLength) {
        const string newText = "Do you see that small vent on the floor?\nHave you heard of \"Among Us?\"";
        fixed (char* newPtr = newText) {
            setPaneStringTrampoline(iUseLayout, paneName, newPtr, unknown, (ushort) newText.Length);
        }
    }

    public static byte[] StrToUtf8(string str) {
        byte[] bytes = new byte[str.Length];
        fixed (char* strPtr = str)
            for (int i = 0; i < str.Length; i++)
                bytes[i] = strPtr[i] < 0x80
                    ? (byte) strPtr[i]
                    : throw new Exception("grr arf bark bark");

        return bytes;
    }
}