using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Employees
{
    public class EmployeeService : IEmployeeService
    {
        LangDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployeeService(LangDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Employee?> Create(EmployeeCreateRequest request)
        {
            try
            {
                AppUser appUser = new AppUser()
                {
                    UserName = request.Username,
                    Email = request.Email,
                    DisplayName = request.DisplayName,
                    Dob = request.Dob,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    ImageUrl = request.ImageUrl,
                    IsActivated = true,
                };
                var result = await _userManager.CreateAsync(appUser, request.Password);
                if (result == IdentityResult.Success)
                {
                    await _userManager.AddToRoleAsync(appUser, "employee");

                    Employee employee = new Employee()
                    {
                        IdUser = appUser.Id,
                        IsDeleted = false,

                    };
                    await _context.Employees.AddAsync(employee);
                    var success = await _context.SaveChangesAsync();
                    if (success > 0)
                    {
                        return employee;
                    }
                  
                }
               
            }
            catch(Exception ex)
            {
                return null;
            }
          
            return null;
        }

        public async Task<List<Employee>> FindAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> FindOne(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.User.IsActivated = false;
                employee.IsDeleted = true;
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(Guid id, EmployeeUpdateRequest request)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                employee.User.DisplayName = request.DisplayName;
                employee.User.Gender = request.Gender;
                employee.User.PhoneNumber = request.PhoneNumber ;
                employee.User.ImageUrl = request.ImageUrl;
                employee.User.Address = request.Address;
                employee.User.Dob = request.Dob;

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
