using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Parameter
    {
        public Guid IdParameter { get; set; }
        
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
