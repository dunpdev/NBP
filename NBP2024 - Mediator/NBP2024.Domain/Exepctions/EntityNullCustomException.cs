using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NBP2024.Domain.Exepctions
{
    public class EntityNullCustomException : Exception
    {
        private static string errorMessage = "Entity could not be null!";
        public EntityNullCustomException() : base(errorMessage){ }
        public EntityNullCustomException(string message) : base(message) { }
        public EntityNullCustomException(string message, Exception innerException) : base(message, innerException) { }
        public EntityNullCustomException(SerializationInfo serializationInfo, StreamingContext streamingContext) 
            : base(serializationInfo, streamingContext) { }
    }
}
