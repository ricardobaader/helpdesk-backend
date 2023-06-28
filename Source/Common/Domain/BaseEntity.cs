namespace Common.Domain
{
    public class BaseEntity
    {
        public bool IsDeleted { get; private set; }

        protected void SetBaseProperty() => IsDeleted = true;
    }
}
