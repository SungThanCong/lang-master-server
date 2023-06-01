using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Learning
    {
        public Guid IdStudent { get; set; }

        public Guid IdClass { get; set;}

        public Student Student { get; set; }

        public Class Class { get; set; }
    }
}
