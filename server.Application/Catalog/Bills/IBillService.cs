using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Bills
{
    public interface IBillService
    {
        public Task<Bill> Create(BillCreateRequest request);
        public Task<bool> Update(string id, BillUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<Bill>> FindAll();
        public Task<Bill> FindOne(string id);
    }
}
