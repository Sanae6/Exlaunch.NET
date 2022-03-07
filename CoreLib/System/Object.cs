using Internal.Runtime;

namespace System;

public class Object {
    // The layout of object is a contract with the compiler.
    private unsafe MethodTable* MethodTable;

    public unsafe MethodTable* GetMethodTable() {
        return MethodTable;
    }

    /**
     * A method forged from pure evil, designed to carry out the will of its creator no matter the cost.
     * Changes the method table of an object at its very core, allowing for incredibly unsafe casting.
     */
    public unsafe void SetMethodTable(MethodTable* table) {
        MethodTable = table;
    }

    public unsafe T CastToAnything<T>() {
        MethodTable = typeof(T).TypeHandle.MethodTable;
        return (T) this;
    }
}