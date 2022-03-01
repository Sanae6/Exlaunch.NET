namespace System; 

[Flags]
public enum AttributeTargets {
    Assembly = 0x1,
    Module = 0x2,
    Class = 0x4,
    Struct = 0x8,
    Enum = 0x10,
    Constructor = 0x20,
    Method = 0x40,
    Property = 0x80,
    Field = 0x100,
    Event = 0x200,
    Interface = 0x400,
    Parameter = 0x800,
    ReturnValue = 0x2000,
    Delegate = 0x1000,
    GenericParameter = 0x4000,
    All = Assembly | Module | Class | Struct | Enum | Constructor | Method | Property | Field | Event | Interface | Parameter | ReturnValue | Delegate | GenericParameter
}