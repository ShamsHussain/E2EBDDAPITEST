using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Models.Response
{
    public class WorkflowGetResponse
    {
        public List<WorkflowDetail> Data { get; set; }
        public int TotalRows { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
