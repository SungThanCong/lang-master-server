using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Classes
{
    public class ClassTimeService : IClassTimeService
    {
        LangDbContext _context;
        public ClassTimeService(LangDbContext context)
        {
            _context = context;
        }
        public async Task<ClassTime?> Create(ClassTimeCreateRequest request)
        {
            ClassTime classTime = new ClassTime()
            {
                DayOfWeek = request.DayOfWeek,
                IdClass = request.IdClass,
                IdTimeFrame = request.IdTimeFrame,
                
            };
            await _context.ClassTimes.AddAsync(classTime);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return classTime;
            }
            return null;
        }

        public async Task<List<ClassTime>> FindAll()
        {
            return await _context.ClassTimes.ToListAsync();
        }

        public async Task<ClassTime?> FindOne(string id)
        {
            return await _context.ClassTimes.FindAsync(id);
        }

        public async Task<bool> Remove(string id)
        {
            var classTime = await _context.ClassTimes.FindAsync(id);
            if(classTime != null)
            {
                _context.ClassTimes.Remove(classTime);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(string id, ClassTimeUpdateRequest request)
        {
            var classTime = await _context.ClassTimes.FindAsync(id);
            if (classTime != null)
            {
                classTime.IdClass = request.IdClass;
                classTime.DayOfWeek = request.DayOfWeek;
                classTime.IdTimeFrame = request.IdTimeFrame;

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
