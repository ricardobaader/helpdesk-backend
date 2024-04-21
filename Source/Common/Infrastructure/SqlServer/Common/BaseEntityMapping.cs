using Common.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Common.Infrastructure.SqlServer.Common
{
    public abstract class BaseEntityMapping<T> where T : BaseEntity
    {
        protected readonly EntityTypeBuilder<T> Builder;

        protected BaseEntityMapping(EntityTypeBuilder<T> builder)
        {
            Builder = builder;

            Map();
        }

        protected abstract string TableName { get; }
        protected abstract void MapProperties();
        protected abstract void MapIndexes();
        protected abstract void MapForeignKeys();

        private void Map()
        {
            MapTableName();
            MapBaseProperties();
            MapPrimaryKey();

            MapProperties();
            MapIndexes();
            MapForeignKeys();
        }

        private void MapTableName() => Builder.ToTable(TableName);

        private void MapBaseProperties()
        {
            Builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            Builder.Property(x => x.IsDeleted).HasColumnName("is_deleted").IsRequired();
            Builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
            Builder.Ignore(x => x.Errors);
        }

        private void MapPrimaryKey() => Builder.HasKey(x => x.Id);
    }
}
