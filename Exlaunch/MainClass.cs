using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Native;
using Nintendo.Bindings;

namespace Exlaunch;

public static unsafe class MainClass {

    private static delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void> setPaneStringTrampoline =
        null!;
    private static FileHandle file;

    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Main() {
        FileBindings.MountSdCard("sd");
        file = new FileHandle("sd:/writtenwithlove.txt");
        file.Write("hey besties\n");
    }

    public static void SetPaneStringLength(IntPtr iUseLayout, byte* paneName, char* text, ushort unknown,
        ushort textLength) {
        
        file.Write(new string(text));
        file.Write("\n");
        const string newText = "Do you see that small vent on the floor?\nHave you heard of \"Among Us?\"";
        fixed (char* newPtr = newText) {
            setPaneStringTrampoline(iUseLayout, paneName, newPtr, unknown, (ushort) newText.Length);
        }
    }
}