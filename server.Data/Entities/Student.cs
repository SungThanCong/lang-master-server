using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Student
    {
        public Guid IdStudent { get; set; }

        public Guid IdUser { get; set; }

        public bool IsDeleted { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual List<Bill> Bills { get; set; }
        public virtual List<Learning> Learnings { get; set; }
        public virtual List<Testing> Testings { get; set; }
        public virtual List<Attendance> Attendances { get; set; }
    }
}
