using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Teaching
{
    public class TeachingCreateRequest
    {
        public Guid IdLecturer { get; set; }

        public Guid IdClass { get; set; }
    }
}
