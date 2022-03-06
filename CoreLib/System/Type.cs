using System.Reflection;

namespace System;

public abstract class Type {
    public RuntimeTypeHandle TypeHandle;

    public static Type GetTypeFromHandle(RuntimeTypeHandle handle) {
        return new RuntimeType {
            TypeHandle = handle
        };
    }
}

public class RuntimeType : TypeInfo {
    
}