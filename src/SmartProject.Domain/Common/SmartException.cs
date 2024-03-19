
namespace SmartProject.Domain.Common
{
    public class SmartException : Exception
    {
        public SmartException(string message)
            : base(message)
        {
        }

        public SmartException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}

