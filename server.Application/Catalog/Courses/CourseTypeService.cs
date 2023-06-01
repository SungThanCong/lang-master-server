using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Courses
{
    public class CourseTypeService : ICourseTypeService
    {
        LangDbContext _context;
        public CourseTypeService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<CourseType?> Create(CourseTypeCreateRequest request)
        {
            CourseType courseType = new CourseType()
            {
                Description = request.Description,
                TypeName = request.TypeName,
                IsDeleted = false
            };
            await _context.CourseTypes.AddAsync(courseType);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return courseType;
            }
            return null;
        }

        public async Task<List<CourseType>> FindAll()
        {
            return await _context.CourseTypes.ToListAsync();
        }

        public async Task<CourseType?> FindOne(string id)
        {
            return await _context.CourseTypes.FindAsync(id);
        }

        public async Task<bool> Remove(string id)
        {
            var courseType = await _context.CourseTypes.FindAsync(id);
            if(courseType != null)
            {
                courseType.IsDeleted = true;
                var result = await _context.SaveChangesAsync();
                if(result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(string id, CourseTypeUpdateRequest request)
        {
            var courseType = await _context.CourseTypes.FindAsync(id);
            if (courseType != null)
            {
                courseType.Description = request.Description;
                courseType.TypeName = request.TypeName;

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
