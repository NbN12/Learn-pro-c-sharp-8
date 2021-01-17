using System.Collections.Generic;

namespace SimpleIndexer
{
    class SomeClass : IStringContainer
    {
        private List<string> myStrings = new List<string>();
        public string this[int index] { get => myStrings[index]; set => myStrings.Insert(index, value); }
    }
}