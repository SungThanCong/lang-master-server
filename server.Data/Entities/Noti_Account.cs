using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Noti_Account
    {
        public Guid IdNotification { get; set; }
        public Guid IdAccount { get; set; }

        public AppUser AppUser { get; set; }
        public Notification Notification { get; set; }
    }
}
