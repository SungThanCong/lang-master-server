using server.Data.Entities;
using server.ViewModel.Catalog.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Attendances
{
    public interface IAttendanceService
    {
        public Task<Attendance?> Create(AttendanceCreateRequest request);
        public Task<bool> Update(Guid id, AttendanceUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<Attendance?> FindOne(Guid id);
        public Task<List<Attendance>> FindAll();

    }
}
