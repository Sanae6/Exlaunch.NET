using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Native;

public class InternalCalls {
    [DllImport("*", EntryPoint = "envSetOwnProcessHandle")]
    public static extern void SetOwnProcessHandle(IntPtr ptr);

    [DllImport("*", EntryPoint = "_ZN3exl4util11proc_handle3GetEv")]
    public static extern IntPtr GetProcHandle();

    [DllImport("*", EntryPoint = "_ZN3exl4util4Hook10InitializeEv")]
    public static extern void HookInitialize();

    [DllImport("*", EntryPoint = "ExlaunchGetSymbol")]
    public static extern unsafe IntPtr GetSymbol(byte* str);

    [DllImport("*", EntryPoint = "ExlaunchHook")]
    public static extern IntPtr Hook(IntPtr hook, IntPtr callback);

    [DllImport("*", EntryPoint = "svcBreak")]
    public static extern void SvcBreak(int reason, ulong address = 0, ulong size = 0);
}