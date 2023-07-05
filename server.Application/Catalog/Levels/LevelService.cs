using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Levels
{
    public class LevelService : ILevelService
    {
        LangDbContext _context;
        public LevelService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Level?> Create(LevelCreateRequest request)
        {
            Level level = new Level()
            {
                LevelName = request.LevelName,
                Point = request.Point,
                Language = request.Language
            };
            await _context.Levels.AddAsync(level);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return level;
            }
            return null;
        }

        public async Task<List<Level>> FindAll()
        {
            return await _context.Levels.ToListAsync();
        }

        public async Task<Level?> FindOne(Guid idLevel)
        {
            return await _context.Levels.FindAsync(idLevel);
        }

        public async Task<bool> Remove(Guid idLevel)
        {
            var level = await _context.Levels.FindAsync(idLevel);
            if (level != null)
            {
                _context.Levels.Remove(level);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(Guid idLevel, LevelUpdateRequest request)
        {
            var level = await _context.Levels.FindAsync(idLevel);
            if (level != null)
            {
                level.LevelName = request.LevelName;
                level.Point = request.Point;
                level.Language = request.Language;


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
