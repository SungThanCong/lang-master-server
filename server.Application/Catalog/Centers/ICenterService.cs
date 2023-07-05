using server.Data.Entities;
using server.ViewModel.Catalog.Center;
using server.ViewModel.Catalog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Centers
{
    public interface ICenterService
    {
        public Task<Center?> Create(CenterCreateRequest request);
        public Task<bool> Update(string id, CenterUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<Center>> FindAll();
        public Task<Center?> FindOne(string id);
    }
}
