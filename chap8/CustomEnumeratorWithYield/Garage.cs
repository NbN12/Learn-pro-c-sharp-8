using System;
using System.Collections;

namespace CustomEnumeratorWithYield
{
    // Garage contains a set of Car objects.
    public class Garage : IEnumerable
    {
        private Car[] carArray = new Car[4];

        // Fill with some Car objects upon startup.
        public Garage()
        {
            carArray[0] = new Car("Rusty", 30);
            carArray[1] = new Car("Clunker", 55);
            carArray[2] = new Car("Zippy", 30);
            carArray[3] = new Car("Fred", 30);
        }

        public IEnumerable GetTheCars(bool returnReversed)
        {
            //do some error checking here
            return ActualImplementation();

            IEnumerable ActualImplementation()
            {
                if (returnReversed)
                {
                    for (int i = carArray.Length; i != 0; i--)
                    {
                        yield return carArray[i - 1];
                    }
                }
                else
                {
                    // Return the items as placed in the array.
                    foreach (Car c in carArray)
                    {
                        yield return c;
                    }
                }
            }
        }

        // Return the array object's IEnumerator.
        public IEnumerator GetEnumerator()
        {
            //This will get thrown immediately
            // throw new Exception("This won't get called");
            return ActualImplementation();

            IEnumerator ActualImplementation()
            {
                //this is the local function and the actual IEnumerator implementation
                foreach (var car in carArray)
                {
                    yield return car;
                }
            }
        }

    }
}