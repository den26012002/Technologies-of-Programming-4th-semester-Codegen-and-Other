using System;
using System.IO;
using System.Reflection;
using Microsoft.FSharp.Core;

[assembly: FSharpInterfaceDataVersion(2, 0, 0)]
[CompilationMapping(SourceConstructFlags.Module)]
public static class @_
{
    public static string from(string whom)
    {
        return PrintfModule.PrintFormatToStringThen(new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("from %s")).Invoke(whom);
    }

    [EntryPoint]
    public static int Main(string[] argv)
    {
        string func = PrintfModule.PrintFormatToStringThen(new PrintfFormat<FSharpFunc<string, string>, Unit, string, string, string>("from %s")).Invoke("F#");
        PrintfFormat<FSharpFunc<string, Unit>, TextWriter, Unit, Unit> format = new PrintfFormat<FSharpFunc<string, Unit>, TextWriter, Unit, Unit, string>("Hello world %s");
        PrintfModule.PrintFormatLineToTextWriter(Console.Out, format).Invoke(func);
        return 0;
    }
}