using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Accounts;
using server.Data.Entities;
using server.ViewModel.Catalog.User;

namespace server.BackendApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]UserCreateRequest data)
        {
            var user = await _userService.Create(data);
            if (user is AppUser)
            {
                return StatusCode(200, user);
            }
            else
            {
                return StatusCode(500, user);
            }
        }

        [HttpGet()]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var users = await _userService.FindAll();
                return StatusCode(200, users);

            }catch(Exception ex)
            {
                return StatusCode(500, new {message= $"Some error occurred while retrieving user information. {ex.Message}" });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var user = await _userService.FindOne(id);
                if(user== null)
                {
                    return StatusCode(404, new { message= $"Cannot find User with idUser ={id}"});
                }
                return StatusCode(200, user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Some error occurred while retrieving user information. " });
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id,[FromBody]UserUpdateRequest request)
        {
            try
            {
                var isSucess = await _userService.Update(id,request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot update User with idUser ={id}" });
                }
                return StatusCode(200, new {message = "User was updated successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error updating User " });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(string id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                var isSucess = await _userService.Remove(id);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Cannot remove User with idUser ={id}" });
                }
                return StatusCode(200, new { message = "User was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error removing User " });
            }
        }
    }
}
