using Common.Domain.Tickets;
using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.SqlServer.Mappings
{
    public class TicketMapping : BaseEntityMapping<Ticket>
    {
        public TicketMapping(EntityTypeBuilder<Ticket> builder) : base(builder)
        {
        }

        protected override string TableName => "tickets";

        protected override void MapProperties()
        {
            Builder.Property(x => x.Number).HasColumnName("number").IsRequired().HasIdentityOptions(startValue: 100).ValueGeneratedOnAdd(); 
            Builder.Property(x => x.Title).HasColumnName("title").IsRequired();
            Builder.Property(x => x.Description).HasColumnName("description").IsRequired();
            Builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            Builder.Property(x => x.SupportUserId).HasColumnName("support_user_id").IsRequired(false);
            Builder.Property(x => x.RoomId).HasColumnName("room_id").IsRequired();
            Builder.Property(x => x.Status).HasColumnName("status").IsRequired();
        }

        protected override void MapForeignKeys()
        {
            Builder.HasOne(x => x.User)
               .WithMany(x => x.Tickets)
               .HasForeignKey(x => x.UserId);

            Builder.HasOne(x => x.Room)
               .WithMany(x => x.Tickets)
               .HasForeignKey(x => x.RoomId);

            Builder.HasOne(x => x.SupportUser)
               .WithMany(x => x.UserSupportTickets)
               .HasForeignKey(x => x.SupportUserId);

            Builder.HasMany(x => x.TicketImages);
            Builder.HasMany(x => x.Chats);
        }

        protected override void MapIndexes()
        {
            Builder.HasIndex(f => new { f.Id, f.IsDeleted }).IsUnique();
        }
    }
}
