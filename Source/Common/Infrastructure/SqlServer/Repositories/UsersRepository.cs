using Common.Domain.Users;
using Common.Infrastructure.SqlServer.Common;
using Common.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure.SqlServer.Repositories
{
    internal class UsersRepository : BaseEntityRepository<User>, IUsersRepository
    {
        public UsersRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ListUsersDto>> ListUsers()
        {
            return await Entity.Where(x => !x.IsDeleted).AsNoTracking().Select(x => new ListUsersDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Role = x.UserType.GetDescription()
            }).ToListAsync(); ;
        }
    }
}
