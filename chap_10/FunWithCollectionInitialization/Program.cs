using System;
using System.Collections;
using System.Collections.Generic;

namespace FunWithCollectionInitialization
{
    // https://stackoverflow.com/questions/4936941/using-a-using-alias-class-with-generic-types
    using PointsList = List<Point>;
    using Rectangles = List<Rectangle>;
    class Program
    {
        static void Main(string[] args)
        {

            // Init a standard array.
            int[] myArrayOfInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Init a generic List<> of ints
            List<int> myGenericList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Init an ArrayList with numerial data.
            ArrayList myList = new ArrayList { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            PointsList myListOfPoints = new PointsList
            {
                new Point{X = 2, Y = 2},
                new Point{X = 3, Y = 3},
                new Point{X = 4, Y = 4}
            };

            foreach (var pt in myListOfPoints)
            {
                pt.DisplayStats();
            }

        }
    }
}
