using System;

namespace Nintendo.Fs; 

[Flags]
public enum OpenMode {
    Read = 1 << 0,
    Write = 1 << 1,
    Append = 1 << 2
}