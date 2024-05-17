using Common.Domain.Chats;
using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.SqlServer.Mappings
{
    public class ChatMapping : BaseEntityMapping<Chat>
    {
        public ChatMapping(EntityTypeBuilder<Chat> builder) : base(builder)
        {
        }

        protected override string TableName => "chat_messages";


        protected override void MapProperties()
        {
            Builder.Property(x => x.Message).HasColumnName("message").IsRequired();
            Builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
            Builder.Property(x => x.TicketId).HasColumnName("ticket_id").IsRequired();
        }

        protected override void MapForeignKeys()
        {
            Builder.HasOne(x => x.User)
               .WithMany(x => x.Chats)
               .HasForeignKey(x => x.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            Builder.HasOne(x => x.Ticket)
               .WithMany(x => x.Chats)
               .HasForeignKey(x => x.TicketId)
               .OnDelete(DeleteBehavior.NoAction);
        }

        protected override void MapIndexes()
        {
            Builder.HasIndex(x => new { x.Id, x.IsDeleted }).IsUnique();
        }
    }
}
