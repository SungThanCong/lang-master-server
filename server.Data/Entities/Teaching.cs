using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Teaching
    {
        public Guid IdTeaching { get; set; }

        public Guid IdLecturer { get; set; }

        public Guid IdClass { get; set; }

        public Class Class { get; set; }

        public Lecturer Lecturer { get; set; }
    }
}
