using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTemplate
{
    public class TypeTree
    {
        // public ArrayList<string> GenericContainerNames { get; set; } = new ArrayList<string>();
        public string Name { get; set; } = "void";
        public ArrayList<TypeTree> InnerTypes { get; set; } = new ArrayList<TypeTree>();
    }
}
