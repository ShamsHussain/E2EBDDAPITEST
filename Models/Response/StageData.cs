using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowBddFramework.Models.Response
{
    public class StageData
    {
        public string ClientId { get; set; }
        public string CodingRequestId { get; set; }
        public string OrderNumber { get; set; }
        public string ProcedureId { get; set; }
        public string ? Result { get; set; }
        public string ? Remarks { get; set; }
        public List<object> ? FollowUpProcedures { get; set; }
        public bool isOwnerShipRelease { get; set; }
    }
}
