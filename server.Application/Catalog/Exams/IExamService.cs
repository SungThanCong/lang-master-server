using server.Data.Entities;
using server.ViewModel.Catalog.Employee;
using server.ViewModel.Catalog.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Exams
{
    public interface IExamService
    {
        public Task<Exam?> Create(ExamCreateRequest request);
        public Task<bool> Update(Guid id, ExamUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Exam>> FindAll();
        public Task<Exam?> FindOne(Guid id);
    }
}
