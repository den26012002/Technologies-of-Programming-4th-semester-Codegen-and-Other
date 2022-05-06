using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTemplate.Entities
{
    public class SemanticModel
    {
        public ArrayList<MethodDeclaration> ServerMethodDeclarations { get; set; } = new ArrayList<MethodDeclaration>();
        public ArrayList<ClassWithFields> UserTypes { get; set; } = new ArrayList<ClassWithFields>();
    }
}
