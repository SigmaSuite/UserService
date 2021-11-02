using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Commands.User.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserService _UserService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _UserService = userService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _UserService.UpdateUser(request);
            return new Unit();
        }
    }
}
