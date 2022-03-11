namespace CsDfsAndBfs.Tools
{
    public class TwiceOperation : IUnaryOperation<int, int>
    {
        public int Apply(int value)
        {
            return value * 2;
        }
    }
}
