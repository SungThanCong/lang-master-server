using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Parameters
{
    public class ParameterService : IParameterService
    {
        LangDbContext _context;
        public ParameterService(LangDbContext context)
        {
            _context = context;
        }
        public async Task<Parameter?> Create(ParameterCreateRequest request)
        {
            try
            {
                Parameter parameter = new Parameter()
                {
                   Name = request.Name,
                   Value = request.Value,
                };
                await _context.Parameters.AddAsync(parameter);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return parameter;
                }
                return null;
            }catch(Exception ex)
            {
                return null;
            }
            return null;
        }

        public async Task<List<Parameter>> FindAll()
        {
            return await _context.Parameters.ToListAsync();
        }

        public async Task<Parameter?> FindOne(Guid id)
        {
            return await _context.Parameters.FindAsync(id);
        }

        public async Task<bool> Remove(Guid id)
        {
            var parameter = await _context.Parameters.FindAsync(id);
            if (parameter != null)
            {
                _context.Parameters.Remove(parameter);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Update(string name, ParameterUpdateRequest request)
        {
            var parameter = await _context.Parameters.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (parameter != null)
            {
                parameter.Value = request.Value;

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
