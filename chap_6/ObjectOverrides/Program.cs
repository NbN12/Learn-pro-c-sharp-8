using System;

namespace ObjectOverrides
{

    class Person
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string SSN { get; } = "";
        public Person(string fName, string lName, int personAge, string ssn)
        {
            FirstName = fName;
            LastName = lName;
            Age = personAge;
            SSN = ssn;
        }
        public Person() { }
        public override string ToString() => $"[First Name: {FirstName}; Last Name: {LastName}; Age:{Age}]";

        // public override bool Equals(object obj)
        // {
        //     if (!(obj is Person temp))
        //     {
        //         return false;
        //     }

        //     if (temp.FirstName == this.FirstName && temp.LastName == this.LastName && temp.Age == this.Age)
        //         return true;
        //     return false;
        // }

        public override bool Equals(object obj)
         => obj?.ToString() == ToString();

        public override int GetHashCode() => SSN.GetHashCode();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with System.Object *****\n");

            Person p1 = new Person("Homer", "Simpson", 50, "111-11-1111");
            Person p2 = new Person("Homer", "Simpson", 50, "111-11-1111");
            // Get stringified version of objects.
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            // Test overridden Equals().
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));
            // Test hash codes.
            //still using the hash of the SSN
            Console.WriteLine("Same hash codes?: {0}", p1.GetHashCode() == p2.GetHashCode());
            Console.WriteLine();
            // Change age of p2 and test again.
            p2.Age = 45;
            Console.WriteLine("p1.ToString() = {0}", p1.ToString());
            Console.WriteLine("p2.ToString() = {0}", p2.ToString());
            Console.WriteLine("p1 = p2?: {0}", p1.Equals(p2));
            //still using the hash of the SSN
            Console.WriteLine("Same hash codes?: {0}", p1.GetHashCode() == p2.GetHashCode());

            Person p3 = new Person("Sally", "Jones", 4, "333-333");
            Person p4 = new Person("Sally", "Jones", 4, "333-333");
            Console.WriteLine("P3 and P4 have same state: {0}", object.Equals(p3, p4));
            Console.WriteLine("P3 and P4 are pointing to same object: {0}",
            object.ReferenceEquals(p3, p4));

            Console.ReadLine();
        }
    }
}
