using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealClientGenerator.Tools
{
    public class StringModifier
    {
        public string MakeCSharpName(string name)
        {
            string result = name;
            if (name[0] == '_')
            {
                result = result.Remove(0, 1);
            }

            if (result[0] > 'a' && result[0] < 'z')
            {
                result = string.Concat(result.First().ToString().ToUpper(), result.AsSpan(1));
            }

            return result;
        }

        public string DeleteQuotes(string name)
        {
            string result = name;
            if (result[0] == '\"')
            {
                result = result.Remove(0, 1);
            }

            if (result[result.Length - 1] == '\"')
            {
                result = result.Remove(result.Length - 1, 1);
            }

            return result;
        }
    }
}
