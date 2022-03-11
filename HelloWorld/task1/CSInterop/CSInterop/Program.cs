using System;

namespace CSInterop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MathLibraryImport.Sum(10, 20));
        }
    }
}
