namespace System;

public abstract class Array {
#pragma warning disable CS0169
    private int numComponents;
#pragma warning restore CS0169
}

public class Array<T> : Array { }