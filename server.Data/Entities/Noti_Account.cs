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

        public virtual AppUser AppUser { get; set; }
        public virtual Notification Notification { get; set; }
    }
}
