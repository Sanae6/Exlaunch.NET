namespace System.Runtime.InteropServices; 

[AttributeUsage(AttributeTargets.Method)]
public sealed class DllImportAttribute : Attribute {
    public CharSet CharSet = CharSet.Ansi;
    public string? EntryPoint;
    public CallingConvention CallingConvention;
    public bool ExactSpelling;
    public bool PreserveSig;
    public bool SetLastError;
    public bool BestFitMapping;
    public bool ThrowOnUnmappableChar;
    public string Value { get; }
    public DllImportAttribute(string dllName = "*") {
        Value = dllName;
    }
}