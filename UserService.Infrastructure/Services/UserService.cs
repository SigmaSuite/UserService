using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Core.Entities;
using UserService.Core.MessageBroker.Interfaces;
using UserService.Core.Repositories.Interfaces;
using UserService.Infrastructure.Commands.User;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _Mapper;
        private readonly IMessagePublisher _MessagePublisher;

        public UserService(IUserRepository userRepository, IMapper mapper, IMessagePublisher messagePublisher)
        {
            _UserRepository = userRepository;
            _Mapper = mapper;
            _MessagePublisher = messagePublisher;
        }

        public async Task<int> CreateUser(CreateUserCommand createUserCommand)
        {
            _MessagePublisher.Publish("CreatingUser");
            return await _UserRepository.CreateUser(_Mapper.Map<CreateUserCommand, User>(createUserCommand));
        }

        public async Task DeleteUser(DeleteUserCommand deleteUserCommand)
        {
            await _UserRepository.DeleteUser(deleteUserCommand.UserId);
        }

        public async Task<User> GetUser(GetUserCommand getUserCommand)
        {
            return await _UserRepository.GetUser(getUserCommand.UserId);
        }

        public async Task<IEnumerable<User>> GetUsers(GetUsersCommand getUsersCommand)
        {
            return await _UserRepository.GetUsers();
        }
    }
}
