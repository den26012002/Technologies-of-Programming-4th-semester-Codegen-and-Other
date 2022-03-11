using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsBenchmarking
{
    class LessComparator : IComparator<int>
    {
        public bool IsFirstLess(int value1, int value2)
        {
            return value1 < value2;
        }
    }
}
