using System.Runtime.InteropServices;

namespace CSInterop
{
    public class MathLibraryImport
    {
        [DllImport("MyMathLibrary", CallingConvention = CallingConvention.StdCall, EntryPoint = "sum")]
        public static extern int Sum(int a, int b);
    }
}
