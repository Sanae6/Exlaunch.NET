using System.Runtime.InteropServices;

namespace Internal.Runtime;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct MethodTable {
    #region Offsets

    private const int DebugClassNamePtr = // adjust for debug_m_szClassName
#if DEBUG
#if TARGET_64BIT
            8
#else
            4
#endif
#else
            0
#endif
        ;

    private const int ParentMethodTableOffset = 0x10 + DebugClassNamePtr;
#if TARGET_64BIT
        private const int ElementTypeOffset = 0x30 + DebugClassNamePtr;
#else
    private const int ElementTypeOffset = 0x20 + DebugClassNamePtr;
#endif

#if TARGET_64BIT
        private const int InterfaceMapOffset = 0x38 + DebugClassNamePtr;
#else
    private const int InterfaceMapOffset = 0x24 + DebugClassNamePtr;
#endif

    #endregion

    [FieldOffset(0x0)]
    public ushort ComponentSize;
    [FieldOffset(0x2)]
    public ushort Flags;
    [FieldOffset(0x4)]
    public uint BaseSize;
    [FieldOffset(0xE)]
    public void* RelatedType;
    [FieldOffset(ParentMethodTableOffset)]
    public MethodTable* ParentMethodTable;
    [FieldOffset(ElementTypeOffset)]
    public void* ElementType;
    [FieldOffset(InterfaceMapOffset)]
    public MethodTable** InterfaceMap;
}