using BenchmarkDotNet;

namespace CsBenchmarking
{
    public class SortingAlgorithms
    {
        public static Type[] StoogeSort<Type>(Type[] array, int fromIndex, int toIndex, IComparator<Type> comparator)
        {
            if (!comparator.IsFirstLess(array[fromIndex], array[toIndex]))
            {
                (array[fromIndex], array[toIndex]) = (array[toIndex], array[fromIndex]);
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
        
        public static Type[] InsertionSort<Type>(Type[] array, int fromIndex, int toIndex, IComparator<Type> comparator)
        {
            for (int i = fromIndex + 1; i <= toIndex; ++i)
            {
                for (int j = i; j > fromIndex; --j)
                {
                    if (!comparator.IsFirstLess(array[j - 1], array[j]))
                    {
                        (array[j], array[j - 1]) = (array[j - 1], array[j]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return array;
        }

        public static Type[] MergeSort<Type>(Type[] array, int fromIndex, int toIndex, IComparator<Type> comparator)
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
            var newArray = new Type[toIndex - fromIndex + 1];
            int newPtr = 0;
            while (fromPtr <= midIndex || midPtr <= toIndex)
            {
                if (fromPtr > midIndex)
                {
                    newArray[newPtr++] = array[midPtr++];
                }
                else if (midPtr > toIndex)
                {
                    newArray[newPtr++] = array[fromPtr++];
                }
                else if (comparator.IsFirstLess(array[fromPtr], array[midPtr]))
                {
                    newArray[newPtr++] = array[fromPtr++];
                }
                else
                {
                    newArray[newPtr++] = array[midPtr++];
                }
            }

            for (int i = fromIndex; i <= toIndex; ++i)
            {
                array[i] = newArray[i - fromIndex];
            }

            return array;
        }

        public static Type[] QuickSort<Type>(Type[] array, int fromIndex, int toIndex, IComparator<Type> comparator)
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

        private static int Partition<Type>(Type[] array, int leftPtr, int rightPtr, IComparator<Type> comparator)
        {
            Type strongElement = array[(leftPtr + rightPtr) / 2];

            while (leftPtr < rightPtr)
            {
                if (comparator.IsFirstLess(array[leftPtr], strongElement))
                {
                    ++leftPtr;
                }
                else if (comparator.IsFirstLess(strongElement, array[rightPtr]))
                {
                    --rightPtr;
                }
                else
                {
                    (array[leftPtr], array[rightPtr]) = (array[rightPtr], array[leftPtr]);
                    ++leftPtr;
                    --rightPtr;
                }
            }

            return rightPtr;
        }
    }
}