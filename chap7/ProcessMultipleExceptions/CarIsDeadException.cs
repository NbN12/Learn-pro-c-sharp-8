using System;
using System.Runtime.Serialization;

namespace ProcessMultipleExceptions
{
    // This custom exception describes the details of the car-is-dead condition.
    // (Remember, you can also simply extend Exception.)
    [Serializable]
    public class CarIsDeadException : ApplicationException
    {
        public DateTime ErrorTimeStamp { get; set; }
        public string CauseOfError { get; set; }

        public CarIsDeadException() { }
        public CarIsDeadException(string cause, DateTime time)
        : this(cause, time, string.Empty) { }
        public CarIsDeadException(string cause, DateTime time, string message)
        : this(cause, time, message, null) { }
        public CarIsDeadException(string cause, DateTime time, string message, Exception inner) :
        base(message, inner)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

        protected CarIsDeadException(string cause, DateTime time, SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
            CauseOfError = cause;
            ErrorTimeStamp = time;
        }

    }
}