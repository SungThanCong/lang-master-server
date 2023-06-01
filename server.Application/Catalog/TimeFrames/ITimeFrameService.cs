using Azure.Core;
using server.Data.Entities;
using server.ViewModel.Catalog.Course;
using server.ViewModel.Catalog.TimeFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.TimeFrames
{
    public interface ITimeFrameService
    {
        public Task<TimeFrame?> Create(TimeFrameCreateRequest request);
        public Task<bool> Update(Guid id, TimeFrameUpdateRequest request);
        public Task<bool> UpdateAll(List<TimeFrameUpdateRequest> requests);
        public Task<bool> Remove(Guid id);
        public Task<List<TimeFrame>> FindAll();
        public Task<TimeFrame?> FindOne(Guid id);
    }
}
