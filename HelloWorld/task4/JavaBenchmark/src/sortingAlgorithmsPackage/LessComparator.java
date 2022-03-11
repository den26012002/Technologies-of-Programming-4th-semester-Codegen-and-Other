package sortingAlgorithmsPackage;

class LessComparator implements IComparator<Integer>
{
    public boolean IsFirstLess(Integer value1, Integer value2)
    {
        return value1 < value2;
    }
}
