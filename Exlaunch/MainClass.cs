using System;
using System.Runtime;

// dotnet publish --sc -c Release -r linux-arm64 -o ../exlaunch-cmake/libs/
namespace Exlaunch; 

public class MainClass {
    public unsafe delegate void SetPaneStringDel(IntPtr ptr, char* text, ushort length, ushort unknown);

    private static MainClass Instance = null!;
    private static int sussy = 0;

    public int FieldYooo = 69;
    public string Among = "Us";

    [RuntimeExport("exl_csmain")]
    public static void Main() {
        Native.SetOwnProcessHandle(Native.GetProcHandle());
        // Native.HookInitialize();

        sussy++;
        Instance = new MainClass {
            FieldYooo = 142104
        };
    }

    // SetPaneStringTrampoline = Hook<SetPaneStringDel>("_ZN2al19setPaneStringLengthEPNS_10IUseLayoutEPKcPKDstt", SetPaneStringLength)
    // Native.ExlaunchAbort(0x21242069);

    // public static unsafe void SetPaneStringLength(IntPtr ptr, char* text, ushort length, ushort unknown) {
    //     const string newText = "Among Us";
    //     fixed (char* newPtr = newText) {
    //         Instance.SetPaneStringTrampoline(ptr, newPtr, (ushort) newText.Length, unknown);
    //     }
    // }
    // public static unsafe T Hook<T>(string location, T callback) where T : Delegate {
    //     byte[] locationAscii = StrToUtf8(location);
    //     fixed (char* locationPtr = location) 
    //         return (T) Native.Hook(Native.GetSymbol(locationPtr), callback);
    // }
    //
    // public static unsafe byte[] StrToUtf8(string str) {
    //     byte[] bytes = new byte[str.Length];
    //     fixed (char* strPtr = str) for (int i = 0; i < str.Length; i++) {
    //         if (strPtr[i] > 0x80) throw new Exception("grr arf bark bark");
    //         bytes[i] = (byte) strPtr[i];
    //     }
    //
    //     return bytes;
    // }
}