using server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Classes
{
    public class ClassTimeCreateRequest
    {
        public Guid IdClass { get; set; }

        public Guid IdTimeFrame { get; set; }

        public int DayOfWeek { get; set; }

    }
}
