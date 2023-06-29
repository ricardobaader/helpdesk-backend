using Common.Infrastructure.SqlServer.Common;
using Microsoft.EntityFrameworkCore;

namespace API.Middlewares
{
    public class UnitOfWorkMiddleware
    {
        private readonly RequestDelegate _next;

        public UnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            try
            {
                await _next(context);
                await unitOfWork.Commit();
            }
            catch (DbUpdateException e)
            {
                await unitOfWork.Rollback();
                throw new DbUpdateException("Could not save database update.", e);
            }
            catch (InvalidOperationException e)
            {
                await unitOfWork.Rollback();
                throw new InvalidOperationException("An invalid operation has occurred.", e);
            }
        }
    }
}
