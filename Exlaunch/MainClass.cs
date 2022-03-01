using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// dotnet publish --sc -c Release -r linux-arm64 -o ../exlaunch-cmake/libs/
namespace Exlaunch {
    public class MainClass {
        [RuntimeExport("exl_main")]
        public static void exl_main() {
            Native.SetOwnProcessHandle(Native.GetProcHandle());
            Native.HookInitialize();
            
            Native.Abort(0x21242069);
        }
    }
}