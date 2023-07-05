using server.Data.Entities;
using server.ViewModel.Catalog.Level;
using server.ViewModel.Catalog.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Parameters
{
    public interface IParameterService
    {
        public Task<Parameter?> Create(ParameterCreateRequest request);
        public Task<bool> Update(string name, ParameterUpdateRequest request);
        public Task<bool> Remove(Guid id);
        public Task<List<Parameter>> FindAll();
        public Task<Parameter?> FindOne(Guid id);
    }
}
