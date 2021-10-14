using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Core.Entities;

namespace UserService.Core.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int userId);
        public Task DeleteUser(int userId);
        public Task<IEnumerable<User>> GetUsers();
        public Task<int> CreateUser(User userToCreate);
    }
}
