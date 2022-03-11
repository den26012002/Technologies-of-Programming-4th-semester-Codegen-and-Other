package dfs_and_bfs1.graphs;

public class MainClass {
	public static void main(String[] args)
	{
		Graph<Integer> graph = new Graph<Integer>(10);
		graph.addEdge(0, 1);
		graph.addEdge(1, 2);
		graph.addEdge(2, 3);
		graph.changeVertex(0, 10);
		graph.changeVertex(1, 20);
		graph.changeVertex(2, 30);
		graph.changeVertex(3, 100);
		graph = Algorithms.dfs(graph, 0, new TwiceOperation());
		Graph<String> newGraph = Algorithms.dfs(graph, 0, new ToStringOperation<Integer>());
		Algorithms.bfs(newGraph, 0, new OutputOperation<String>());
	}
}
