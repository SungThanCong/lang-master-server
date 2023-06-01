using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.User
{
    public class UserUpdateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public int Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string IdRole { get; set; }
        public DateTime Dob { get; set; }
    }
}
