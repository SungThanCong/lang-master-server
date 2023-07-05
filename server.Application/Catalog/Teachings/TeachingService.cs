using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Teachings
{
    public class TeachingService : ITeachingService
    {
        LangDbContext _context;
        public TeachingService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Teaching?> Create(TeachingCreateRequest request)
        {
            Teaching teaching = new Teaching()
            {
                IdClass = request.IdClass,
                IdLecturer = request.IdLecturer
            }; 
            await _context.Teachings.AddAsync(teaching);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return teaching;
            }
            return null;
        }

        public async Task<List<Teaching>> FindAll()
        {
            return await _context.Teachings.ToListAsync();
        }

        public async Task<Teaching?> FindOne(Guid id)
        {
            return await _context.Teachings.FindAsync(id);

        }

        public async Task<bool> Remove(Guid id)
        {
            var teaching = await _context.Teachings.FindAsync(id);
            if(teaching != null)
            {
                _context.Teachings.Remove(teaching);
                var result = await _context.SaveChangesAsync();
                if(result > 0)
                {
                    return true;
                }
            }
            return false;

        }

        public async Task<bool> Update(Guid id, TeachingUpdateRequest request)
        {
            var teaching = await _context.Teachings.FindAsync(id);
            if (teaching != null)
            {
                teaching.IdClass = request.IdClass; 

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
