using server.Data.Entities;
using server.ViewModel.Catalog.Employee;
using server.ViewModel.Catalog.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Employees
{
    public interface IEmployeeService
    {
        public Task<Employee?> Create(EmployeeCreateRequest request);
        public Task<bool> Update(Guid id, EmployeeUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Employee>> FindAll();
        public Task<Employee?> FindOne(Guid id);
    }
}
