using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Testing
    {
        public Guid IdStudent { get; set; }

        public Guid IdExam { get; set; }

        public float Score { get; set; }

        public Exam Exam { get; set; }

        public Student Student { get; set; }
    }
}
