using System;

namespace Nintendo.Bindings; 

[Flags]
public enum OpenMode {
    Read = 1 << 0,
    Write = 1 << 1
}