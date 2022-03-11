using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.FSharp.Core;

[assembly: FSharpInterfaceDataVersion(2, 0, 0)]
[assembly: AssemblyVersion("0.0.0.0")]
[CompilationMapping(SourceConstructFlags.Module)]
public static class @_
{
    [Serializable]
    [StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto)]
    [DebuggerDisplay("{__DebugDisplay(),nq}")]
    [CompilationMapping(SourceConstructFlags.SumType)]
    public abstract class Union : IEquatable<Union>, IStructuralEquatable, IComparable<Union>, IComparable, IStructuralComparable
    {
        public static class Tags
        {
            public const int X = 0;

            public const int Y = 1;
        }

        [Serializable]
        [SpecialName]
        [DebuggerTypeProxy(typeof(X@DebugTypeProxy))]
        [DebuggerDisplay("{__DebugDisplay(),nq}")]
        public class X : Union
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            [CompilerGenerated]
            [DebuggerNonUserCode]
            internal readonly int item;

            [CompilationMapping(SourceConstructFlags.Field, 0, 0)]
            [CompilerGenerated]
            [DebuggerNonUserCode]
            public int Item
            {
                [CompilerGenerated]
                [DebuggerNonUserCode]
                get
                {
                    return item;
                }
            }

            [CompilerGenerated]
            [DebuggerNonUserCode]
            internal X(int item)
            {
                this.item = item;
            }
        }

        [Serializable]
        [SpecialName]
        [DebuggerTypeProxy(typeof(Y@DebugTypeProxy))]
        [DebuggerDisplay("{__DebugDisplay(),nq}")]
        public class Y : Union
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            [CompilerGenerated]
            [DebuggerNonUserCode]
            internal readonly string item;

            [CompilationMapping(SourceConstructFlags.Field, 1, 0)]
            [CompilerGenerated]
            [DebuggerNonUserCode]
            public string Item
            {
                [CompilerGenerated]
                [DebuggerNonUserCode]
                get
                {
                    return item;
                }
            }

            [CompilerGenerated]
            [DebuggerNonUserCode]
            internal Y(string item)
            {
                this.item = item;
            }
        }

        [SpecialName]
        internal class X@DebugTypeProxy
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CompilerGenerated]
        [DebuggerNonUserCode]
        internal X _obj;

        [CompilationMapping(SourceConstructFlags.Field, 0, 0)]
        [CompilerGenerated]
        [DebuggerNonUserCode]
        public int Item
        {
            [CompilerGenerated]
            [DebuggerNonUserCode]
            get
            {
                return _obj.item;
            }
        }

        [CompilerGenerated]
        [DebuggerNonUserCode]
        public X @DebugTypeProxy(X obj)
        {
            _obj = obj;
        }
    }

    [SpecialName]
    internal class Y@DebugTypeProxy
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    [CompilerGenerated]
    [DebuggerNonUserCode]
    internal Y _obj;

    [CompilationMapping(SourceConstructFlags.Field, 1, 0)]
    [CompilerGenerated]
    [DebuggerNonUserCode]
    public string Item
    {
        [CompilerGenerated]
        [DebuggerNonUserCode]
        get
        {
            return _obj.item;
        }
    }

    [CompilerGenerated]
    [DebuggerNonUserCode]
    public Y @DebugTypeProxy(Y obj)
    {
        _obj = obj;
    }
}

[CompilerGenerated]
[DebuggerNonUserCode]
[DebuggerBrowsable(DebuggerBrowsableState.Never)]
public int Tag
{
    [CompilerGenerated]
    [DebuggerNonUserCode]
    get
    {
        return (this is Y) ? 1 : 0;
    }
}

[CompilerGenerated]
[DebuggerNonUserCode]
[DebuggerBrowsable(DebuggerBrowsableState.Never)]
public bool IsX
{
    [CompilerGenerated]
    [DebuggerNonUserCode]
    get
    {
        return this is X;
    }
}

[CompilerGenerated]
[DebuggerNonUserCode]
[DebuggerBrowsable(DebuggerBrowsableState.Never)]
public bool IsY
{
    [CompilerGenerated]
    [DebuggerNonUserCode]
    get
    {
        return this is Y;
    }
}

[CompilerGenerated]
[DebuggerNonUserCode]
internal Union()
{
}

[CompilationMapping(SourceConstructFlags.UnionCase, 0)]
public static Union NewX(int item)
{
    return new X(item);
}

[CompilationMapping(SourceConstructFlags.UnionCase, 1)]
public static Union NewY(string item)
{
    return new Y(item);
}

[SpecialName]
[CompilerGenerated]
[DebuggerNonUserCode]
internal object __DebugDisplay()
{
    return ExtraTopLevelOperators.PrintFormatToString(new PrintfFormat<FSharpFunc<Union, string>, Unit, string, string, string>("%+0.8A")).Invoke(this);
}

