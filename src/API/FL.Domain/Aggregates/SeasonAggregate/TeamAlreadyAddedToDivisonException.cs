using System;
using System.Runtime.Serialization;

namespace FL.Domain.Aggregates.SeasonAggregate
{
    [Serializable]
    public class TeamAlreadyAddedToDivisonException : Exception
    {
        public TeamAlreadyAddedToDivisonException()
        {
        }

        public TeamAlreadyAddedToDivisonException(string message)
            : base(message)
        {
        }

        public TeamAlreadyAddedToDivisonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected TeamAlreadyAddedToDivisonException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}