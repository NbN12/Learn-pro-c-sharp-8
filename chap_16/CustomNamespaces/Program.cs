using System;
using CustomNamespaces.MyShapes;
using CustomNamespaces.My3DShapes;

// Resolve the ambiguity using a custom alias.
using The3DHexagon = CustomNamespaces.My3DShapes.Hexagon;

using bfHome = System.Runtime.Serialization.Formatters.Binary;

namespace CustomNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // Resolved the ambiguity.
            // My3DShapes.Hexagon hexagon = new My3DShapes.Hexagon();
            // My3DShapes.Circle circle = new My3DShapes.Circle();
            // My3DShapes.Square square = new My3DShapes.Square();

            // This is really creating a My3DShapes.Hexagon class.
            The3DHexagon h2 = new The3DHexagon();
            // ...

            bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();
        }
    }
}
