using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace CsBenchmarking
{
    [SimpleJob(RunStrategy.Throughput, launchCount: 10)]
    [MemoryDiagnoser]
    public class SortingBenchmark
    {
        private int[] _array;
        private IComparator<int> _comparator;
        public SortingBenchmark()
        {
            _array = new int[1000];
            _comparator = new LessComparator();
        }

        [Benchmark(Description = "StoogeSortBenchmark")]
        public int[] StoogeSortBenchmark()
        {
            GenerateRandomSequence();
            return SortingAlgorithms.StoogeSort(_array, 0, _array.Length - 1, _comparator);
        }

        [Benchmark(Description = "InsertionSortBenchmark")]
        public int[] InsertionSortBenchmark()
        {
            GenerateRandomSequence();
            return SortingAlgorithms.InsertionSort(_array, 0, _array.Length - 1, _comparator);
        }

        [Benchmark(Description = "MergeSortBenchmark")]
        public int[] MergeSortBenchmark()
        {
            GenerateRandomSequence();
            return SortingAlgorithms.MergeSort(_array, 0, _array.Length - 1, _comparator);
        }

        [Benchmark(Description = "QuickSortBenchmark")]
        public int[] QuickSortBenchmark()
        {
            GenerateRandomSequence();
            return SortingAlgorithms.QuickSort(_array, 0, _array.Length - 1, _comparator);
        }

        [Benchmark(Description = "DefaultSortBenchmark")]
        public int[] DefaultSortBenchmark()
        {
            GenerateRandomSequence();
            Array.Sort(_array);
            return _array;
        }

        private void GenerateRandomSequence()
        {
            for (int i = 0; i < _array.Length; ++i)
            {
                _array[i] = new Random().Next();
            }
        }
    }
}
