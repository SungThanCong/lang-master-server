using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class ConfirmCodes
    {
        public Guid id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Guid IdUser { get; set; }

        public AppUser AppUser { get; set; }
    }
}
