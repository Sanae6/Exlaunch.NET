using System;
using Native;

namespace Nintendo.Bindings; 

public struct FileHandle : IDisposable {
    public unsafe void* Handle;
    public long Position;
    public long CachedSize;
    public FileHandle(string fileName, OpenMode openMode = OpenMode.Read | OpenMode.Write | OpenMode.Append) {
        Position = 0;
        CachedSize = 0;
        unsafe {
            Result res;
            fixed (byte* sisterLocation = InternalCalls.StrToAnsi(fileName)) {
                res = FileBindings.GetEntryType(out bool isFile, sisterLocation);
                if (res.Value == 0x202) {
                    res = FileBindings.CreateFile(sisterLocation, 0);
                    if (res.Failure)
                        InternalCalls.SvcBreak(res.Value);
                }
                res = FileBindings.OpenFile(out Handle, sisterLocation, openMode);
                if (res.Failure)
                    InternalCalls.SvcBreak(res.Value);
            }
            if (res.Failure)
                InternalCalls.SvcBreak(res.Value);
            res = FileBindings.GetFileSize(out CachedSize, Handle);
            if (res.Failure)
                InternalCalls.SvcBreak(res.Value);
        }
    }
    public Result Write(string text) {
        unsafe {
            fixed (byte* data = InternalCalls.StrToAnsi(text))
                return Write(data, (ulong) (text.Length - 1));
        }
    }
    public Result Write(Span<byte> buffer) {
        unsafe {
            fixed (byte* data = buffer)
                return Write(data, (ulong) buffer.Length);
        }
    }
    public unsafe Result Write(byte* data, ulong size) {
        Result res;
        if (Position + (long) size > CachedSize) {
            res = Resize((long) size);
            if (res.Failure)
                InternalCalls.SvcBreak(res.Value);
        }
        res = FileBindings.WriteFile(Handle, Position, data, size);
        Position += (long) size;
        return res;
    }

    public Result Resize(long newSize) {
        unsafe {
            return FileBindings.SetFileSize(Handle, newSize);
        }
    }
    public Result GetSize(out long size) {
        unsafe {
            Result res = FileBindings.GetFileSize(out size, Handle);
            if (res.Success) CachedSize = size;
            return res;
        }
    }
    public void Dispose() {
        unsafe {
            FileBindings.CloseFile(Handle);
        }
    }
}