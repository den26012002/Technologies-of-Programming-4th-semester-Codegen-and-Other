using System;
using System.Collections;
using FS;
using Microsoft.FSharp.Collections;

namespace FSUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Just a function
            Console.WriteLine(FS.func.from("a"));

            //Discriminated union
            FS.func.Union union = FS.func.Union.NewX(10);
            FS.func.printUnion(union);

            //Computation expression
            FS.func.logSumOfSqrs(10, 20);
        }
    }
}
