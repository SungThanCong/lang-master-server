using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Lecturer
    {
        public Guid IdLecturer { get; set; }
        public Guid IdUser { get; set; }
        public bool IsDeleted { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual List<Teaching> Teachings { get; set; }
    }
}
