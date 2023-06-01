using server.Data.Entities;
using server.ViewModel.Catalog.Classes;
using server.ViewModel.Catalog.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Courses
{
    public interface ICourseTypeService
    {
        public Task<CourseType?> Create(CourseTypeCreateRequest request);
        public Task<bool> Update(string id, CourseTypeUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<CourseType>> FindAll();
        public Task<CourseType?> FindOne(string id);
    }
}