[CompilerGenerated]
public override string ToString()
{
    return ExtraTopLevelOperators.PrintFormatToString(new PrintfFormat<FSharpFunc<Union, string>, Unit, string, string, Union>("%+A")).Invoke(this);
}

[CompilerGenerated]
public sealed override int CompareTo(Union obj)
{
    if (this != null)
    {
        if (obj != null)
        {
            int num = ((this is Y) ? 1 : 0);
            int num2 = ((obj is Y) ? 1 : 0);
            if (num == num2)
            {
                IComparer genericComparer;
                if (this is X)
                {
                    X x = (X)this;
                    X x2 = (X)obj;
                    genericComparer = LanguagePrimitives.GenericComparer;
                    int item = x.item;
                    int item2 = x2.item;
                    if (item < item2)
                    {
                        return -1;
                    }
                    return (item > item2) ? 1 : 0;
                }
                Y y = (Y)this;
                Y y2 = (Y)obj;
                genericComparer = LanguagePrimitives.GenericComparer;
                return string.CompareOrdinal(y.item, y2.item);
            }
            return num - num2;
        }
        return 1;
    }
    if (obj != null)
    {
        return -1;
    }
    return 0;
}

[CompilerGenerated]
public sealed override int CompareTo(object obj)
{
    return CompareTo((Union)obj);
}

[CompilerGenerated]
public sealed override int CompareTo(object obj, IComparer comp)
{
    Union union = (Union)obj;
    if (this != null)
    {
        if ((Union)obj != null)
        {
            int num = ((this is Y) ? 1 : 0);
            Union union2 = union;
            int num2 = ((union2 is Y) ? 1 : 0);
            if (num == num2)
            {
                if (this is X)
                {
                    X x = (X)this;
                    X x2 = (X)union;
                    int item = x.item;
                    int item2 = x2.item;
                    if (item < item2)
                    {
                        return -1;
                    }
                    return (item > item2) ? 1 : 0;
                }
                Y y = (Y)this;
                Y y2 = (Y)union;
                return string.CompareOrdinal(y.item, y2.item);
            }
            return num - num2;
        }
        return 1;
    }
    if ((Union)obj != null)
    {
        return -1;
    }
    return 0;
}

[CompilerGenerated]
public sealed override int GetHashCode(IEqualityComparer comp)
{
    if (this != null)
    {
        int num = 0;
        if (this is X)
        {
            X x = (X)this;
            num = 0;
            return -1640531527 + (x.item + ((num << 6) + (num >> 2)));
        }
        Y y = (Y)this;
        num = 1;
        string item = y.item;
        return -1640531527 + (((item != null) ? item.GetHashCode() : 0) + ((num << 6) + (num >> 2)));
    }
    return 0;
}

[CompilerGenerated]
public sealed override int GetHashCode()
{
    return GetHashCode(LanguagePrimitives.GenericEqualityComparer);
}

[CompilerGenerated]
public sealed override bool Equals(object obj, IEqualityComparer comp)
{
    if (this != null)
    {
        Union union = obj as Union;
        if (union != null)
        {
            int num = ((this is Y) ? 1 : 0);
            Union union2 = union;
            int num2 = ((union2 is Y) ? 1 : 0);
            if (num == num2)
            {
                if (this is X)
                {
                    X x = (X)this;
                    X x2 = (X)union;
                    return x.item == x2.item;
                }
                Y y = (Y)this;
                Y y2 = (Y)union;
                return string.Equals(y.item, y2.item);
            }
            return false;
        }
        return false;
    }
    return obj == null;
}

[CompilerGenerated]
public sealed override bool Equals(Union obj)
{
    if (this != null)
    {
        if (obj != null)
        {
            int num = ((this is Y) ? 1 : 0);
            int num2 = ((obj is Y) ? 1 : 0);
            if (num == num2)
            {
                if (this is X)
                {
                    X x = (X)this;
                    X x2 = (X)obj;
                    return x.item == x2.item;
                }
                Y y = (Y)this;
                Y y2 = (Y)obj;
                return string.Equals(y.item, y2.item);
            }
            return false;
        }
        return false;
    }
    return obj == null;
}

[CompilerGenerated]
public sealed override bool Equals(object obj)
{
    Union union = obj as Union;
    if (union != null)
    {
        return Equals(union);
    }
    return false;
}
    }

    [EntryPoint]
public static int main(string[] argv)
{
    PrintfFormat<FSharpFunc<string, Unit>, TextWriter, Unit, Unit> format = new PrintfFormat<FSharpFunc<string, Unit>, TextWriter, Unit, Unit, string>("%s");
    PrintfModule.PrintFormatLineToTextWriter(Console.Out, format).Invoke("alkdfjs");
    return 0;
}
}
namespace <StartupCode$_>
{
    internal static class $_
    {
    }
}
