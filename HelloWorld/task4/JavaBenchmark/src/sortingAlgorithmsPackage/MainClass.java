package sortingAlgorithmsPackage;
import java.util.*;

public class MainClass {
	public static void main(String[] args)
	{
		var array = new ArrayList<Integer>();
	    for (int i = 0; i < 10; ++i)
	    {
	        array.add(new Random().nextInt(0, 10));
	        System.out.print(array.get(i) + " ");
	    }
	    System.out.println();
	
	    SortingAlgorithms.QuickSort(array, 0, array.size() - 1, new LessComparator());
	    //Array.Sort(array);
	
	    for (int value : array)
	    {
	        System.out.print(value + " ");
	    }
	}
}
