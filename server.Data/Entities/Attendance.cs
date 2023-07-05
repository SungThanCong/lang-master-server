using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Attendance
    {
        public Guid IdAttendance { get; set; }
        public Guid IdStudent { get; set; }
        public Guid IdClassTime { get; set; }
        public DateTime CheckedDate { get; set; }
        public Student Student { get; set; }
        public ClassTime ClassTime { get; set; }
    }
}
