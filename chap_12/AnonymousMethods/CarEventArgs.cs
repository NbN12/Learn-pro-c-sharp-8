using System;

namespace AnonymousMethods
{
    public class CarEventArgs : EventArgs
    {
        public readonly string _msg;

        public CarEventArgs(string msg)
        {
            _msg = msg;
        }

    }
}