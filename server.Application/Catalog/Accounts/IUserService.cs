using server.Data.Entities;
using server.ViewModel.Catalog.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Accounts
{
    public interface IUserService
    {
        public Task<object> Create(UserCreateRequest request);
        public Task<bool> Update(string id, UserUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<UserViewModel>> FindAll();
        public Task<UserViewModel> FindOne(string id);
    }
}
