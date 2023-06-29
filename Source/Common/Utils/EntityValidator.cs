namespace Common.Utils
{
    public class EntityValidator
    {
        private readonly List<string> _errors = new();

        public static EntityValidator New() => new();

        public List<string> GetErrors() => _errors;

        public EntityValidator Requiring(string value, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(value))
                _errors.Add(errorMessage);

            return this;
        }

        public EntityValidator Requiring<T>(T value, string errorMessage)
        {
            if (value.Equals(default(T)))
                _errors.Add(errorMessage);

            return this;
        }

        public EntityValidator When(bool condition, string errorMessage)
        {
            if (condition)
                _errors.Add(errorMessage);

            return this;
        }
    }
}
