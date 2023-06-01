using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class CourseType
    {
        public Guid IdCourseType { get; set; }
        public string TypeName { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public List<Course> Courses { get; set; }
    }
}
