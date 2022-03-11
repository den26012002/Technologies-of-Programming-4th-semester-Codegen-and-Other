package mainpackage;

public class CMyClass {
	public native int sum(int a, int b);
	
	static
	{
		System.loadLibrary("MyMathLibrary");
	}
	
	public static void main(String[] args)
	{
		int a = 10;
		int b = 20;
		int c = new CMyClass().sum(a, b);
		System.out.println(c);
	}
}
