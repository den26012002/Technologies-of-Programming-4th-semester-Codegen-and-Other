package dfs_and_bfs1.graphs;

public interface IUnaryOperation<InputType, ReturnType> {
	ReturnType apply(InputType value);
}
