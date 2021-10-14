using MediatR;

namespace UserService.Infrastructure.Commands.User
{
    public class GetUserCommand : IRequest<Core.Entities.User>
    {
        public int UserId { get; set; }
    }
}
