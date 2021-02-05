using System;

namespace CarEvents
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