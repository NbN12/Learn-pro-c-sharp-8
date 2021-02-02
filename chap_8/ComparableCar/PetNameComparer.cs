using System.Collections;
using System;

namespace ComparableCar
{
    public class PetNameComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Car c1 && x is Car c2)
            {
                return string.Compare(c1.PetName, c2.PetName, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                throw new ArgumentException("Parameter is not a Car!");
            }
        }
    }
}