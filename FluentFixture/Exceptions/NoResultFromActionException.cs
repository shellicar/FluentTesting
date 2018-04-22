using System;
using System.Runtime.Serialization;

namespace FluentFixture.Exceptions
{
    public class NoResultFromActionException : Exception
    {
        public NoResultFromActionException()
        {
        }

        protected NoResultFromActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NoResultFromActionException(string message) : base(message)
        {
        }

        public NoResultFromActionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
