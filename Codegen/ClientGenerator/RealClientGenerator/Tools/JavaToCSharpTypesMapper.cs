using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealClientGenerator.Tools
{
    public class JavaToCSharpTypesMapper : ITypesMapper
    {
        public string GetMappedType(string otherType)
        {
            switch (otherType)
            {
                case "boolean": return "bool";
                case "Boolean": return "bool?";
                case "byte": return "sbyte";
                case "Byte": return "sbyte?";
                case "short": return "short";
                case "Short": return "short?";
                case "int": return "int";
                case "Integer": return "int?";
                case "long": return "long";
                case "Lont": return "long?";
                case "BigInteger": return "long?";
                case "char": return "char";
                case "Char": return "char?";
                case "float": return "float";
                case "Float": return "float?";
                case "double": return "double";
                case "Double": return "double?";
                case "BigDecimal": return "decimal?";
                case "String": return "string";
                case "Date": return "System.DateTime";
                case "Calendar": return "System.DateTime";
                case "ArrayList": return "System.Collections.Generic.List";
                case "HashMap": return "System.Collections.Generic.Dictionary";
                case "LinkedList": return "System.Collections.Generic.LinkedList";
                case "Vector": return "System.Collections.Generic.List";
                case "Stack": return "System.Collections.Generic.Stack";
                default: return otherType;
            }
        }
    }
}
