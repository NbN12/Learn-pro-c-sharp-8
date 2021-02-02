using System;
using System.Collections.Generic;

namespace SimpleIndexer
{
    // Indexers allow you to access items in an array-like fashion.
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Indexers *****\n");

            PersonCollection myPeople = new PersonCollection();

            // Add objects with indexer syntax.
            myPeople[0] = new Person("Homer", "Simpson", 40);
            myPeople[1] = new Person("Marge", "Simpson", 38);
            myPeople[2] = new Person("Lisa", "Simpson", 9);
            myPeople[3] = new Person("Bart", "Simpson", 7);
            myPeople[4] = new Person("Maggie", "Simpson", 2);

            // Now obtain and display each item using indexer.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }

            UseGenericListOfPeople();

            PersonCollectionStringIndexer myPeopleStrings = new PersonCollectionStringIndexer();

            myPeopleStrings["Homer"] = new Person("Homer", "Simpson", 40);
            myPeopleStrings["Marge"] =
            new Person("Marge", "Simpson", 38);
            // Get "Homer" and print data.
            Person homer = myPeopleStrings["Homer"];

            Console.ReadLine();
        }

        static void UseGenericListOfPeople()
        {
            List<Person> myPeople = new List<Person>();

            myPeople.Add(new Person("Lisa", "Simpson", 9));
            myPeople.Add(new Person("Bart", "Simpson", 7));
            // Change first person with indexer.
            myPeople[0] = new Person("Maggie", "Simpson", 2);
            // Now obtain and display each item using indexer.
            for (int i = 0; i < myPeople.Count; i++)
            {
                Console.WriteLine("Person number: {0}", i);
                Console.WriteLine("Name: {0} {1}", myPeople[i].FirstName, myPeople[i].LastName);
                Console.WriteLine("Age: {0}", myPeople[i].Age);
                Console.WriteLine();
            }
        }
    }
}
