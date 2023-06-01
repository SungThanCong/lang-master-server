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
    public class BillService : IBillService
    {
        LangDbContext _context;
        public BillService(LangDbContext context)
        {
            _context = context;
        }

        public async Task<Bill> Create(BillCreateRequest request)
        {
            Bill bill = new Bill()
            {
                CreatedDate = request.CreatedDate,
                TotalFee = request.TotalFee,
                IdEmployee = request.IdEmployee,
                IdStudent = request.IdStudent,
                BillInfos = request.BillInfos
            };

            await _context.Bills.AddAsync(bill);
            var result = await _context.SaveChangesAsync();

            if(result > 0)
            {
                return bill;
            }

            return null;
        }

        public async Task<List<Bill>> FindAll()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> FindOne(string id)
        {
            return await _context.Bills.FindAsync(id);
        }

        public async Task<bool> Remove(string id)
        {
            var bill = await _context.Bills.FindAsync(id);
            
            if(bill != null)
                _context.Bills.Remove(bill);

            var result = await _context.SaveChangesAsync();
            if (result > 0) return true;

            return false;
        }

        public async Task<bool> Update(string id, BillUpdateRequest request)
        {
            var bill =  await _context.Bills.FindAsync(id);
            if(bill != null)
            {
                bill.TotalFee = request.TotalFee;
                bill.BillInfos = request.BillInfos;

                var result = await _context.SaveChangesAsync();
                if (result <= 0) return false;
            }
            return true;
        }
    }
}
