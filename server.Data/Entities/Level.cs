using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Level
    {
        public Guid IdLevel { get; set; }
        public string LevelName { get; set; }
        public int Point { get; set; }

        public string Language { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<Course> Courses { get; set; }
    }
}
