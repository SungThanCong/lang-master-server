using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Notification
{
    public class NotificationUpdateRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsEmployee { get; set; }
    }
}
