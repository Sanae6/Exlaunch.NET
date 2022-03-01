namespace System.Runtime.InteropServices; 

[AttributeUsage(AttributeTargets.Method)]
public sealed class DllImportAttribute : Attribute {
    public CharSet CharSet = CharSet.Ansi;
    public string? EntryPoint;
    public DllImportAttribute(string dllName) { }
}