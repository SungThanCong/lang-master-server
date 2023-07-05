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
    public class ClassService : IClassService
    {
        LangDbContext _context;
        public ClassService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Class?> Create(ClassCreateRequest request)
        {
            Class @class = new Class()
            {
                ClassName = request.ClassName,
                EndDate = request.EndDate,
                IdCourse = request.IdCourse,
                StartDate = request.StartDate,
                Room = request.Room,
                IsDeleted = false,
            };
            await _context.Classes.AddAsync(@class);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return @class;
            }
            return null;
        }

        public async Task<List<Class>> FindAll()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> FindOne(string id)
        {
            return await _context.Classes.FindAsync(id);
        }

        public async Task<bool> Remove(string id)
        {
            var @class = await _context.Classes.FindAsync(id);
            if(@class != null)
            {
                @class.IsDeleted = true;
                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> Update(string id, ClassUpdateRequest request)
        {
            var @class = await _context.Classes.FindAsync(id);
            if (@class != null)
            {
                @class.ClassName = request.ClassName;
                @class.EndDate = request.EndDate;
                @class.IdCourse = request.IdCourse;
                @class.StartDate = request.StartDate;
                @class.Room = request.Room;

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
