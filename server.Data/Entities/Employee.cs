using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Employee
    {
        public Guid IdEmployee { get; set; }

        public Guid IdUser { get; set; }

        public bool IsDeleted { get; set; }

        public virtual AppUser User { get; set; }

        public virtual List<Bill> Bills { get; set; }
    }
}
