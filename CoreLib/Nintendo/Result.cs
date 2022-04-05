namespace Nintendo;

public struct Result {
    public uint Value;
    public bool Success => Value ==  0;
}
