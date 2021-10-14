using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Commands.User.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserService _UserService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _UserService = userService;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _UserService.DeleteUser(request);
            return new Unit();
        }
    }
}
