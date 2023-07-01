namespace Common.Exceptions
{
    [Serializable]
    public class InvalidDataException : Exception
    {
        public InvalidDataException()
        {
        }

        public InvalidDataException(string message)
            : base(message)
        {
        }
    }
}
