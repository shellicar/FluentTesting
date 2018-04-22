using System;
using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    public class GroupCountException : BookSerialValidateException
    {
        public GroupCountException()
        {
        }

        public GroupCountException(string message) : base(message)
        {
        }

        public GroupCountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GroupCountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}