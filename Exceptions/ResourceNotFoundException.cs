using System.Runtime.Serialization;

namespace SocialMediaApiLastChance.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        // Constructor without parameters
        public ResourceNotFoundException()
        {

        }

        // Constructor with the error message parameter
        public ResourceNotFoundException(string message)
            : base(message)
        {

        }

        // Constructor with the error message and inner exception parameters.
        // This is useful when catching an inner exception and rethrowing it within this custom exception.
        public ResourceNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }

        // Constructor used for serialization of the exception. This is necessary for remoting the exception,
        // and for situations where the exception needs to be reconstituted from a serialized form.
        protected ResourceNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
