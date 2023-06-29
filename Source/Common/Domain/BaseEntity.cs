using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; private set; }
#pragma warning disable S1104
        [JsonIgnore] public List<string> Errors = new();
#pragma warning restore S1104
        public bool IsValid => Errors.Count == 0;

        protected void SetBaseProperties()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
        }
    }
}
