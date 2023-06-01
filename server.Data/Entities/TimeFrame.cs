using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class TimeFrame
    {
        public Guid IdTimeFrame { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public bool Active { get; set; }

        public List<ClassTime> ClassTimes { get; set; }
    }
}
