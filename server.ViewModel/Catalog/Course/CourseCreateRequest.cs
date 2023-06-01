using server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Course
{
    public class CourseCreateRequest
    {
        public string CourseName { get; set; }

        public int Fee { get; set; }

        public string Description { get; set; }

        public Guid IdLevel { get; set; }

        public Guid IdCourseType { get; set; }

        public int Max { get; set; }

    }
}
