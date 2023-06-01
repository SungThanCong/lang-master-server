using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Bill
    {
        public Guid IdBill { get; set; }
        public Guid IdEmployee { get; set; }
        public Guid IdStudent { get; set; }
        public DateTime CreatedDate { get; set; }

        public Employee Employee { get; set; }
        public Student Student { get; set; }
        public decimal TotalFee { get; set; }

        public List<BillInfo> BillInfos { get; set; }

    }
}
