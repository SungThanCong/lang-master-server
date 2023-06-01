using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class BillInfo
    {
        public Guid IdBill { get; set; }
        public Guid IdCourse { get; set; }
        public decimal Fee { get; set; }

        public Bill Bill { get; set; }
        public Course Course { get; set; }
    }
}
