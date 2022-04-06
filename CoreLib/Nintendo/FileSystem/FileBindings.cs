using System.Runtime.InteropServices;

namespace Nintendo.Bindings;

public unsafe class FileBindings {
    [DllImport(EntryPoint = "_ZN2nn2fs8OpenFileEPNS0_10FileHandleEPKci", CharSet = CharSet.Ansi)]
    public static extern Result OpenFile(out uint fileHandle, string path, OpenMode mode);
    [DllImport(EntryPoint = "_ZN2nn2fs8ReadFileEPmNS0_10FileHandleElPvm")]
    public static extern Result WriteFile(uint fileHandle, long offset, byte* buffer, uint size);
    [DllImport(EntryPoint = "_ZN2nn2fs11MountSdCardEPKc")]
    public static extern Result MountSdCard(string mountName);
}