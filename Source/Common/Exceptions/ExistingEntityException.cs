namespace Common.Exceptions
{
    public class ExistingEntityException : Exception
    {
        public ExistingEntityException()
        {
        }

        public ExistingEntityException(string message)
            : base(message)
        {
        }
    }
}
