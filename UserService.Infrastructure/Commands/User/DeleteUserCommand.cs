using MediatR;

namespace UserService.Infrastructure.Commands.User
{
    public class DeleteUserCommand : IRequest
    {
        public int UserId { get; set; }
    }
}
