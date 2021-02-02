using System;

namespace GenericPoint
{
    // MyGenericClass derives from object, while
    // contained items must be a class implementing IDrawable
    // and must support a default ctor.
    public class MyGenericClass<T> where T : class, IDrawable, new()
    {

    }

    // <K> must extend class and have a default ctor,
    // while <T> must be a structure and implement the
    // generic IComparable interface.
    public class MyGenericClass<K, T> where K : class, new() where T : struct, IComparable<T>
    {

    }
}