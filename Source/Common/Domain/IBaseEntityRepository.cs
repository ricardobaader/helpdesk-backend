using System.Linq.Expressions;

namespace Common.Domain
{
    public interface IBaseEntityRepository<T> where T : BaseEntity
    {
        Task Commit();
        void DeleteMany(IEnumerable<T> entities);
        void DeleteOne(T entity);
        Task<bool> ExistsBy(Expression<Func<T, bool>> filter);
        Task InsertMany(IEnumerable<T> entities);
        Task InsertOne(T entity);
        Task<IList<TR>> ProjectManyBy<TR>(Expression<Func<T, TR>> project, Expression<Func<T, bool>> filter = null);
        Task<TR> ProjectOneBy<TR>(Expression<Func<T, TR>> project, Expression<Func<T, bool>> filter = null);
        Task<IList<T>> SelectManyBy(Expression<Func<T, bool>> filter = null, bool track = false);
        Task<T> SelectOneBy(Expression<Func<T, bool>> filter = null, bool track = false);
        void UpdateMany(IEnumerable<T> entities);
        void UpdateOne(T entity);
        void ReloadAll(IEnumerable<T> entities);
    }
}
