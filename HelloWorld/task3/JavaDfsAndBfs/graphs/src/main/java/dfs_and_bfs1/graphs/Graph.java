package dfs_and_bfs1.graphs;
import java.util.*;

public class Graph<Type> {
	public Graph(int size)
	{
		vertexes = new ArrayList<Type>(size);
		edges = new ArrayList<Vector<Integer>>(size);
		for (int i = 0; i < size; ++i)
		{
			vertexes.add(null);
			edges.add(new Vector<Integer>());
		}
	}
	
	public<AnotherType> Graph(Graph<AnotherType> graph)
	{
		vertexes = new ArrayList<Type>(graph.vertexes.size());
		edges = new ArrayList<Vector<Integer>>(graph.edges);
		for (int i = 0; i < graph.vertexes.size(); ++i)
		{
			vertexes.add(null);
		}
	}
	
	public Type getVertex(int number)
	{
		return vertexes.get(number);
	}
	
	public void changeVertex(int number, Type newValue)
	{
		vertexes.set(number, newValue);
	}
	
	public void addEdge(int fromVertex, int toVertex)
	{
		edges.get(fromVertex).add(toVertex);
		edges.get(toVertex).add(fromVertex);
	}
	
	public Vector<Integer> getVertexNeighbours(int number)
	{
		return edges.get(number);
	}
	
	public int size()
	{
		return vertexes.size();
	}
	
	private ArrayList<Type> vertexes;
	private ArrayList<Vector<Integer>> edges; 
}