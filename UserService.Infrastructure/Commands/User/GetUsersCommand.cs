using MediatR;
using System.Collections.Generic;

namespace UserService.Infrastructure.Commands.User
{
    public class GetUsersCommand : IRequest<IEnumerable<Core.Entities.User>>
    {
    }
}
