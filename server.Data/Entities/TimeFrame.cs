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

        public string StartingTime { get; set; }

        public string EndingTime { get; set; }

        public bool Activate { get; set; }

        public virtual List<ClassTime> ClassTimes { get; set; }
    }
}
