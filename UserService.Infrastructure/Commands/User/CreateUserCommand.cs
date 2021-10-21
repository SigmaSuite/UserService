using MediatR;

namespace UserService.Infrastructure.Commands.User
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}
