using server.ViewModel.System.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.System.Auth
{
    public interface IAuthService
    {
        public Task<object> SignIn(LoginRequest request);

        public Task<string> RefreshToken(string requestToken);

        public Task<string> SendEmail(SendEmailRequest request);

        public Task<string> ResetPassword();




    }
}
