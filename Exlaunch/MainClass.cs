using System;
using System.Runtime;
using System.Runtime.InteropServices;

// dotnet publish /t:LinkNative /p:NativeLib=Static --sc -c Release -r linux-arm64
namespace Exlaunch {
    public class MainClass {
        private static extern void envSetOwnProcessHandle(IntPtr ptr);
        private static extern IntPtr _ZN3exl4util11proc_handle3GetEv();
        private static extern IntPtr _ZN3exl4util4Hook10InitializeEv();

        [RuntimeExport("exl_main")]
        public static unsafe void exl_main(void* x0, void* x1) {
            envSetOwnProcessHandle(_ZN3exl4util11proc_handle3GetEv());
        }
    }
}