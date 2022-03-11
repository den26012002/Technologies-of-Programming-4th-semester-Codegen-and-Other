namespace CsDfsAndBfs.Tools
{
    public class ToStringOperation<InputType> : IUnaryOperation<InputType, string>
    {
        public string Apply(InputType value)
        {
            return value.ToString();
        }
    }
}
