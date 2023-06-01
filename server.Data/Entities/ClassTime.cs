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

        public Class Class { get; set; }

        public TimeFrame TimeFrame { get; set; }

        public int DayOfWeek { get; set; }

        public List<Attendance> Attendances { get; set; }
    }
}
