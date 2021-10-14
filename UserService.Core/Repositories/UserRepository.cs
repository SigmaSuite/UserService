using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Core.DbContexts;
using UserService.Core.Entities;
using UserService.Core.Repositories.Interfaces;

namespace UserService.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<UserServiceDbContext> _DbContextFactory;

        public UserRepository(IDbContextFactory<UserServiceDbContext> dbContextFactory)
        {
            _DbContextFactory = dbContextFactory;
        }

        public async Task<int> CreateUser(User userToCreate)
        {
            using (var context = _DbContextFactory.CreateDbContext())
            {
                await context.AddAsync(userToCreate);
                await context.SaveChangesAsync();
            }
            return userToCreate.Id;
        }

        public async Task DeleteUser(int userId)
        {
            using (var context = _DbContextFactory.CreateDbContext())
            {
                var userToDelete = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                context.Users.Remove(userToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUser(int userId)
        {
            using (var context = _DbContextFactory.CreateDbContext())
                return await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (var context = _DbContextFactory.CreateDbContext())
                return await context.Users.ToListAsync();
        }
    }
}
