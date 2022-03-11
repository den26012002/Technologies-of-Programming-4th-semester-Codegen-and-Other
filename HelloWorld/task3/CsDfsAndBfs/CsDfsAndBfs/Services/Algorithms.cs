using System.Collections.Generic;
using CsDfsAndBfs.Entities;
using CsDfsAndBfs.Tools;

namespace CsDfsAndBfs.Services
{
    public class Algorithms
    {
		static public Graph<ReturnType> Dfs<Type, ReturnType>(
			Graph<Type> graph,
			int vertex,
			IUnaryOperation<Type, ReturnType> operation)
		{
			var resultGraph = new Graph<ReturnType>(graph.Size());
			resultGraph.ConstructByGraph(graph);
			var graphCopy = new Graph<bool>(graph.Size());
			graphCopy.ConstructByGraph(graph);
			for (int i = 0; i < graphCopy.Size(); ++i)
			{
				graphCopy.ChangeVertex(i, false);
			}
			Dfs(graph, vertex, operation, resultGraph, graphCopy);
			return resultGraph;
		}

		static public Graph<ReturnType> Bfs<Type, ReturnType>(
				Graph<Type> graph,
				int vertex,
				IUnaryOperation<Type, ReturnType> operation)
		{
			var resultGraph = new Graph<ReturnType>(graph.Size());
			resultGraph.ConstructByGraph(graph);
			var graphCopy = new Graph<bool>(graph.Size());
			graphCopy.ConstructByGraph(graph);
			for (int i = 0; i < graphCopy.Size(); ++i)
			{
				graphCopy.ChangeVertex(i, false);
			}
			Bfs(graph, vertex, operation, resultGraph, graphCopy);
			return resultGraph;
		}

		static private void Dfs<Type, ReturnType>(
				Graph<Type> graph,
				int vertex,
				IUnaryOperation<Type, ReturnType> operation,
				Graph<ReturnType> resultGraph,
				Graph<bool> graphCopy)
		{
			graphCopy.ChangeVertex(vertex, true);
			resultGraph.ChangeVertex(vertex, operation.Apply(graph.GetVertex(vertex)));
			var neighbours = graphCopy.GetVertexNeighbours(vertex);
			foreach (int neighbour in neighbours)
			{
				if (!graphCopy.GetVertex(neighbour))
				{
					Dfs(graph, neighbour, operation, resultGraph, graphCopy);
				}
			}
		}

		static private void Bfs<Type, ReturnType>(
				Graph<Type> graph,
				int vertex,
				IUnaryOperation<Type, ReturnType> operation,
				Graph<ReturnType> resultGraph,
				Graph<bool> graphCopy)
		{
			var vertexesQueue = new Queue<int>();
			vertexesQueue.Enqueue(vertex);
			while (vertexesQueue.Count != 0)
			{
				int vertexNow = vertexesQueue.Dequeue();
				graphCopy.ChangeVertex(vertexNow, true);
				resultGraph.ChangeVertex(vertexNow, operation.Apply(graph.GetVertex(vertexNow)));
				var neighbours = graphCopy.GetVertexNeighbours(vertexNow);
				foreach (int neighbour in neighbours)
				{
					if (!graphCopy.GetVertex(neighbour))
					{
						vertexesQueue.Enqueue(neighbour);
					}
				}
			}
		}
	}
}
