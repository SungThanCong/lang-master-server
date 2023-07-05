using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Attendances
{
    public class AttendanceService : IAttendanceService
    {
        LangDbContext _context;
        public AttendanceService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Attendance?> Create(AttendanceCreateRequest request)
        {
            Attendance attendance = new Attendance();
            {
                attendance.IdStudent = request.IdStudent;
                attendance.IdClassTime = request.IdClassTime;
                attendance.CheckedDate = request.CheckedDate;
            }
            await _context.Attendances.AddAsync(attendance);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return attendance;
            }
            return null;
        }

        public async Task<List<Attendance>> FindAll()
        {
            return await _context.Attendances.ToListAsync();
        }

        public async Task<Attendance?> FindOne(Guid id)
        {
            //return await _context.Attendances.Where(x=> x.IdStudent == idStudent && x.IdClassTime == idClassTime).FirstOrDefaultAsync();
            return await _context.Attendances.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var result = await _context.Attendances.FindAsync(id);

            if (result != null)
            {
                _context.Attendances.Remove(result);
                return false;
            }
            return true;
        }

        public async Task<bool> Update(Guid id, AttendanceUpdateRequest request)
        {
            var attendance = await _context.Attendances.FindAsync(id);
            if (attendance != null)
            {
                attendance.CheckedDate = request.CheckedDate;
                var result = await _context.SaveChangesAsync();

                if(result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
