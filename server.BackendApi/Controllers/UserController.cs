using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Accounts;
using server.Data.Entities;
using server.ViewModel.Catalog.User;

namespace server.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromForm]UserCreateRequest data)
        {
            var user = await _userService.Create(data);
            if (user is AppUser)
            {
                return StatusCode(201, new JsonResult(user));
            }
            else
            {
                return StatusCode(500, user);
            }
        }
    }
}
