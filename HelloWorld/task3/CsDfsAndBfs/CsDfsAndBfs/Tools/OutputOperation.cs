using System;
using CsDfsAndBfs.Entities;

namespace CsDfsAndBfs.Tools
{
    public class OutputOperation<InputType> : IUnaryOperation<InputType, Unit>
    {
        public Unit Apply(InputType value)
        {
            Console.WriteLine(value);
            return new Unit();
        }
    }
}
