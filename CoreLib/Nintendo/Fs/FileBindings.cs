using System.Runtime.InteropServices;
using Native;

namespace Nintendo.Fs;

public unsafe class FileBindings {
    [DllImport(EntryPoint = "_ZN2nn2fs12GetEntryTypeEPNS0_18DirectoryEntryTypeEPKc")]
    public static extern Result GetEntryType(out bool isFile, byte* path);
    [DllImport(EntryPoint = "_ZN2nn2fs10CreateFileEPKcl")]
    public static extern Result CreateFile(void* fileHandle, long size);
    [DllImport(EntryPoint = "_ZN2nn2fs11SetFileSizeENS0_10FileHandleEl")]
    public static extern Result SetFileSize(void* fileHandle, long size);
    [DllImport(EntryPoint = "_ZN2nn2fs11GetFileSizeEPlNS0_10FileHandleE")]
    public static extern Result GetFileSize(out long size, void* fileHandle);
    [DllImport(EntryPoint = "_ZN2nn2fs8OpenFileEPNS0_10FileHandleEPKci", CharSet = CharSet.Ansi)]
    public static extern Result OpenFile(out void* fileHandle, byte* path, OpenMode mode);
    [DllImport(EntryPoint = "_ZN2nn2fs9WriteFileENS0_10FileHandleElPKvmRKNS0_11WriteOptionE")]
    public static extern Result WriteFile(void* fileHandle, long offset, void* buffer, ulong size, in int writeFlags = 1);
    [DllImport(EntryPoint = "_ZN2nn2fs9CloseFileENS0_10FileHandleE")]
    public static extern Result CloseFile(void* fileHandle);
    [DllImport(EntryPoint = "_ZN2nn2fs11MountSdCardEPKc")]
    private static extern Result MountSdCard(byte* mountName);
    public static Result MountSdCard(string mountName) {
        fixed (byte* str = InternalCalls.StrToAnsi(mountName)) return MountSdCard(str);
    }
}