using server.Data.Entities;
using server.ViewModel.Catalog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Classes
{
    public interface IClassTimeService
    {
        public Task<ClassTime?> Create(ClassTimeCreateRequest request);
        public Task<bool> Update(string id, ClassTimeUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<ClassTime>> FindAll();
        public Task<ClassTime?> FindOne(string id);
    }
}
