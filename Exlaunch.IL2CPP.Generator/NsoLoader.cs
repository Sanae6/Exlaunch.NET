using LZ4;

namespace Exlaunch.IL2CPP.Generator;

public class NsoLoader {
    public NsoLoader() {
        
    }

    public struct NsoHeader {
        public int Magic;
        public int Version;
        public int Reserved;
        public int Flags;
        public SegmentHeader TextSegHeader;
        public int ModuleNameOffset;
        public SegmentHeader RoDataSegHeader;
        public int ModuleNameSize;
        public SegmentHeader DataSegHeader;
        public int BssSize;
        public Guid ModuleId1; // don't care
        public Guid ModuleId2; // didn't ask
    }

    public struct SegmentHeader {
        public int FileOffset;
        public int MemoryOffest;
        public int DecompressedSize;
    }

    public struct SegmentHeaderRel { // relative to rodata
        public int FileOffset;
        public int Size;
    }
}