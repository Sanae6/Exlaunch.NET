namespace System; 

[AttributeUsage(AttributeTargets.Class)]
public class AttributeUsageAttribute : Attribute {
    public AttributeUsageAttribute(AttributeTargets targets) { }
    public bool AllowMultiple { get; set; } = false;
    public bool Inherited { get; set; } = true;
}