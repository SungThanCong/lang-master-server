using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class TestType
    {
        public Guid IdTestType { get; set; }

        public string TypeName { get; set; }

        public List<Exam> Exams { get; set; } 
    }
}
