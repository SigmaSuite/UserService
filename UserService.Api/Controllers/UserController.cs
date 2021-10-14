using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Core.Entities;
using UserService.Infrastructure.Commands.User;

namespace UserService.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public UserController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetUser(GetUserCommand getUserCommand)
        {
            return Ok(await _Mediator.Send(getUserCommand));
        }

        [HttpGet("/api/v1/user/all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser(GetUsersCommand getUsersCommand)
        {
            return Ok(await _Mediator.Send(getUsersCommand));
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(DeleteUserCommand deleteUserCommand)
        {
            return Ok(await _Mediator.Send(deleteUserCommand));
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateUser(CreateUserCommand createUserCommand)
        {
            return Ok(await _Mediator.Send(createUserCommand));
        }
    }
}
