using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.Attendance
{
    public class AttendanceCreateRequest
    {
        public Guid IdStudent { get; set; }
        public Guid IdClassTime { get; set; }
        public DateTime CheckedDate { get; set; }
    }
}
