namespace CsDfsAndBfs.Tools
{
	public interface IUnaryOperation<InputType, ReturnType>
	{
		ReturnType Apply(InputType value);
	}
}
