namespace Common.Infrastructure.SqlServer.Common
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        Task Rollback();
    }
}
