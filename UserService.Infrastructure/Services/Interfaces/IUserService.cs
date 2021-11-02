using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Core.Entities;
using UserService.Infrastructure.Commands.User;

namespace UserService.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetUser(GetUserCommand getUserCommand);
        public Task DeleteUser(DeleteUserCommand deleteUserCommand);
        public Task<IEnumerable<User>> GetUsers(GetUsersCommand getUsersCommand);
        public Task<int> CreateUser(CreateUserCommand createUserCommand);
        public Task UpdateUser(UpdateUserCommand updateUserCommand);
    }
}
