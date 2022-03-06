namespace System.Runtime.CompilerServices;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
public class MethodImplAttribute : Attribute {
    public MethodCodeType MethodCodeType;
    public MethodImplAttribute() { }

    public MethodImplAttribute(short options) {
        Value = (MethodImplOptions) options;
    }

    public MethodImplAttribute(MethodImplOptions options) {
        Value = options;
    }

    public MethodImplOptions Value { get; }
}