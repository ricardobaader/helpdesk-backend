namespace Common.Exceptions
{
    public class ActiveObjectException : Exception
    {
        public ActiveObjectException()
        {
        }

        public ActiveObjectException(string message)
            : base(message)
        {
        }
    }
}
