using server.Data.Entities;
using server.ViewModel.Catalog.Employee;
using server.ViewModel.Catalog.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Lecturers
{
    public interface ILecturerService
    {
        public Task<Lecturer?> Create(LecturerCreateRequest request);
        public Task<bool> Update(Guid id, LecturerUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Lecturer>> FindAll();
        public Task<Lecturer?> FindOne(Guid id);
    }
}
