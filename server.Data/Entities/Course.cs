using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Course
    {
        public Guid IdCourse { get; set; }

        public string CourseName { get; set; }

        public int Fee { get; set; }

        public string Description { get; set; }

        public Guid IdLevel { get; set; }

        public Guid IdCourseType { get; set; }

        public int Max { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Level Level { get; set; }

        public virtual CourseType CourseType { get; set; }

        public virtual List<Class> Classes { get; set; }
        public virtual List<ColumnCourse> ColumnCourses { get; set; }


    }
}
