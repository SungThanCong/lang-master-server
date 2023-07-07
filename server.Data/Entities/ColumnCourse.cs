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

        public virtual ColumnTranscript ColumnTranscript { get; set; }

        public virtual Course Course { get; set; }
    }
}
