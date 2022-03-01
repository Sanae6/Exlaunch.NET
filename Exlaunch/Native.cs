using System;
using System.Runtime.InteropServices;

namespace Exlaunch;

public class Native {
    // ReSharper disable InconsistentNaming
    [DllImport("*", EntryPoint = "envSetOwnProcessHandle")]
    public static extern void SetOwnProcessHandle(IntPtr ptr);
    [DllImport("*", EntryPoint = "_ZN3exl4util11proc_handle3GetEv")]
    public static extern IntPtr GetProcHandle();
    [DllImport("*", EntryPoint = "_ZN3exl4util4Hook10InitializeEv")]
    public static extern void HookInitialize();
    [DllImport("*", EntryPoint = "ExlaunchAbort")]
    public static extern void Abort(uint value);
    // ReSharper restore InconsistentNaming
}