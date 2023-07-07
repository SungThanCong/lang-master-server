using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string DisplayName { get; set; }

        public DateTime Dob { get; set; }

        public int Gender { get; set; }
        public string? Address { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActivated { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual Student Student { get; set; }
        public virtual RefreshTokens RefreshTokens { get; set; }
        public virtual List<Noti_Account> NotiAccounts { get; set; }
        public virtual List<ConfirmCodes> ConfirmCodes { get; set; }

    }
}
