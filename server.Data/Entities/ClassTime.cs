using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class ClassTime
    {
        public Guid IdClassTime { get; set; }

        public Guid IdClass { get; set; }

        public Guid IdTimeFrame { get; set; }

        public virtual Class Class { get; set; }

        public virtual TimeFrame TimeFrame { get; set; }

        public int DayOfWeek { get; set; }

        public virtual List<Attendance> Attendances { get; set; }
    }
}
