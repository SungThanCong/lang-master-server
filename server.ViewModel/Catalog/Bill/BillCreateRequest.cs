using server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Bill
{
    public class BillCreateRequest
    {
        public Guid IdBill { get; set; }
        public Guid IdEmployee { get; set; }
        public Guid IdStudent { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal TotalFee { get; set; }

        public List<BillInfo> BillInfos { get; set; }
    }
}
