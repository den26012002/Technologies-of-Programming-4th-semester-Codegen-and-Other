using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealClientGenerator.Tools
{
    public interface ITypesMapper
    {
        string GetMappedType(string otherType);
    }
}
