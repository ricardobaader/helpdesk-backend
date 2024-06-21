using System.Text.Json.Serialization;

namespace Common.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastUpdatedAt { get; private set; }

        public bool IsDeleted { get; private set; }

        [JsonIgnore]
        public List<string> Errors = new();

        public bool IsValid => Errors.Count == 0;

        protected void SetBaseProperties()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            LastUpdatedAt = CreatedAt;
            IsDeleted = false;
        }

        protected void SetUpdate()
            => LastUpdatedAt = DateTime.UtcNow;

        public void SetDelete()
        {
            LastUpdatedAt = DateTime.UtcNow;
            IsDeleted = true;
        }

        public void UpdateId(Guid id) => Id = id;
    }
}
