using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Commands.User.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserService _UserService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _UserService = userService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _UserService.CreateUser(request);
        }
    }
}
