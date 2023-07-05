using server.Data.Entities;
using server.ViewModel.Catalog.Employee;
using server.ViewModel.Catalog.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Students
{
    public interface IStudentService
    {
        public Task<Student?> Create(StudentCreateRequest request);
        public Task<bool> Update(Guid id, StudentUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Student>> FindAll();
        public Task<Student?> FindOne(Guid id);
        public Task<List<Student>> FindByIdClass(Guid idClass);
        public Task<bool> UpdateScore(List<Testing> testings);
    }
}
