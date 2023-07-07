using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Students
{
    public class StudentService : IStudentService
    {
        LangDbContext _context;
        UserManager<AppUser> _userManager;
        public StudentService(LangDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<Student?> Create(StudentCreateRequest request)
        {
            try
            {
                AppUser appUser = new AppUser()
                {
                    UserName = "student1",
                    Email = request.Email,
                    DisplayName = request.DisplayName,
                    Dob = DateTime.Parse(request.Dob),
                    Gender = request.Gender,
                    PhoneNumber = request.PhoneNumber,
                    Address = request.Address,
                    IsActivated = true,
                };
                var result = await _userManager.CreateAsync(appUser,"Aa@123");
                if (result == IdentityResult.Success)
                {

                    Student student = new Student()
                    {
                        IdUser = appUser.Id,
                        IsDeleted = false,

                    };
                    await _context.Students.AddAsync(student);
                    var success = await _context.SaveChangesAsync();
                    if (success > 0)
                    {
                        return student;
                    }

                }

            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }

        public async Task<List<Student>> FindAll()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<List<Student>> FindByIdClass(Guid idClass)
        {
            return await _context.Students.Join(
                                    _context.Learnings,
                                    student => student.IdStudent,
                                    learning => learning.IdStudent,
                                    (student, learning) => new { student, learning.IdClass })
                .Where(x => x.IdClass == idClass).Select(x => x.student).ToListAsync();
        }
        public async Task<Student?> FindOne(Guid id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                student.AppUser.IsActivated = false;
                student.IsDeleted = true;

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(Guid id, StudentUpdateRequest request)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                student.AppUser.DisplayName = request.DisplayName;
                student.AppUser.Gender = request.Gender;
                student.AppUser.PhoneNumber = request.PhoneNumber;
                student.AppUser.Email = request.Email;
                student.AppUser.Address = request.Address;
                student.AppUser.Dob = request.Dob;

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateScore(List<Testing> testings)
        {
            foreach (Testing test in testings)
            {
                var data = await _context.Testings.Where(
                    x => x.IdStudent == test.IdStudent && x.IdExam == test.IdExam).FirstOrDefaultAsync();
                if(data != null)
                {
                    data.Score = test.Score;
                }
                else
                {
                    await _context.Testings.AddAsync(test);
                }
            }
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
