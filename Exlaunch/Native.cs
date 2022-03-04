using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Exlaunch;

public class Native {
    [DllImport("*", EntryPoint = "envSetOwnProcessHandle")]
    public static extern void SetOwnProcessHandle(IntPtr ptr);

    [DllImport("*", EntryPoint = "_ZN3exl4util11proc_handle3GetEv")]
    public static extern IntPtr GetProcHandle();

    [DllImport("*", EntryPoint = "_ZN3exl4util4Hook10InitializeEv")]
    public static extern void HookInitialize();

    [DllImport("*", EntryPoint = "ExlaunchGetSymbol")]
    public static extern unsafe IntPtr GetSymbol(char* str);

    [DllImport("*", EntryPoint = "ExlaunchAbort")]
    public static extern void ExlaunchAbort(uint value);

    [DllImport("*", EntryPoint = "ExlaunchHook")]
    public static extern Delegate Hook(IntPtr hook, Delegate callback);
}