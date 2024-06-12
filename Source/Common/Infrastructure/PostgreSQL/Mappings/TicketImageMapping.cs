using Common.Domain.TicketImages;
using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.SqlServer.Mappings
{
    public class TicketImageMapping : BaseEntityMapping<TicketImage>
    {
        public TicketImageMapping(EntityTypeBuilder<TicketImage> builder) : base(builder)
        {
        }

        protected override string TableName => "ticket_images";

        protected override void MapProperties()
        {
            Builder.Property(x => x.Image).HasColumnName("image").IsRequired();
            Builder.Property(x => x.TicketId).HasColumnName("ticket_id").IsRequired();
        }

        protected override void MapForeignKeys()
        {
            Builder.HasOne(x => x.Ticket)
               .WithMany(x => x.TicketImages)
               .HasForeignKey(x => x.TicketId);
        }

        protected override void MapIndexes()
        {
            Builder.HasIndex(f => new { f.Id, f.IsDeleted }).IsUnique();
        }

    }
}
