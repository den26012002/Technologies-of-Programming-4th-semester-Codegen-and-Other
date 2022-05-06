using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTemplate.Entities
{
    public class MethodDeclaration
    {
        public HttpMethodAnnotation HttpMethodAnnotation { get; set; }
        public TypeTree ReturnType { get; set; } = new TypeTree();
        public string Name { get; set; }
        public ArrayList<FormalParameter> formalParameters { get; set; } = new ArrayList<FormalParameter>();
    }
}
