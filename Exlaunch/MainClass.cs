using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Native;

namespace Exlaunch;

public static unsafe class MainClass {
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void SetPaneStringLengthDel(IntPtr iUseLayout, byte* paneName, char* text, ushort unknown,
        ushort textLength);


    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void SetPaneStringLength(IntPtr iUseLayout, byte* paneName, char* text, ushort unknown,
        ushort textLength) {
        // InternalCalls.SvcBreak(2430, (ulong) SetPaneStringTrampoline!.m_functionPointer);
        const string newText = "Do you see that small vent on the floor?\nHave you heard of \"Among Us?\"";
        fixed (char* newPtr = newText)
            SetPaneStringTrampoline(iUseLayout, paneName, newPtr, unknown, (ushort) newText.Length);
    }

    private static SetPaneStringLengthDel? SetPaneStringTrampoline = null;
    // private static delegate* unmanaged[Cdecl]<IntPtr, byte*, char*,ushort,ushort, void> SetPaneStringTrampoline = null;
    private static bool InitializedSocket;
    private static Func<IntPtr, ulong, ulong, int, int> SocketInitTrampoline = null!;

    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Main() {
        // return;
        // SocketInitTrampoline = HookTrampoline("_ZN2nn6socket10InitializeEPvmmi", (IntPtr pool, ulong poolSize, ulong allocPoolSize, int concurLimit) => {
        //     if (InitializedSocket) return 0;
        //     InitializedSocket = true;
        //     int result = SocketInitTrampoline(pool, poolSize, allocPoolSize, concurLimit);
        //     InternalCalls.InitializeLogger();
        //     return result;
        // });
        SetPaneStringTrampoline = HookTrampoline<SetPaneStringLengthDel>("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt", );
        // SetPaneStringTrampoline = (delegate* unmanaged[Cdecl]<IntPtr, byte*, char*,ushort,ushort, void>) HookTrampolinePtr("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt", (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, byte*, char*,ushort,ushort, void>)&SetPaneStringLength);
    }

    public static T HookTrampoline<T>(string location, T callback) where T : Delegate {
        IntPtr trampoline;
        fixed (byte* sisterLocation = StrToUtf8(location))
            trampoline = InternalCalls.Hook(InternalCalls.GetSymbol(sisterLocation),
                callback.m_functionPointer, true);
        callback.InitializeOpenStaticThunk(null!, trampoline, trampoline);
        return callback;
    }

    // public static IntPtr HookTrampolinePtr(string location, IntPtr callback) {
    //     fixed (byte* sisterLocation = StrToUtf8(location))
    //         return InternalCalls.Hook(InternalCalls.GetSymbol(sisterLocation), callback);
    // }

    // public static void Hook<T>(string sisterLocation, T callback) where T : Delegate
    //     => InternalCalls.Hook(InternalCalls.GetSymbol((byte*) Marshal.StringToHGlobalAnsi(sisterLocation)), callback.m_functionPointer, false);

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