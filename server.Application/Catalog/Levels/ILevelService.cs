using server.Data.Entities;
using server.ViewModel.Catalog.Course;
using server.ViewModel.Catalog.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.Levels
{
    public interface ILevelService
    {
        public Task<Level?> Create(LevelCreateRequest request);
        public Task<bool> Update(Guid idLevel, LevelUpdateRequest request);
        public Task<bool> Remove(Guid idLevel);
        public Task<List<Level>> FindAll();
        public Task<Level?> FindOne(Guid idLevel);
    }
}
