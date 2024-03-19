
namespace SmartProject.Domain.Common
{
	public static class Guard
	{
        public static void AgainstEmptyString(string value, string name = "Value")
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            throw new ArgumentException($"{name} cannot be null or empty.");
        }

        public static void ForStringLength(string value, int minLength, int maxLength, string name = "Value")
        {
            AgainstEmptyString(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            throw new ArgumentException($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void AgainstOutOfRange(int number, int min, int max, string name = "Value")
        {
            if (min <= number && number <= max)
            {
                return;
            }

            throw new ArgumentException($"{name} must be between {min} and {max}.");
        }

        public static void AgainstOutOfRange(decimal number, decimal min, decimal max, string name = "Value")
        {
            if (min <= number && number <= max)
            {
                return;
            }

            throw new ArgumentException($"{name} must be between {min} and {max}.");
        }

        public static void ForValidUrl(string url, string name = "Value")
        {
            if (url.Length <= Constants.Common.MaxUrlLength &&
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            throw new ArgumentException($"{name} must be a valid URL.");
        }
    }    
}

