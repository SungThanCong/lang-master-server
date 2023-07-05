using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.TestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.TestTypes
{
    public class TestTypeService : ITestTypeService
    {
        LangDbContext _context;
        public TestTypeService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<TestType?> Create(TestTypeCreateRequest request)
        {
            try
            {
                TestType testType = new TestType()
                {
                    TypeName = request.TypeName
                };
                await _context.TestTypes.AddAsync(testType);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return testType;
                }
                return null;
            }catch(Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<List<TestType>> FindAll()
        {
            return await _context.TestTypes.ToListAsync();
        }

        public async Task<TestType?> FindOne(Guid id)
        {
            return await _context.TestTypes.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var testType = await _context.TestTypes.FindAsync(id);
            if (testType != null)
            {
                _context.TestTypes.Remove(testType);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(Guid id, TestTypeUpdateRequest request)
        {
            var testType = await _context.TestTypes.FindAsync(id);
            if (testType != null)
            {
                testType.TypeName = request.TypeName;

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
