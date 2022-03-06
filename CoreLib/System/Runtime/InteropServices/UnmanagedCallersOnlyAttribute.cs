namespace System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Method, Inherited = false)]
public sealed class UnmanagedCallersOnlyAttribute : Attribute
{
    public UnmanagedCallersOnlyAttribute()
    {
    }

    /// <summary>
    /// Optional. If omitted, the runtime will use the default platform calling convention.
    /// </summary>
    /// <remarks>
    /// Supplied types must be from the official "System.Runtime.CompilerServices" namespace and
    /// be of the form "CallConvXXX".
    /// </remarks>
    public Type[]? CallConvs;

    /// <summary>
    /// Optional. If omitted, no named export is emitted during compilation.
    /// </summary>
    public string? EntryPoint;
}