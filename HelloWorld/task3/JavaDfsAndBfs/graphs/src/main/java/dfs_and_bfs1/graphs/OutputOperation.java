package dfs_and_bfs1.graphs;

public class OutputOperation<Type> implements IUnaryOperation<Type, Void> {

	@Override
	public Void apply(Type value) {
		System.out.println(value);
		return null;
	}
}
