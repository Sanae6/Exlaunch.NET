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

    public static void SetPaneStringLength(IntPtr iUseLayout, byte* paneName, char* text, ushort unknown,
        ushort textLength) {
        // InternalCalls.SvcBreak(2430, (ulong) SetPaneStringTrampoline!.m_functionPointer);
        const string newText = "Do you see that small vent on the floor?\nHave you heard of \"Among Us?\"";
        fixed (char* newPtr = newText) {
            SetPaneStringTrampoline(iUseLayout, paneName, newPtr, unknown, (ushort) newText.Length);
        }
    }

    private static delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void> SetPaneStringTrampoline = null!;
    private static bool InitializedSocket;
    private static delegate* unmanaged[Cdecl]<IntPtr, ulong, ulong, int, int> SocketInitTrampoline;

    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Main() {
        SocketInitTrampoline = (delegate* unmanaged[Cdecl]<IntPtr, ulong, ulong, int, int>)
            HookTrampoline<Func<IntPtr, ulong, ulong, int, int>>("_ZN2nn6socket10InitializeEPvmmi",
                (pool, poolSize, allocPoolSize, concurLimit) => {
                    if (InitializedSocket) return 0;
                    InitializedSocket = true;
                    int result = SocketInitTrampoline(pool, poolSize, allocPoolSize, concurLimit);
                    InternalCalls.InitializeLogger();
                    InternalCalls.Log("Amongies");
                    return result;
                });
        SetPaneStringTrampoline = (delegate* unmanaged[Cdecl]<IntPtr, byte*, char*, ushort, ushort, void>)
            HookTrampoline<SetPaneStringLengthDel>("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt",
                SetPaneStringLength);
        // holder.SetPaneStringTrampoline = (delegate* unmanaged[Cdecl]<IntPtr, byte*, char*,ushort,ushort, void>) HookTrampolinePtr("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt", (IntPtr)(delegate* unmanaged[Cdecl]<IntPtr, byte*, char*,ushort,ushort, void>)&SetPaneStringLength);
    }

    public static IntPtr HookTrampoline<T>(string location, T callback) where T : Delegate {
        IntPtr trampoline;
        fixed (byte* sisterLocation = StrToUtf8(location)) {
            IntPtr symbol = InternalCalls.GetSymbol(sisterLocation);
            // InternalCalls.SvcBreak(134, (ulong) symbol);
            trampoline = InternalCalls.Hook(symbol, callback.m_functionPointer, true);
        }

        // callback.InitializeOpenStaticThunk(null!, trampoline, trampoline);
        return trampoline;
    }

    public static IntPtr HookTrampolinePtr(string location, IntPtr callback) {
        fixed (byte* sisterLocation = StrToUtf8(location))
            return InternalCalls.Hook(InternalCalls.GetSymbol(sisterLocation), callback, true);
    }

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