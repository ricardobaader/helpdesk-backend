using Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Common.Infrastructure.SqlServer.Common
{
    public class BaseEntityRepository<T> : IBaseEntityRepository<T> where T : BaseEntity
    {
        protected readonly DatabaseContext Context;
        protected readonly DbSet<T> Entity;

        public BaseEntityRepository(DatabaseContext context)
        {
            Context = context;
            Entity = Context.Set<T>();
        }

        public async Task Commit() => await Context.SaveChangesAsync();

        public virtual void DeleteMany(IEnumerable<T> entities) => UpdateMany(entities);

        public virtual void DeleteOne(T entity) => UpdateOne(entity);

        public virtual async Task<bool> ExistsBy(Expression<Func<T, bool>> filter) =>
            await Entity.AsNoTracking().AnyAsync(filter);

        public virtual async Task InsertMany(IEnumerable<T> entities) => await Entity.AddRangeAsync(entities);

        public virtual async Task InsertOne(T entity) => await Entity.AddAsync(entity);

        public virtual async Task<IList<TR>> ProjectManyBy<TR>(
            Expression<Func<T, TR>> project, Expression<Func<T, bool>> filter = null) =>
            filter == null
                ? await Entity.AsNoTracking().Select(project).ToListAsync()
                : await Entity.AsNoTracking().Where(filter).Select(project).ToListAsync();

        public virtual async Task<TR> ProjectOneBy<TR>(
            Expression<Func<T, TR>> project, Expression<Func<T, bool>> filter = null) =>
            filter == null
                ? await Entity.AsNoTracking().Select(project).SingleOrDefaultAsync()
                : await Entity.AsNoTracking().Where(filter).Select(project).SingleOrDefaultAsync();

        public virtual async Task<IList<T>> SelectManyBy(Expression<Func<T, bool>> filter = null, bool track = false)
        {
            return filter == null
                ? track
                    ? await Entity.ToListAsync()
                    : await Entity.AsNoTracking().ToListAsync()
                : track
                    ? await Entity.Where(filter).ToListAsync()
                    : await Entity.AsNoTracking().Where(filter).ToListAsync();
        }

        public virtual async Task<T> SelectOneBy(Expression<Func<T, bool>> filter = null, bool track = false) =>
            filter == null
                ? track
                    ? await Entity.SingleOrDefaultAsync()
                    : await Entity.AsNoTracking().SingleOrDefaultAsync()
                : track
                    ? await Entity.SingleOrDefaultAsync(filter)
                    : await Entity.AsNoTracking().SingleOrDefaultAsync(filter);

        public virtual void UpdateMany(IEnumerable<T> entities) => Entity.UpdateRange(entities);

        public virtual void UpdateOne(T entity) => Entity.Update(entity);

        public void ReloadAll(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
                Context.Entry(entity).Reload();
        }
    }
}
