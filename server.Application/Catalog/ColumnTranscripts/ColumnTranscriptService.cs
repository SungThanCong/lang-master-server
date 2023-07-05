using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.ColumnTranscript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.ColumnTranscripts
{
    public class ColumnTranscriptService : IColumnTranscriptService
    {
        LangDbContext _context;
        public ColumnTranscriptService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<ColumnTranscript?> Create(ColumnTranscriptCreateRequest request)
        {
            try
            {
                ColumnTranscript columnTranscript = new ColumnTranscript()
                {
                    ColumnName = request.ColumnName,
                    Max = request.Max,
                    Min = request.Min
                };
                await _context.ColumnTranscripts.AddAsync(columnTranscript);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return columnTranscript;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<List<ColumnTranscript>> FindAll()
        {
            return await _context.ColumnTranscripts.ToListAsync();
        }

        public async Task<ColumnTranscript?> FindOne(string id)
        {
            return await _context.ColumnTranscripts.FindAsync(id);
        }

        public async Task<bool> Remove(string id)
        {
            var columnTranscript = await _context.ColumnTranscripts.FindAsync(id);
            if (columnTranscript != null)
            {
                _context.ColumnTranscripts.Remove(columnTranscript);

                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(string id, ColumnTranscriptUpdateRequest request)
        {
            var columnTranscript = await _context.ColumnTranscripts.FindAsync(id);
            if (columnTranscript != null)
            {
                columnTranscript.ColumnName = request.ColumnName;
                columnTranscript.Min = request.Min;
                columnTranscript.Max = request.Max;

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
