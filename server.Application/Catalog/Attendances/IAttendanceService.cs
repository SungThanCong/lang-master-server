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
        public Task<bool> Update(Guid idStudent,Guid idClassTime,AttendanceUpdateRequest request);
        public Task<bool> Remove(Guid idStudent, Guid idClassTime);
        public Task<Attendance?> FindOne(Guid idStudent, Guid idClassTime);
        public Task<List<Attendance>> FindAll();

    }
}
