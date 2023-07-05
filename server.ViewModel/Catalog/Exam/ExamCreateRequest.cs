using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Exam
{
    public class ExamCreateRequest
    {
        public string ExamName { get; set; }

        public string FileUrl { get; set; }

        public DateTime PostedDate { get; set; }

        public Guid IdClass { get; set; }

        public Guid IdTestType { get; set; }

        public Guid IdColumn { get; set; }

        public int TestTime { get; set; }

        public DateTime TestDate { get; set; }
    }
}
