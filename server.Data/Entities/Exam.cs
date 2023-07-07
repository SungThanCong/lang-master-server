using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Exam
    {
        public Guid IdExam { get; set; }

        public string ExamName { get; set; }

        public string FileUrl { get; set; }

        public DateTime PostedDate { get; set; }

        public Guid IdClass { get; set; }

        public Guid IdTestType { get; set; }

        public Guid IdColumn { get; set; }

        public int TestTime { get; set; }

        public DateTime TestDate { get; set; }

        public virtual Class Class { get; set; }

        public virtual TestType TestType { get; set; }

        public virtual ColumnTranscript ColumnTranscript { get; set; }

        public virtual List<Testing> Testings { get; set; }
    }
}
