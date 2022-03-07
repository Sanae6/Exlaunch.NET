using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Native;

public unsafe class InternalCalls {
    [DllImport("*", EntryPoint = "tryInitSocket")]
    public static extern void InitializeLogger();
    [DllImport("*", EntryPoint = "ExlaunchGetSymbol")]
    public static extern IntPtr GetSymbol(byte* str);

    [DllImport("*", EntryPoint = "ExlaunchHook")]
    public static extern IntPtr Hook(IntPtr hook, IntPtr callback, bool trampoline);

    [DllImport("*", EntryPoint = "svcBreak")]
    public static extern void SvcBreak(int reason, ulong address = 0, ulong size = 0);
}