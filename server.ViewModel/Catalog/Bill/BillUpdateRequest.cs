using server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Bill
{
    public class BillUpdateRequest
    {

        public decimal TotalFee { get; set; }

        public List<BillInfo> BillInfos { get; set; }
    }
}
