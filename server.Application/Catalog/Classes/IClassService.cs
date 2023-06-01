using server.Data.Entities;
using server.ViewModel.Catalog.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Classes
{
    public interface IClassService
    {
        public Task<Class?> Create(ClassCreateRequest request);
        public Task<bool> Update(string id, ClassUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<Class>> FindAll();
        public Task<Class?> FindOne(string id);
    }
}
