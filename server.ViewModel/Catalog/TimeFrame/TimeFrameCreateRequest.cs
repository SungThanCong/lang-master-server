using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.TimeFrame
{
    public class TimeFrameCreateRequest
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public bool Active { get; set; }
    }
}
