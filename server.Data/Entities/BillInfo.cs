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
        public Guid IdClass { get; set; }
        public decimal Fee { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Class Class { get; set; }
    }
}
