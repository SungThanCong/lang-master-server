using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.ColumnCourse
{
    public class ColumnCourseUpdateRequest
    {
        public Guid IdColumn { get; set; }

        public Guid IdCourse { get; set; }
    }
}
