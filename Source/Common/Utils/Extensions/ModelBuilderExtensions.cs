using Common.Domain.Rooms;
using Common.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Common.Utils.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(
                new Room { Name = "A1" },
                new Room { Name = "A2" },
                new Room { Name = "B1" },
                new Room { Name = "B2" },
                new Room { Name = "C1" },
                new Room { Name = "C2" },
                new Room { Name = "D1" },
                new Room { Name = "D2" },
                new Room { Name = "E1" },
                new Room { Name = "E2" }
                );

            modelBuilder.Entity<User>().HasData(
                new User("admin", "admin@gmail.com.br", "admin123", UserType.Admin)
                );
        }
    }
}
