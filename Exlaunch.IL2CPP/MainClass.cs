using System.Runtime;
using System.Runtime.CompilerServices;

namespace Exlaunch.IL2CPP;

public class MainClass {
    [RuntimeExport("exl_main")]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void Main() {
        
    }
}