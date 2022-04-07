using System.Runtime.InteropServices;
using System.Text;

namespace Exlaunch.IL2CPP.Generator;

public class GlobalMetadata {
    private byte[] Data;
    private Range Strings;
    // todo: put all struct ranges here, make methods to access them

    public GlobalMetadata(byte[] data) {
        MetadataHeader header = MemoryMarshal.Read<MetadataHeader>(data);
        Strings = header.StringOffset..(header.StringOffset + header.StringCount);
        
    }

    public string GetString(int index) {
        Span<byte> b = Data[Strings];
        return Encoding.UTF8.GetString(b[index..b.IndexOf((byte) 0)]);
    }
}