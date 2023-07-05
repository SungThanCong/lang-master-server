using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Exams
{
    public class ExamService : IExamService
    {
        public LangDbContext _context;
        public ExamService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Exam?> Create(ExamCreateRequest request)
        {
            try
            {
                var exam = new Exam()
                {
                    ExamName = request.ExamName,
                    FileUrl = request.FileUrl,
                    PostedDate = request.PostedDate,
                    TestDate = request.TestDate,
                    TestTime = request.TestTime,
                    IdClass = request.IdClass,
                    IdTestType = request.IdTestType,
                    IdColumn = request.IdColumn,
                };
                await _context.Exams.AddAsync(exam);
                var result = await _context.SaveChangesAsync();
                return exam;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Exam>> FindAll()
        {
            return await _context.Exams.ToListAsync();
        }

        public async Task<Exam?> FindOne(Guid id)
        {
            return await _context.Exams.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {

                _context.Exams.Remove(exam);
                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> Update(Guid id, ExamUpdateRequest request)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam != null)
            {
                exam.ExamName = request.ExamName;
                exam.FileUrl = request.FileUrl;
                exam.PostedDate = request.PostedDate;
                exam.TestDate = request.TestDate;
                exam.TestTime = request.TestTime;
                exam.IdClass = request.IdClass;
                exam.IdTestType = request.IdTestType;
                exam.IdColumn = request.IdColumn;

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
