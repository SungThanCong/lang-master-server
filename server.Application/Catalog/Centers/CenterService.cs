using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Centers
{
    public class CenterService : ICenterService
    {
        LangDbContext _context;
        public CenterService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Center?> Create(CenterCreateRequest request)
        {
            Center center = new Center()
            {
               Address = request.Address,
               CenterName = request.CenterName,
            };
            await _context.Centers.AddAsync(center);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return center;
            }
            return null;
        }

        public async Task<List<Center>> FindAll()
        {
            return await _context.Centers.ToListAsync();
        }

        public async Task<Center?> FindOne(string id)
        {
            return await _context.Centers.FindAsync(id);

        }

        public async Task<bool> Remove(string id)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center != null)
            {
                _context.Centers.Remove(center);

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> Update(string id, CenterUpdateRequest request)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center != null)
            {
                center.Address = request.Address;
                center.CenterName = request.CenterName;

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
