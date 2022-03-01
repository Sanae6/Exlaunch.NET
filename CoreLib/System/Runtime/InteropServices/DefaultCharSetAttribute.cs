namespace System.Runtime.InteropServices; 

[AttributeUsage(AttributeTargets.Module)]
public sealed class DefaultCharSetAttribute : Attribute {
    public CharSet CharSet;

    public DefaultCharSetAttribute(CharSet charSet) {
        CharSet = charSet;
    }
}