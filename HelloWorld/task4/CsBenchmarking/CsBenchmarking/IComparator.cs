namespace CsBenchmarking
{
    public interface IComparator<Type>
    {
        bool IsFirstLess(Type value1, Type value2);
    }
}
