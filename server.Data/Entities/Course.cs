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

        public Level Level { get; set; }

        public CourseType CourseType { get; set; }

        public List<BillInfo> BillInfos { get; set; }
        public List<Class> Classes { get; set; }
        public List<ColumnCourse> ColumnCourses { get; set; }


    }
}
