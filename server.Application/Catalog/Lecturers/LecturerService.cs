using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Lecturers
{
    public class LecturerService : ILecturerService
    {
        LangDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public LecturerService(LangDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Lecturer?> Create(LecturerCreateRequest request)
        {
            try
            {
                AppUser appUser = new AppUser()
                {
                    UserName = request.Username,
                    Email = request.Email,
                    DisplayName = request.DisplayName,
                    Dob = request.Dob,
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    ImageUrl = request.ImageUrl,
                    IsActivated = true,
                };
                var result = await _userManager.CreateAsync(appUser, request.Password);
                if (result == IdentityResult.Success)
                {
                    await _userManager.AddToRoleAsync(appUser, request.IdRole);

                    Lecturer lecturer = new Lecturer()
                    {
                        IdUser = appUser.Id,
                        IsDeleted = false,

                    };
                    await _context.Lecturers.AddAsync(lecturer);
                    var success = await _context.SaveChangesAsync();
                    if (success > 0)
                    {
                        return lecturer;
                    }

                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public async Task<List<Lecturer>> FindAll()
        {
            return await _context.Lecturers.ToListAsync();
        }

        public async Task<Lecturer?> FindOne(Guid id)
        {
            return await _context.Lecturers.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer != null)
            {
                lecturer.AppUser.IsActivated = false;
                lecturer.IsDeleted = true;
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(Guid id, LecturerUpdateRequest request)
        {
            var lecturer = await _context.Lecturers.FindAsync(id);
            if (lecturer != null)
            {
                lecturer.AppUser.DisplayName = request.DisplayName;
                lecturer.AppUser.Gender = request.Gender;
                lecturer.AppUser.PhoneNumber = request.PhoneNumber;
                lecturer.AppUser.ImageUrl = request.ImageUrl;
                lecturer.AppUser.Address = request.Address;
                lecturer.AppUser.Dob = request.Dob;

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
