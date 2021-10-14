using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Commands.User.Handlers
{
    public class GetUsersCommandHandler : IRequestHandler<GetUsersCommand, IEnumerable<Core.Entities.User>>
    {
        private readonly IUserService _UserSerivce;

        public GetUsersCommandHandler(IUserService userSerivce)
        {
            _UserSerivce = userSerivce;
        }

        public async Task<IEnumerable<Core.Entities.User>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            return await _UserSerivce.GetUsers(request);
        }
    }
}
