using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;

namespace server.BackendApi.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly LangDbContext _context;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(LangDbContext context, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] string name)
        {
            if (name == null) return StatusCode(400, new { message = "Content can not be empty!" });
            try
            {
                AppRole role = new AppRole()
                {
                    Name = name,
                    Description = name + " role",
                    NormalizedName = name,
                };

                await _roleManager.CreateAsync(role);

                return StatusCode(200, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> FindAll()
        {

            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                return StatusCode(200, roles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                return StatusCode(200, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] string name)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                role.Name = name;
                var result = await _roleManager.UpdateAsync(role);

                if(result == IdentityResult.Success)
                    return StatusCode(200, new {message= "Role was updated successfully." });
                return StatusCode(200, new {message= "Cannot update Role" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
              
                var result = await _roleManager.DeleteAsync(role);

                if (result == IdentityResult.Success)
                    return StatusCode(200, new { message = "Role was deleted successfully." });
                return StatusCode(200, new { message = "Cannot delete Role" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
