using Microsoft.EntityFrameworkCore;
using UserService.Core.DbContexts.Interfaces;

namespace UserService.Core.DbContexts
{
    public class UserServiceDbContextFactory : IDbContextFactory<UserServiceDbContext>
    {
        private readonly IUserServiceDbConnectionStringProvider _UserServiceDbConnectionStringProvider;

        public UserServiceDbContextFactory(IUserServiceDbConnectionStringProvider userServiceDbConnectionStringProvider)
        {
            _UserServiceDbConnectionStringProvider = userServiceDbConnectionStringProvider;
        }

        public UserServiceDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
            optionsBuilder.UseNpgsql(_UserServiceDbConnectionStringProvider.Get());
            return new UserServiceDbContext(optionsBuilder.Options);
        }

        public UserServiceDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
            optionsBuilder.UseNpgsql(_UserServiceDbConnectionStringProvider.Get());
            return new UserServiceDbContext(optionsBuilder.Options);
        }
    }
}
