using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Accounts
{
    public class UserService : IUserService
    {
        private readonly LangDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserService(LangDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
   
        public async Task<object> Create(UserCreateRequest request)
        {
            try
            {
                AppUser appUser = new AppUser()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    DisplayName = request.DisplayName,
                    Dob = request.Dob,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    ImageUrl = request.ImageUrl,
                };
                var result = await _userManager.CreateAsync(appUser, request.Password);
                if (result == IdentityResult.Success)
                {
                    await _userManager.AddToRoleAsync(appUser, request.IdRole);
                    return appUser;
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }

            return "Create user is not success";
        }

        public async Task<List<UserViewModel>> FindAll()
        {
            List<UserViewModel> list = new List<UserViewModel>();
            foreach(var user in _userManager.Users)
            {
                UserViewModel model = new UserViewModel();
                model.UserName = user.UserName;
                model.Email = user.Email;
                model.DisplayName = user.DisplayName;
                model.Dob = user.Dob;
                model.Gender = user.Gender;
                model.PhoneNumber = user.PhoneNumber;
                model.Address = user.Address;
                model.ImageUrl = user.ImageUrl;
                list.Add(model);
            }
            return list;
        }

        public async Task<UserViewModel> FindOne(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user != null)
            {
                UserViewModel model = new UserViewModel();
                model.UserName = user.UserName;
                model.Email = user.Email;
                model.DisplayName = user.DisplayName;
                model.Dob = user.Dob;
                model.Gender = user.Gender;
                model.PhoneNumber = user.PhoneNumber;
                model.Address = user.Address;
                model.ImageUrl = user.ImageUrl;

                return model;
            }
            return null;
        }

        public async Task<bool> Remove(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if(user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if(result == IdentityResult.Success)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(string id, UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            if (user != null)
            {
                user.UserName = request.UserName;
                user.Email = request.Email;
                user.DisplayName = request.DisplayName;
                user.Dob = request.Dob;
                user.Gender = request.Gender;
                user.PhoneNumber = request.PhoneNumber;
                user.Address = request.Address;
                user.ImageUrl = request.ImageUrl;

                var result = await _context.SaveChangesAsync();

                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

       
    }
}
