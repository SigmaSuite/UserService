using Microsoft.EntityFrameworkCore;
using UserService.Core.Entities;

namespace UserService.Core.DbContexts
{
    public class UserServiceDbContext : DbContext
    {
        public DbSet<User> Users;

        public UserServiceDbContext()
        {

        }
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "user");
        }
    }
}
