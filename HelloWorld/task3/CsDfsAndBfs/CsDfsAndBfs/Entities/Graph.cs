using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsDfsAndBfs.Entities
{
    public class Graph<Type>
    {
		public Graph(int size)
		{
			vertexes = new List<Type>(size);
			edges = new List<List<int>>(size);
			for (int i = 0; i < size; ++i)
			{
				vertexes.Add(default);
				edges.Add(new List<int>(size));
			}
		}

		public void ConstructByGraph<AnotherType>(Graph<AnotherType> graph)
		{
			vertexes = new List<Type>(graph.vertexes.Count);
			edges = new List<List<int>>(graph.edges);
			for (int i = 0; i < graph.vertexes.Count; ++i)
			{
				vertexes.Add(default);
			}
		}

		public Type GetVertex(int number)
		{
			return vertexes[number];
		}

		public void ChangeVertex(int number, Type newValue)
		{
			vertexes[number] = newValue;
		}

		public void AddEdge(int fromVertex, int toVertex)
		{
			edges[fromVertex].Add(toVertex);
			edges[toVertex].Add(fromVertex);
		}

		public List<int> GetVertexNeighbours(int number)
		{
			return edges[number];
		}

		public int Size()
		{
			return vertexes.Count;
		}

		private List<Type> vertexes;
        private List<List<int>> edges;
    }
}
