using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.ColumnCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.ColumnCourses
{
    public class ColumnCourseService : IColumnCourseService
    {
        LangDbContext _context;
        public ColumnCourseService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<ColumnCourse?> Create(ColumnCourseCreateRequest request)
        {
            try
            {
                ColumnCourse columnCourse = new ColumnCourse()
                {
                    IdColumn = request.IdColumn,
                    IdCourse = request.IdCourse,
                };
                await _context.ColumnCourses.AddAsync(columnCourse);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return columnCourse;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<List<ColumnCourse>> FindAll()
        {
            return await _context.ColumnCourses.ToListAsync();
        }

        public async Task<ColumnCourse?> FindOne(string id)
        {
            return await _context.ColumnCourses.FindAsync(id);
        }

        public async Task<bool> Remove(string id)
        {
            var columnCourse = await _context.ColumnCourses.FindAsync(id);
            if (columnCourse != null)
            {
                _context.ColumnCourses.Remove(columnCourse);

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public Task<bool> Update(string id, ColumnCourseUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
