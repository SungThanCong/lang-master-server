using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.ViewModel.Catalog.ColumnTranscript
{
    public class ColumnTranscriptCreateRequest
    {

        public string ColumnName { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }
    }
}
