using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FluentFixture.Exceptions
{
    public class TestFailedException : Exception
    {
        public TestFailedException()
        {
        }

        protected TestFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TestFailedException(string message) : base(message)
        {
        }

        public TestFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
