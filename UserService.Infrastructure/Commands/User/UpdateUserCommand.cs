using MediatR;

namespace UserService.Infrastructure.Commands.User
{
    public class UpdateUserCommand : IRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }

    }
}
