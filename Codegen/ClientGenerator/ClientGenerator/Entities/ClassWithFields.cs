using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTemplate
{
    public class ClassWithFields
    {
        public string Name { get; set; }
        public ArrayList<ClassField> Fields { get; set; } = new ArrayList<ClassField>();
    }
}
