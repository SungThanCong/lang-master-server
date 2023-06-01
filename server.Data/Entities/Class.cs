using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Class
    {
        public Guid IdClass { get; set; }
        public string ClassName { get; set; }
        public Guid IdCourse { get; set; }
        public string Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsDeleted { get; set; }

        public Course Course { get; set; }
        public List<ClassTime> ClassTimes { get; set; }
        public List<Exam> Exams { get; set; }
        public List<Learning> Learnings { get; set; }
        public List<Teaching> Teachings { get; set; }
    }
}
