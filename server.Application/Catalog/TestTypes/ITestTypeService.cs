using server.Data.Entities;
using server.ViewModel.Catalog.Teaching;
using server.ViewModel.Catalog.TestType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.TestTypes
{
    public interface ITestTypeService
    {
        public Task<TestType?> Create(TestTypeCreateRequest request);
        public Task<bool> Update(Guid id, TestTypeUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<TestType>> FindAll();
        public Task<TestType?> FindOne(Guid id);
    }
}
