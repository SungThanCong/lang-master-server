using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class ColumnCourse
    {
        public Guid IdColumn { get; set; }

        public Guid IdCourse { get; set; }

        public ColumnTranscript ColumnTranscript { get; set; }

        public Course Course { get; set; }
    }
}
