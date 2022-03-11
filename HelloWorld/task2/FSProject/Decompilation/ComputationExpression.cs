using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.FSharp.Core;

[assembly: FSharpInterfaceDataVersion(2, 0, 0)]
[assembly: AssemblyVersion("0.0.0.0")]
[CompilationMapping(SourceConstructFlags.Module)]
public static class @_
{
    [Serializable]
    [CompilationMapping(SourceConstructFlags.ObjectType)]
    public class LoggingBuilder
    {
        public c Bind<b, c>(b x, FSharpFunc<b, c> f)
        {
            log(x);
            return f.Invoke(x);
        }

        public a Return<a>(a x)
        {
            return x;
        }

        [CompilerGenerated]
        internal void log<a>(a p)
        {
            PrintfFormat<FSharpFunc<a, Unit>, TextWriter, Unit, Unit> format = new PrintfFormat<FSharpFunc<a, Unit>, TextWriter, Unit, Unit, a>("expression is %A");
            PrintfModule.PrintFormatLineToTextWriter(Console.Out, format).Invoke(p);
        }
    }

    [CompilerGenerated]
    internal static int f@8(LoggingBuilder logger, int x)
    {
        logger.log(43);
        return f@8-1(logger, x, 43);
    }

[CompilerGenerated]
internal static int f@8-1(LoggingBuilder logger, int x, int y)
    {
    int num = x + y;
    logger.log(num);
    return num;
}

[EntryPoint]
public static int main(string[] argv)
{
    LoggingBuilder loggingBuilder = new LoggingBuilder();
    loggingBuilder.log(42);
    int num = f@8(loggingBuilder, 42);
    return 0;
}
}
