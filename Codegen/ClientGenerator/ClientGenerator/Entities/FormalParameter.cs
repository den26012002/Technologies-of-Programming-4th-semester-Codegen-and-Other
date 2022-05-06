using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrTemplate.Entities
{
    public class FormalParameter
    {
        public string HttpParameterAnnotation { get; set; }
        public TypeTree Type { get; set; } = new TypeTree();
        public string Name { get; set; }
    }
}
