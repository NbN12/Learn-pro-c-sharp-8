namespace GenericPoint
{
    // Compiler error! Cannot apply
    // operators to type parameters!
    // public class BasicMath<T>
    // {
    //     public T Add(T arg1, T arg2)
    //     => arg1 + arg2;
    //     public T Subtract(T arg1, T arg2)
    //     => arg1 - arg2;
    //     public T Multiply(T arg1, T arg2)
    //     => arg1 * arg2;
    //     public T Divide(T arg1, T arg2)
    //     => arg1 / arg2;
    // }

    // Illustrative code only!
    // public class BasicMath<T> where T : operator +, operator -, operator *, operator /
    // {
    //     public T Add(T arg1, T arg2)
    //     => arg1 + arg2;
    //     public T Subtract(T arg1, T arg2)
    //     => arg1 - arg2;
    //     public T Multiply(T arg1, T arg2)
    //     => arg1 * arg2;
    //     public T Divide(T arg1, T arg2)
    //     => arg1 / arg2;
    // }
}