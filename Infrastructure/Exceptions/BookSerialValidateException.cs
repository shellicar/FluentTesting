using System;
using System.Runtime.Serialization;

namespace Infrastructure.Exceptions
{
    public class BookSerialValidateException : Exception
    {
        public BookSerialValidateException()
        {
        }

        public BookSerialValidateException(string message) : base(message)
        {
        }

        public BookSerialValidateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BookSerialValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}