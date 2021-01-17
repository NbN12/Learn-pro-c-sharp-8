namespace GenericPoint
{
    // A generic Point structure.
    public struct Point<T>
    {
        private T _xPos;
        private T _yPos;

        public Point(T xPos, T yPos)
        {
            _xPos = xPos;
            _yPos = yPos;
        }

        public T XPos { get => _xPos; set => _xPos = value; }
        public T YPos { get => _yPos; set => _yPos = value; }

        public override string ToString() => $"[{_xPos}, {_yPos}]";

        // Reset fields to the default value of the type parameter.
        // The "default" keyword is overloaded in C#.
        // When used with generics, it represents the default
        // value of a type parameter.
        public void ResetPoint()
        {
            _xPos = default;
            _yPos = default;
        }
    }
}