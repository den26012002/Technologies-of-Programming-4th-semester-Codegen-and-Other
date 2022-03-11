using CsDfsAndBfs.Entities;
using CsDfsAndBfs.Services;
using CsDfsAndBfs.Tools;

namespace CsDfsAndBfs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<int>(10);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.ChangeVertex(0, 10);
            graph.ChangeVertex(1, 20);
            graph.ChangeVertex(2, 30);
            graph.ChangeVertex(3, 100);
            Graph<int> newGraph = Algorithms.Dfs(graph, 0, new TwiceOperation());
            Algorithms.Bfs(newGraph, 0, new OutputOperation<int>());
        }
    }
}
