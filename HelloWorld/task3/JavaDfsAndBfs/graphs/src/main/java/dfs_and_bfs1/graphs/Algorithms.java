package dfs_and_bfs1.graphs;
import java.util.*;

public class Algorithms {
	static public<Type, ReturnType> Graph<ReturnType> dfs(
			Graph<Type> graph,
			int vertex,
			IUnaryOperation<Type, ReturnType> operation)
	{
		Graph<ReturnType> resultGraph = new Graph<ReturnType>(graph);
		Graph<Boolean> graphCopy = new Graph<Boolean>(graph);
		for (int i = 0; i < graphCopy.size(); ++i)
		{
			graphCopy.changeVertex(i, false);
		}
	    dfs(graph, vertex, operation, resultGraph, graphCopy);
	    return resultGraph;
	}
	
	static public<Type, ReturnType> Graph<ReturnType> bfs(
			Graph<Type> graph,
			int vertex,
			IUnaryOperation<Type, ReturnType> operation)
	{
		Graph<ReturnType> resultGraph = new Graph<ReturnType>(graph);
		Graph<Boolean> graphCopy = new Graph<Boolean>(graph);
		for (int i = 0; i < graphCopy.size(); ++i)
		{
			graphCopy.changeVertex(i, false);
		}
		bfs(graph, vertex, operation, resultGraph, graphCopy);
		return resultGraph;
	}
	
	static private<Type, ReturnType> void dfs(
			Graph<Type> graph,
			int vertex,
			IUnaryOperation<Type, ReturnType> operation,
			Graph<ReturnType> resultGraph,
			Graph<Boolean> graphCopy)
	{
		graphCopy.changeVertex(vertex, true);
		resultGraph.changeVertex(vertex, operation.apply(graph.getVertex(vertex)));
		Vector<Integer> neighbours = graphCopy.getVertexNeighbours(vertex);
		for (int neighbour : neighbours)
		{
			if (!graphCopy.getVertex(neighbour))
			{
				dfs(graph, neighbour, operation, resultGraph, graphCopy);
			}
		}
	}
	
	static private<Type, ReturnType> void bfs(
			Graph<Type> graph,
			int vertex,
			IUnaryOperation<Type, ReturnType> operation,
			Graph<ReturnType> resultGraph,
			Graph<Boolean> graphCopy)
	{
		Queue<Integer> vertexesQueue = new ArrayDeque<Integer>(); 
		vertexesQueue.add(vertex);
		while (!vertexesQueue.isEmpty())
		{
			int vertexNow = vertexesQueue.poll();
			graphCopy.changeVertex(vertexNow, true);
			resultGraph.changeVertex(vertexNow, operation.apply(graph.getVertex(vertexNow)));
			Vector<Integer> neighbours = graphCopy.getVertexNeighbours(vertexNow);
			for (int neighbour : neighbours)
			{
				if (!graphCopy.getVertex(neighbour))
				{
					vertexesQueue.add(neighbour);
				}
			}
		}
	}
}
