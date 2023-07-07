using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.TimeFrame
{
    public class TimeFrameUpdateRequest
    {
        public Guid IdTimeFrame { get; set; }
        public bool Activate { get; set; }
        public string StartingTime { get; set; }
        public string EndingTime { get; set; }
    }
}
