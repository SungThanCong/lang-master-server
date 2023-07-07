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

        public virtual Course Course { get; set; }
        public virtual List<ClassTime> ClassTimes { get; set; }
        public virtual List<Exam> Exams { get; set; }
        public virtual List<Learning> Learnings { get; set; }
        public virtual List<Teaching> Teachings { get; set; }
        public virtual List<BillInfo> BillInfos { get; set; }

    }
}
