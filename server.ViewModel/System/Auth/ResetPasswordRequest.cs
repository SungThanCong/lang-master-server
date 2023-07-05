using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.System.Auth
{
    public class ResetPasswordRequest
    {
        public string Username { get; set; }
        public string Code { get; set; }
        public string Password { get; set; }
    }
}
