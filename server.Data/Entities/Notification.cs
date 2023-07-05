using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class Notification
    {
        public Guid IdNotification { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsEmployee { get; set; }

        public List<Noti_Account> NotiAccounts { get; set; }
    }
}
