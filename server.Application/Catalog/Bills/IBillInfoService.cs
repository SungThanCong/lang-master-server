using server.Data.Entities;
using server.ViewModel.Catalog.Bill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Bills
{
    public interface IBillInfoService
    {
        public Task<BillInfo?> Create(BillInfoCreateRequest request);
        public Task<bool> Update(Guid idBill, Guid idCourse, BillInfoUpdateRequest request);
        public Task<bool> Remove(Guid idBill, Guid idCourse);
        public Task<List<BillInfo>> FindAll(Guid idBill);
        public Task<BillInfo?> FindOne(Guid idBill, Guid idCourse);
    }
}
