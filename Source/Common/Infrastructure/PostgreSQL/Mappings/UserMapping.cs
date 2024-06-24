using Common.Domain.Users;
using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.SqlServer.Mappings
{
    public class UserMapping : BaseEntityMapping<User>
    {
        public UserMapping(EntityTypeBuilder<User> builder) : base(builder)
        {
        }

        protected override string TableName => "users";

        protected override void MapProperties()
        {
            Builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            Builder.Property(x => x.Email).HasColumnName("email").IsRequired();
            Builder.Property(x => x.UserType).HasColumnName("userType").IsRequired();
        }

        protected override void MapForeignKeys()
        {
            Builder.HasMany(x => x.Tickets);
            Builder.HasMany(x => x.UserSupportTickets);
            Builder.HasMany(x => x.Chats);
        }

        protected override void MapIndexes()
        {
            Builder.HasIndex(f => new { f.Id, f.IsDeleted }).IsUnique();
        }
    }
}
