﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Bill
{
    public class BillInfoCreateRequest
    {
        public Guid IdBill { get; set; }
        public Guid IdClass { get; set; }
        public decimal Fee { get; set; }
    }
}
