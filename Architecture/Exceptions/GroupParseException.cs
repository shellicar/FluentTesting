using System;
using System.Runtime.Serialization;

namespace Architecture.Exceptions
{
    public class GroupParseException : BookSerialValidateException
    {
        public GroupParseException()
        {
        }

        public GroupParseException(string message) : base(message)
        {
        }

        public GroupParseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GroupParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}