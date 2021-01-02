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

        // Return the array object's IEnumerator.
        public IEnumerator GetEnumerator()
        {
            //This will not get thrown until MoveNext() is called
            throw new Exception("This won't get called");
            foreach (var car in carArray)
            {
                yield return car;
            }
        }
    }
}