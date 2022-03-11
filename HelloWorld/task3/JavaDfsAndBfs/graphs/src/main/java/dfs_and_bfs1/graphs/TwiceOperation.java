package dfs_and_bfs1.graphs;

public class TwiceOperation implements IUnaryOperation<Integer, Integer> {

	@Override
	public Integer apply(Integer value) {
		return value * 2;
	}

}
