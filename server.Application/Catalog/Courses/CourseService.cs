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
    public class CourseService : ICourseService
    {
        LangDbContext _context;
        public CourseService(LangDbContext context)
        {
            _context = context;
        }
        public async Task<Course?> Create(CourseCreateRequest request)
        {
            var course = new Course()
            {
                CourseName = request.CourseName,
                IdCourseType = request.IdCourseType,
                Description = request.Description,
                Fee = request.Fee,
                IdLevel = request.IdLevel,
                Max = request.Max,
                IsDeleted = false
            };
            await _context.Courses.AddAsync(course);
            var result =await _context.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> FindAll()
        {
            return await _context.Courses.Where(x => x.IsDeleted == false).ToListAsync();
        }

        public async Task<Course?> FindOne(Guid idCourse)
        {
            return await _context.Courses.Where(x => x.IsDeleted == false && x.IdCourse == idCourse).FirstOrDefaultAsync();

        }

        public async Task<bool> Remove(Guid idCourse)
        {
            var course = await _context.Courses.FindAsync(idCourse);
            if(course != null)
            {
                course.IsDeleted = true;

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> Update(Guid idCourse, CourseUpdateRequest request)
        {
            var course = await _context.Courses.FindAsync(idCourse);
            if (course != null)
            {
                course.CourseName = request.CourseName;
                course.Fee = request.Fee;
                course.Description = request.Description;
                course.IdCourseType = request.IdCourseType;
                course.IdLevel = request.IdLevel;

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
