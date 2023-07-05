using server.Data.Entities;
using server.ViewModel.Catalog.Level;
using server.ViewModel.Catalog.Teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Teachings
{
    public interface ITeachingService
    {
        public Task<Teaching?> Create(TeachingCreateRequest request);
        public Task<bool> Update(Guid id, TeachingUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Teaching>> FindAll();
        public Task<Teaching?> FindOne(Guid id);
    }
}
