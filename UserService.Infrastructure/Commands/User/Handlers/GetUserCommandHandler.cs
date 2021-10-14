using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Commands.User.Handlers
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, Core.Entities.User>
    {
        private readonly IUserService _UserService;

        public GetUserCommandHandler(IUserService userService)
        {
            _UserService = userService;
        }

        public async Task<Core.Entities.User> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await _UserService.GetUser(request);
        }
    }
}
