using Common.Domain.Rooms;
using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.SqlServer.Mappings
{
    public class RoomMapping : BaseEntityMapping<Room>
    {
        public RoomMapping(EntityTypeBuilder<Room> builder) : base(builder)
        {
        }

        protected override string TableName => "rooms";

        protected override void MapForeignKeys()
        {
        }

        protected override void MapIndexes()
        {
            Builder.HasIndex(f => new { f.Id, f.IsDeleted }).IsUnique();
        }

        protected override void MapProperties()
        {
            Builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        }
    }
}
