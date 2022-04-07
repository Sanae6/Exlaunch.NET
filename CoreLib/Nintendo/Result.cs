namespace Nintendo;

public struct Result {
    public int Value;
    public int Module {
        get => Value & 0x1FF;
        set => Value = Description | value & 0x1FF;
    }
    public int Description {
        get => Value >> 9 & 0x1FFF;
        set => Value = Module | (value & 0x1FFF) << 9;
    }
    public bool Success => Value == 0;
    public bool Failure => Value != 0;
}
