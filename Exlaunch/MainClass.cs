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

    private static SetPaneStringLengthDel SetPaneStringTrampoline;

    // [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public static void SetPaneStringLength(IntPtr ptr, byte* name, char* text, ushort unknown,
        ushort uselessLength) {
        const string newText = "Do you see that small vent on the floor?\nHave you heard of \"Among Us?\"";
        fixed (char* newPtr = newText)
            SetPaneStringTrampoline(ptr, name, newPtr, unknown, (ushort) newText.Length);
    }

    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Main() {
        bool initializedSocket = false;
        Func<IntPtr,ulong,ulong,int,int> socketInitTrampoline = null!;
        socketInitTrampoline = HookTrampoline("_ZN2nn6socket10InitializeEPvmmi", (IntPtr pool, ulong poolSize, ulong allocPoolSize, int concurLimit) => {
            if (initializedSocket) return 0;
            int result = socketInitTrampoline(pool, poolSize, allocPoolSize, concurLimit);
            InternalCalls.InitializeLogger();
            return result;
        });
        SetPaneStringTrampoline = HookTrampoline<SetPaneStringLengthDel>("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt", SetPaneStringLength);
    }

    public static T HookTrampoline<T>(string location, T callback) where T : Delegate {
        IntPtr trampoline = InternalCalls.Hook(InternalCalls.GetSymbol((byte*) Marshal.StringToHGlobalAnsi(location)), callback.m_functionPointer, true);
        callback.m_functionPointer = trampoline;
        return callback;
    }

    public static void Hook<T>(string sisterLocation, T callback) where T : Delegate
        => InternalCalls.Hook(InternalCalls.GetSymbol((byte*) Marshal.StringToHGlobalAnsi(sisterLocation)), callback.m_functionPointer, false);

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