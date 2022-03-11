package dfs_and_bfs1.graphs;

public class ToStringOperation<Type> implements IUnaryOperation<Type, String>{

	@Override
	public String apply(Type value) {
		return value.toString();
	}

}
