using Microsoft.EntityFrameworkCore;
using server.Data.EF;
using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Bills
{
    public class BillInfoService : IBillInfoService
    {
        LangDbContext _context;
        public BillInfoService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<BillInfo?> Create(BillInfoCreateRequest request)
        {
            BillInfo bif = new BillInfo()
            {
                IdBill = request.IdBill,
                IdCourse = request.IdCourse,
                Fee = request.Fee
            };
            await _context.BillInfos.AddAsync(bif);
            var result = await _context.SaveChangesAsync();

            if(result > 0)
            {
                return bif;
            }
            return null;
        }

        public async Task<List<BillInfo>> FindAll(Guid idBill)
        {
            return await _context.BillInfos.Where(x => x.IdBill == idBill).ToListAsync();
        }

        public async Task<BillInfo?> FindOne(Guid idBill, Guid idCourse)
        {
            return await _context.BillInfos.Where(x => x.IdBill == idBill && x.IdCourse == idCourse).FirstOrDefaultAsync();
        }

        public async Task<bool> Remove(Guid idBill, Guid idCourse)
        {
            var billInfo = await _context.BillInfos.Where(x => x.IdBill == idBill && x.IdCourse == idCourse).FirstOrDefaultAsync();
            if(billInfo != null)
            {
                _context.BillInfos.Remove(billInfo);

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }

        public async Task<bool> Update(Guid idBill, Guid idCourse, BillInfoUpdateRequest request)
        {
            var billInfo = await _context.BillInfos.Where(x => x.IdBill == idBill && x.IdCourse == idCourse).FirstOrDefaultAsync();
            if (billInfo != null)
            {
                billInfo.Fee = request.Fee;

                var result = await _context.SaveChangesAsync();
                if (result > 0) return true;
            }
            return false;
        }
    }
}
