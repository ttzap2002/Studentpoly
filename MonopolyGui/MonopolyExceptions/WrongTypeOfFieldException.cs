using System;
using System.Runtime.Serialization;

namespace MonopolyGui
{

    public class WrongTypeOfFieldException : Exception
    {
        public WrongTypeOfFieldException()
        {
        }

        public WrongTypeOfFieldException(string? message) : base(message)
        {
        }

        public WrongTypeOfFieldException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WrongTypeOfFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}