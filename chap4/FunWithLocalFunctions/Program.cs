using System;

namespace FunWithLocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static int AddWrapperWithStatic(int x, int y)
        {
            //Do some validation here
            return Add(x, y);

            static int Add(int x, int y)
            {
                x += 1;
                return x + y;
            }
        }

        static int AddWrapperWithSideEffect(int x, int y)
        {
            //Do some validation here
            return Add();

            int Add()
            {
                x += 1;
                return x + y;
            }
        }

        static int Add(int x, int y)
        {
            //Do some validation here
            return x + y;
        }

        static int AddWrapper(int x, int y)
        {
            return Add();
            int Add()
            {
                return x + y;
            }
        }
    }
}
