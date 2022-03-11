package sortingAlgorithmsPackage;
import java.util.*;

public class SortingAlgorithms {
	public static<Type> ArrayList<Type> StoogeSort(ArrayList<Type> array, int fromIndex, int toIndex, IComparator<Type> comparator)
    {
        if (!comparator.IsFirstLess(array.get(fromIndex), array.get(toIndex)))
        {
        	Collections.swap(array, fromIndex, toIndex);
        }

        if (fromIndex + 1 >= toIndex)
        {
            return array;
        }

        int third = (toIndex - fromIndex + 1) / 3;
        StoogeSort(array, fromIndex, toIndex - third, comparator);
        StoogeSort(array, fromIndex + third, toIndex, comparator);
        StoogeSort(array, fromIndex, toIndex - third, comparator);
        return array;
    }
    
    public static<Type> ArrayList<Type> InsertionSort(ArrayList<Type> array, int fromIndex, int toIndex, IComparator<Type> comparator)
    {
        for (int i = fromIndex + 1; i <= toIndex; ++i)
        {
            for (int j = i; j > fromIndex; --j)
            {
                if (!comparator.IsFirstLess(array.get(j - 1), array.get(j)))
                {
                	Collections.swap(array, j, j - 1);
                }
                else
                {
                    break;
                }
            }
        }
        return array;
    }

    public static<Type> ArrayList<Type> MergeSort(ArrayList<Type> array, int fromIndex, int toIndex, IComparator<Type> comparator)
    {
        if (fromIndex >= toIndex)
        {
            return array;
        }

        int midIndex = (fromIndex + toIndex) / 2;
        MergeSort(array, fromIndex, midIndex, comparator);
        MergeSort(array, midIndex + 1, toIndex, comparator);
        int fromPtr = fromIndex;
        int midPtr = midIndex + 1;
        @SuppressWarnings("unchecked")
		var newArray = (ArrayList<Type>)new ArrayList<Object>(toIndex - fromIndex + 1);
        int newPtr = 0;
        while (fromPtr <= midIndex || midPtr <= toIndex)
        {
            if (fromPtr > midIndex)
            {
                newArray.add(array.get(midPtr++));
            }
            else if (midPtr > toIndex)
            {
                newArray.add(array.get(fromPtr++));
            }
            else if (comparator.IsFirstLess(array.get(fromPtr), array.get(midPtr)))
            {
                newArray.add(array.get(fromPtr++));
            }
            else
            {
                newArray.add(array.get(midPtr++));
            }
        }

        for (int i = fromIndex; i <= toIndex; ++i)
        {
            array.set(i, newArray.get(i - fromIndex));
        }

        return array;
    }

    public static<Type> ArrayList<Type> QuickSort(ArrayList<Type> array, int fromIndex, int toIndex, IComparator<Type> comparator)
    {
        if (fromIndex >= toIndex)
        {
            return array;
        }
        int midIndex = Partition(array, fromIndex, toIndex, comparator);
        QuickSort(array, fromIndex, midIndex, comparator);
        QuickSort(array, midIndex + 1, toIndex, comparator);
        return array;
    }

    private static<Type> int Partition(ArrayList<Type> array, int leftPtr, int rightPtr, IComparator<Type> comparator)
    {
        Type strongElement = array.get((leftPtr + rightPtr) / 2);

        while (leftPtr < rightPtr)
        {
            if (comparator.IsFirstLess(array.get(leftPtr), strongElement))
            {
                ++leftPtr;
            }
            else if (comparator.IsFirstLess(strongElement, array.get(rightPtr)))
            {
                --rightPtr;
            }
            else
            {
            	Collections.swap(array, leftPtr, rightPtr);
                ++leftPtr;
                --rightPtr;
            }
        }

        return rightPtr;
    }
}
