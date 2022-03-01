namespace System.Runtime; 

[AttributeUsage(AttributeTargets.Method)]
public sealed class RuntimeExportAttribute : Attribute {
    public RuntimeExportAttribute(string entry) { }
}