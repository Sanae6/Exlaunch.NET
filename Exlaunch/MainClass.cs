using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Native;

namespace Exlaunch;

public static class MainClass {
    private static unsafe delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void> SetPaneStringTrampoline;

    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static unsafe void Main() {
        InternalCalls.SetOwnProcessHandle(InternalCalls.GetProcHandle());
        InternalCalls.HookInitialize();
        
        // call InternalCalls.SvcBreak to cause a crash report

        SetPaneStringTrampoline = (delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void>)
            Hook("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt", 
                new IntPtr((delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void>) &SetPaneStringLength));
    }
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static unsafe void SetPaneStringLength(IntPtr ptr, byte* name, char* text, ushort unknown, ushort _uselessLength) {
        const string newText = "Do you see that small vent on the floor?\nHave you heard of \"Among Us?\"";
        fixed (char* newPtr = newText)
            SetPaneStringTrampoline(ptr, name, newPtr, unknown, (ushort) newText.Length);
    }

    public static unsafe IntPtr Hook(string location, IntPtr callback) {
        byte[] locationAscii = StrToUtf8(location);
        fixed (byte* locationPtr = locationAscii)
            return InternalCalls.Hook(InternalCalls.GetSymbol(locationPtr), callback);
    }

    public static unsafe byte[] StrToUtf8(string str) {
        byte[] bytes = new byte[str.Length];
        fixed (char* strPtr = str)
            for (int i = 0; i < str.Length; i++)
                bytes[i] = strPtr[i] < 0x80
                    ? (byte) strPtr[i]
                    : throw new Exception("grr arf bark bark");

        return bytes;
    }
}