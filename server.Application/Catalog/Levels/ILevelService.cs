using server.Data.Entities;
using server.ViewModel.Catalog.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Levels
{
    public interface ILevelService
    {
        public Task<Level?> Create(CourseCreateRequest request);
        public Task<bool> Update(Guid idCourse, CourseUpdateRequest request);
        public Task<bool> Remove(Guid idCourse);
        public Task<List<Course>> FindAll();
        public Task<Course?> FindOne(Guid idCourse);
    }
}
