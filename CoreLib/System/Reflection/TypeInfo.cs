namespace System.Reflection; 

public class TypeInfo : Type, IReflectableType {
    protected TypeInfo() {
        
    }
    public TypeInfo GetTypeInfo() => this;
}