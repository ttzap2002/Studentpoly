using System;
using System.Runtime.Serialization;

namespace MonopolyData
{
    [Serializable]
    internal class SomethingGoWrongException : Exception
    {
        public SomethingGoWrongException()
        {
        }

        public SomethingGoWrongException(string? message) : base(message)
        {
        }

        public SomethingGoWrongException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SomethingGoWrongException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}