using server.Data.Entities;
using server.ViewModel.Catalog.ColumnCourse;
using server.ViewModel.Catalog.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.ColumnCourses
{
    public interface IColumnCourseService
    {
        public Task<ColumnCourse?> Create(ColumnCourseCreateRequest request);
        public Task<bool> Update(string id, ColumnCourseUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<ColumnCourse>> FindAll();
        public Task<ColumnCourse?> FindOne(string id);
    }
}
