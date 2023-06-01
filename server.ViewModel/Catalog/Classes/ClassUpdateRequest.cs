using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Classes
{
    public class ClassUpdateRequest
    {
        public string ClassName { get; set; }
        public Guid IdCourse { get; set; }
        public string Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
