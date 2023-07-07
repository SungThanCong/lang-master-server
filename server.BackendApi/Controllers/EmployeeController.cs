using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Application.Catalog.Bills;
using server.Application.Catalog.Employees;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using server.ViewModel.Catalog.Employee;
using System.Data;

namespace server.BackendApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeeService;
        public readonly LangDbContext _context;


        public EmployeeController(IEmployeeService employeeService, LangDbContext context)
        {
            _employeeService = employeeService;
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Create([FromForm] EmployeeCreateRequest data)
        {
            try
            {
                var employee = await _employeeService.Create(data);
                if (employee is Employee)
                {
                    var result = new { idEmployee = employee.IdEmployee, idUser=employee.IdUser, user=employee.User };
                    return StatusCode(200, result);
                }
                else
                {
                    return StatusCode(500, employee);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> FindAll()
        {
            try
            {
                var employees = await _employeeService.FindAll();
                if(employees is null)
                    return StatusCode(200);

                return StatusCode(200,employees);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "admin, employee")]
        public async Task<ActionResult> FindOne(string id)
        {
            try
            {
                var employee = await _employeeService.FindOne(new Guid(id));
                if(employee != null)
                {
                    var result = new { idEmployee = employee.IdEmployee, idUser = employee.IdUser, user = employee.User };
                
                    return StatusCode(200, result);

                }return StatusCode(404,new { message="Not find"});

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Update(string id, [FromBody] EmployeeUpdateRequest request)
        {
            try
            {
                var isSucess = await _employeeService.Update(new Guid(id), request);
                if (!isSucess)
                {
                    return StatusCode(500, new { message = $"Error updating" });
                }
                return StatusCode(200, new { message = "Employee was updated successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Remove(string id)
        {
            try
            {
                var isSuccess = await _employeeService.Remove(new Guid(id));
                if (!isSuccess)
                {
                    return StatusCode(500, new { message = $"Cannot remove" });
                }
                return StatusCode(200, new { message = "Employee was removed successfully." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
