using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientGenerator.Entities
{
    public class ClassField
    {
        public TypeTree Type { get; set; } = new TypeTree();
        public string Name { get; set; }
    }
}
