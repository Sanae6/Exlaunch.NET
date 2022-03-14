﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Native;

public unsafe class InternalCalls {
    [DllImport("*", EntryPoint = "tryInitSocket")]
    public static extern void InitializeLogger();
    [DllImport("*", EntryPoint = "ExlaunchLog")]
    private static extern IntPtr LogInternal(byte* str);
    [DllImport("*", EntryPoint = "ExlaunchGetSymbol")]
    public static extern IntPtr GetSymbol(byte* str);

    [DllImport("*", EntryPoint = "ExlaunchHook")]
    public static extern IntPtr Hook(IntPtr hook, IntPtr callback, bool trampoline);

    [DllImport("*", EntryPoint = "svcBreak")]
    public static extern void SvcBreak(int reason, ulong address = 0, ulong size = 0);
    public static byte[] StrToUtf8(string str) {
        byte[] bytes = new byte[str.Length];
        fixed (char* strPtr = str)
            for (int i = 0; i < str.Length; i++)
                bytes[i] = strPtr[i] < 0x80
                    ? (byte) strPtr[i]
                    : throw new Exception("grr arf bark bark");

        return bytes;
    }

    public static void Log(string text) {
        fixed (byte* data = StrToUtf8(text))
            LogInternal(data);
    }
}