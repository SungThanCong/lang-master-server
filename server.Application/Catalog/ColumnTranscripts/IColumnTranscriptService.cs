using server.Data.Entities;
using server.ViewModel.Catalog.ColumnCourse;
using server.ViewModel.Catalog.ColumnTranscript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Application.Catalog.ColumnTranscripts
{
    public interface IColumnTranscriptService
    {
        public Task<ColumnTranscript?> Create(ColumnTranscriptCreateRequest request);
        public Task<bool> Update(string id, ColumnTranscriptUpdateRequest request);
        public Task<bool> Remove(string id);
        public Task<List<ColumnTranscript>> FindAll();
        public Task<ColumnTranscript?> FindOne(string id);
    }
}
