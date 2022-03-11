using System;
using BenchmarkDotNet.Running;

namespace CsBenchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var array = new int[10000];
            for (int i = 0; i < array.Length; ++i)
            {
                array[i] = new Random().Next(10);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();

            SortingAlgorithms.InsertionSort(array, 0, array.Length - 1, new LessComparator());
            //Array.Sort(array);

            foreach (int value in array)
            {
                Console.Write($"{value} ");
            }*/
            BenchmarkRunner.Run<SortingBenchmark>();
        }
    }
}
