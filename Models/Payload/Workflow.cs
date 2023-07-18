using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowBddFramework.Models.Response;

namespace WorkflowBddFramework.Models.Payload
{
    public class Workflow
    {
        public string WorkflowName { get; set; }
        public int WorkflowId { get; set; }
        public string CurrentStage { get; set; }
        public string ActionName { get; set; }
        public string Notes { get; set; }
        public StageDataPayload StageData { get; set; } = new StageDataPayload();
    }
}
