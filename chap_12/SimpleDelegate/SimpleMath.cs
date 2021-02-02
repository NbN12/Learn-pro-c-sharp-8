namespace SimpleDelegate
{
    // This delegate can point to any method,
    // taking two integers and returning an integer.
    public delegate int BinaryOp(int x, int y);

    // This class contains methods BinaryOp will
    // point to.
    public class SimpleMath
    {
        // public static int Add(int x, int y) => x + y;
        // public static int Subtract(int x, int y) => x - y;
        public int Add(int x, int y) => x + y;
        public int Subtract(int x, int y) => x - y;

        public static int SquareNumber(int a) => a * a;

    }
}