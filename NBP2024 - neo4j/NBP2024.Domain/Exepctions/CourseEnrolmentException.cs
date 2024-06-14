using System.Runtime.Serialization;

namespace NBP2024.Domain.Exepctions
{
    public class CourseEnrolmentException : Exception
    {
        private static string errorMessage = "Course is not free, so you cannot enrol";
        public CourseEnrolmentException() : base(errorMessage) { }
        public CourseEnrolmentException(string message) : base(message) { }
        public CourseEnrolmentException(string message, Exception innerException) : base(message, innerException) { }
        public CourseEnrolmentException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext) { }

    }
}
