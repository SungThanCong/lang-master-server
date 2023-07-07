using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class ColumnTranscript
    {
        public Guid IdColumn { get; set; }

        public string ColumnName { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public virtual List<ColumnCourse> ColumnCourses { get; set; }
        public virtual List<Exam> Exams { get; set; }

    }
}
